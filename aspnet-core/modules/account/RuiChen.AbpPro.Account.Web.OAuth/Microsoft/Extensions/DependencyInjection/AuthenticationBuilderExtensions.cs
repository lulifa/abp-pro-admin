﻿using JetBrains.Annotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RuiChen.AbpPro.Account.Web.OAuth.ExternalProviders;
using Volo.Abp;

namespace RuiChen.AbpPro.Account.Web.OAuth.Microsoft.Extensions.DependencyInjection;

public static class AuthenticationBuilderExtensions
{
    public static AuthenticationBuilder UseSettingProvider<TOptions, THandler, TOptionsProvider>(
        [NotNull] this AuthenticationBuilder authenticationBuilder)
        where TOptions : RemoteAuthenticationOptions, new()
        where THandler : RemoteAuthenticationHandler<TOptions>
        where TOptionsProvider : IOAuthHandlerOptionsProvider<TOptions>
    {
        Check.NotNull(authenticationBuilder, nameof(authenticationBuilder));

        var handler = authenticationBuilder.Services.LastOrDefault(x => x.ServiceType == typeof(THandler));
        authenticationBuilder.Services.Replace(new ServiceDescriptor(
            typeof(THandler),
            provider => new AccountAuthenticationRequestHandler<TOptions, THandler>(
                (THandler)ActivatorUtilities.CreateInstance(provider, typeof(THandler)),
                provider.GetRequiredService<TOptionsProvider>()),
            handler?.Lifetime ?? ServiceLifetime.Transient));

        return authenticationBuilder;
    }
}
