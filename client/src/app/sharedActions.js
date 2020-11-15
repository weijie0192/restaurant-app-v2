import encryptionProvider from "common/encryptionProvider";
import { enqueueSnackbar, handleOpenModal, setLoading } from "./Indicator/indicatorSlice";

export const encryptionAction = (json, success) => dispatch => {
    const encryptedInfo = encryptionProvider.encrypt(json);
    if (encryptedInfo) {
        success(encryptedInfo);
    } else {
        dispatch(
            enqueueSnackbar({
                message: "Encryption Failed",
                variant: "error"
            })
        );
    }
};

export const asyncAction = ({
    promise,
    success,
    failed,
    completed,
    hideErrorModal,
    toggleLoadingFor
}) => async dispatch => {
    try {
        if (toggleLoadingFor) {
            dispatch(setLoading({ target: toggleLoadingFor, loading: true }));
        }

        const res = await promise();
        const json = await res.json();
        if (res.ok) {
            if (success) success(json);
        } else {
            const error = new Error();
            error.errors = json;
            error.res = res;
            throw error;
        }
    } catch (e) {
        console.error(e);
        if (failed) failed(e);

        if (!hideErrorModal) {
            let title = "Request Error";
            if (e.res) {
                switch (e.res.status) {
                    case 404:
                        title = "Not Found";
                        break;
                    case 400:
                        title = "Bad Request";
                        break;
                    case 401:
                        title = "Unauthorized";
                        break;
                    default:
                }
                title = `${e.res.status} ${title}`;
            }
            dispatch(
                handleOpenModal({
                    title: title,
                    color: "secondary",
                    message: !e.errors && "Unexcepted error occurred, please refresh and retry!",
                    messages: e.errors
                })
            );
        }
    }

    if (completed) completed();

    if (toggleLoadingFor) {
        dispatch(setLoading({ target: toggleLoadingFor, loading: false }));
    }
};
