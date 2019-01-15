// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace ST.Web.OAuth
{
	//This file is used to seed the data. If you modify this file, you need to seed the data. IT's bether to change it in the BD.
	public class ConfigServerIdentity
	{
		//https://aaronparecki.com/oauth-2-simplified/#other-app-types

		// scopes define the resources in your system
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile()
			};
		}

		public static IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>
			{
				new ApiResource(Config.General.SmartHomeApiScope_Id, Config.General.SmartHomeApiScope_Name){
					Description = Config.General.SmartHomeApiScope_Description
				}
			};
		}

		// clients want to access resources (aka scopes)
		public static IEnumerable<Client> GetClients(IConfiguration Configuration)
		{
			// client credentials client
			return new List<Client>
			{

				new Client{
					ClientName = "Google",

					AllowedGrantTypes = GrantTypes.Code,
					ClientId = Configuration["Google:OurOpenId:ClientId"],
					ClientSecrets =
					{
						new Secret(Configuration["Google:OurOpenId:ClientSecret"].Sha256())
					},
					RedirectUris = { Config.Urls.GoogleRedirectUrl + Configuration["Google:GoogleProjectId"] },
					AbsoluteRefreshTokenLifetime = 0,
					AllowOfflineAccess = true,
					RequireConsent = true,
					AllowRememberConsent = true,
					AllowedScopes =
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						Config.General.SmartHomeApiScope_Id
					}
				},
				new Client{
					ClientName = "AngularPassword",
					AllowedGrantTypes = GrantTypes.Implicit,
					ClientId = Configuration["AngularConfig:AuthClientId"],
					AllowAccessTokensViaBrowser = true,
					RedirectUris = {
						"http://localhost:4200/index.html", //angular ng serv
						Config.Urls.UiUrl,
						$"{Config.Urls.UiUrl}/",
						$"{Config.Urls.UiUrl}/ng",
						$"{Config.Urls.UiUrl}/ng/",
						$"{Config.Urls.UiUrl}/ng/index.html"},

					AlwaysIncludeUserClaimsInIdToken = true,
					 AllowedScopes =
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						Config.General.SmartHomeApiScope_Id
					}
				},

				new Client
				{
					ClientId = "client",
					AllowedGrantTypes = GrantTypes.ClientCredentials,

					ClientSecrets =
					{
						new Secret("secret".Sha256())
					},
					AllowedScopes = {
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						Config.General.SmartHomeApiScope_Id }
				},

                // resource owner password grant client
                new Client
				{
					ClientId = "ro.client",
					AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

					ClientSecrets =
					{
						new Secret("secret".Sha256())
					},
					AllowedScopes = { Config.General.SmartHomeApiScope_Id }
				},

                // OpenID Connect hybrid flow and client credentials client (MVC)
                new Client
				{
					ClientId = "mvc",
					ClientName = "MVC Client",
					AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

					RequireConsent = true,

					ClientSecrets =
					{
						new Secret("secret".Sha256())
					},

					RedirectUris = { $"{Config.Urls.UiUrl}/signin-oidc" },
					PostLogoutRedirectUris = { $"{Config.Urls.UiUrl}/signout-callback-oidc" },

					AllowedScopes =
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						Config.General.SmartHomeApiScope_Id
					},
					AllowOfflineAccess = true
				}
			};
		}
	}
}