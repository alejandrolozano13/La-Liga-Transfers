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
                    PermissionConstants.SuggestTransfer,
                    PermissionConstants.ManageClubs,
                    PermissionConstants.ManagePlayers
                },
                UserRole.ClubeStaff => new()
                {
                    PermissionConstants.CreateTransfer,
                    PermissionConstants.SuggestTransfer,
                    PermissionConstants.ManagePlayers
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