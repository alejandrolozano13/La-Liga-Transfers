using Domain.Enums;

namespace Domain.Permissions
{
    public static class PermissionsRole
    {
        public static List<string> GetPermissionsForRole(UserRole role)
        {
            return role switch
            {
                UserRole.Admin => new()
                {
                    PermissionConstants.CreateTransfer,
                    PermissionConstants.DeleteTransfer,
                    PermissionConstants.SuggestTransfer
                },
                UserRole.ClubeStaff => new()
                {
                    PermissionConstants.CreateTransfer,
                    PermissionConstants.SuggestTransfer
                },
                UserRole.Agent => new()
                {
                    PermissionConstants.SuggestTransfer
                },
                _ => new List<string>()
            };
        }
    }
}