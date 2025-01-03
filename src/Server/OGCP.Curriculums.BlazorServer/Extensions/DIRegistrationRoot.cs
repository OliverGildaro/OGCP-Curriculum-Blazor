﻿using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using OGCP.Curriculums.Shared.Extensions;

namespace OGCP.Curriculums.BlazorServer.Extensions;
public static class DIRegistrationRoot
{
    public static void AddServicesToContainer(this IServiceCollection services)
    {
        services.AddServices();
    }
}
