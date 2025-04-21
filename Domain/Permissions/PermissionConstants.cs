namespace Domain.Permissions
{
    public static class PermissionConstants
    {
        #region management transfers permissions

        public const string CreateTransfer = "transfer:create";
        public const string DeleteTransfer = "transfer:delete";
        public const string SuggestTransfer = "transfer:suggest";

        #endregion

        #region management clubs permissions

        public const string ManageClubs = "manage:clubs";

        #endregion

        #region management players permissions

        public const string ManagePlayers = "manage:players";

        #endregion
    }
}