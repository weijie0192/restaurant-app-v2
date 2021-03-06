﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Middleware
{

    public static class CustomCorsPolicy
    {

        public const string CUSTOM_CORS = "CustomCors";

        public static void UseCustomCors(this IServiceCollection services, string allowedHosts)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CUSTOM_CORS,
                    builder =>
                    {
                        builder
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();

                        if(allowedHosts == "*")
                        {
                            builder.SetIsOriginAllowed(origin => true);
                        }
                        else
                        {
                            builder.WithOrigins(allowedHosts.Split(";"));
                        }
                    });
            });
        }

    }
}
