using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Form.Repository.Api.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using Form.Repository.Api.Entities;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (form)context.HttpContext.Items["form"];
        if (user == null)
        {
            // not logged in
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}