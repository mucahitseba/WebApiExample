﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.API.Attributes;
using WebApi.API.Security;

namespace WebApi.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ApiExceptionAttribute());
            config.MessageHandlers.Add(new APIKeyHandler());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
