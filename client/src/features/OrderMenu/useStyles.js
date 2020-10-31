import makeStyles from "@material-ui/core/styles/makeStyles";

export default makeStyles(theme => ({
    menuBody: {
        marginBottom: 80,
        marginTop: theme.mixins.toolbar.minHeight + 10,
        marginLeft: 0,
        marginRight: 0,
        width: "100%"
    },
    menuTitle: {
        color: "inherit",
        fontSize: 20,
        "&:before": {
            borderColor: "rgb(0, 155, 160)"
        },
        "&:after": {
            borderColor: "inherit"
        },
        "& svg": {
            color: "inherit"
        }
    },
    expandDetail: {
        padding: "0 8px",
        display: "block"
    },
    foodGroup: {
        padding: 0
    },
    expandHead: {
        minHeight: "auto !important",
        padding: "0 14px 0 24px !important",
        "& .MuiExpansionPanelSummary-content": {
            margin: 0,
            justifyContent: "space-between",
            alignItems: "center"
        }
    },
    cartButton: {
        position: "fixed",
        bottom: 24,
        right: 8
    },
    clearBtn: {
        position: "fixed",
        bottom: 30,
        left: 8
    },
    foodOptions: {
        paddingLeft: "1.5em",
        fontSize: "0.95em",
        display: "block"
    },
    addtionalRequestField: {
        paddingTop: 0,
        paddingBottom: 0,
        "& .MuiTextField-root": {
            marginTop: 0
        },
        "& .MuiInputBase-root": {
            paddingRight: 100
        }
    },
    cart: {
        maxHeight: "90vh",
        overflow: "auto",
        "& hr": {
            margin: "0px 16px"
        }
    },
    cartHeader: {
        position: "sticky",
        top: 0,
        background: "white",
        zIndex: 10
    },
    footer: {
        background: "rgb(0, 155, 160)"
    }
}));