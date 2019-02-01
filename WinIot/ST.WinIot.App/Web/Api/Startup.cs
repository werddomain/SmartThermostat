// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityModel.AspNetCore.OAuth2Introspection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ST.Web.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Data.DeviceDataContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvcCore(options =>
            {
                options.RespectBrowserAcceptHeader = true; // false by default
            })
                .AddAuthorization()
                .AddApiExplorer()
                .AddJsonFormatters();

			services.AddCors();
            //https://github.com/RSuter/NSwag/wiki/AspNetCore-Middleware
            
            services.AddSwaggerDocument(c => {
                
            });
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Config.Urls.OAuthUrl;
                    options.RequireHttpsMetadata = Environment.IsDevelopment() ? false : true;


                    options.ApiName = Config.General.SmartHomeApiScope_Id;
                    options.TokenRetriever = new Func<HttpRequest, string>(req =>
                    {
                        var fromHeader = TokenRetrieval.FromAuthorizationHeader();
                        var fromQuery = TokenRetrieval.FromQueryString();
                        return fromHeader(req) ?? fromQuery(req);
                    });
                });
            services.AddSignalR();
            //sub claim is used from the token for individual users

            services.AddSingleton<IUserIdProvider, UserProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app)
        {
			app.UseCors(builder =>
			{
				builder.AllowAnyHeader();
				builder.AllowAnyMethod();
				builder.AllowAnyOrigin();
				builder.SetIsOriginAllowedToAllowWildcardSubdomains();

			});
            app.UseWebSockets();
            app.UseAuthentication();
            app.UseSwagger(c => {
                //c.Path = "/{documentName}/swagger.json";
            });
            
            app.UseSwaggerUi3(settings =>
            {
                //settings.EnableTryItOut = true;
                settings.ServerUrl = Config.Urls.ApiUrl;
                settings.TransformToExternalPath = (internalUiRoute, request) =>
                {
                    if (internalUiRoute.StartsWith("/") == true && internalUiRoute.StartsWith(request.PathBase) == false)
                    {
                        return request.PathBase + internalUiRoute;
                    }
                    else
                    {
                        return internalUiRoute;
                    }
                };
                //settings.SwaggerRoutes.Add(new NSwag.AspNetCore.SwaggerUi3Route("RootSwagger", "/"));
                // https://github.com/RSuter/NSwag/wiki/AspNetCore-Middleware#enable-oauth2-authorization
                //settings.OAuth2Client.
                //("/swagger/v1/swagger.json", "MyAPI V1");
            });

            app.UseMvc();
            app.UseSignalR(o =>
            {
                o.MapHub<signalR.SmartHub>("/SmartHub");
            });
        }
    }
}