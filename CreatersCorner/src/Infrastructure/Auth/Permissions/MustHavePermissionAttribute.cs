using CreatersCorner.WebApi.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace CreatersCorner.WebApi.Infrastructure.Auth.Permissions;

public class MustHavePermissionAttribute : AuthorizeAttribute
{
    public MustHavePermissionAttribute(string action, string resource) =>
        Policy = FSHPermission.NameFor(action, resource);
}