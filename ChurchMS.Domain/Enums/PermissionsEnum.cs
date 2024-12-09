namespace ChurchMS.Domain.Enums;

public enum PermissionsEnum
{
    FullAccess = 1,
    #region City Permissions
    CreateCity,
    GetCity,
    UpdateCity,
    DeleteCity,
    #endregion
    #region District Permissions
    CreateDistrict,
    GetDistrict,
    UpdateDistrict,
    DeleteDistrict,
    #endregion
    #region Street Permissions
    CreateStreet,
    GetStreet,
    UpdateStreet,
    DeleteStreet,
    #endregion
}