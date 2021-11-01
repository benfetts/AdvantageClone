using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Database
{
    public partial class ConnectionDatabaseProfile //: AdvantageFramework.Core.BaseClasses.BaseClass
    {

        #region  Constants 



        #endregion

        #region  Enum 

        public enum Properties
        {
            ServerName,
            DatabaseName,
            UserName,
            Password
        }

        #endregion

        #region  Variables 

        private string _DecryptedPassword = string.Empty;

        #endregion

        #region  Properties 

        //[System.Xml.Serialization.XmlIgnore()]
        //[AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid = false)]
        //public Guid GUID { get; set; }
        //[AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired = true, DisplayFormat = "")]
        //public string ServerName { get; set; }
        //[AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired = true, DisplayFormat = "")]
        //public string DatabaseName { get; set; }
        //[AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired = true, DisplayFormat = "")]
        //public string UserName { get; set; }
        //[AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired = true, DisplayFormat = "")]
        //public string Password { get; set; }

        #endregion

        #region  Methods 

        //public ConnectionDatabaseProfile()
        //{
        //    GUID = Guid.NewGuid();
        //}

        //public ConnectionDatabaseProfile Copy()
        //{
        //    ConnectionDatabaseProfile CopyRet = default;

        //    // objects
        //    ConnectionDatabaseProfile ConnectionDatabaseProfile = null;
        //    ConnectionDatabaseProfile = new ConnectionDatabaseProfile();
        //    ConnectionDatabaseProfile.ServerName = ServerName;
        //    ConnectionDatabaseProfile.DatabaseName = DatabaseName;
        //    ConnectionDatabaseProfile.UserName = UserName;
        //    ConnectionDatabaseProfile.Password = Password;
        //    CopyRet = ConnectionDatabaseProfile;
        //    return CopyRet;
        //}

        //public string GetDecryptPassword()
        //{
        //    string GetDecryptPasswordRet = default;
        //    string DecryptedPassword = string.Empty;
        //    try
        //    {
        //        DecryptedPassword = AdvantageFramework.Core.Security.Encryption.Decrypt(Password);
        //    }
        //    catch (Exception ex)
        //    {
        //        DecryptedPassword = string.Empty;
        //    }

        //    GetDecryptPasswordRet = DecryptedPassword;
        //    return GetDecryptPasswordRet;
        //}

        //public string GetConnectionString(AdvantageFramework.Core.Security.Application Application)
        //{
        //    string GetConnectionStringRet = default;
        //    string ConnectionString = string.Empty;
        //    ConnectionString = AdvantageFramework.Core.Database.CreateConnectionString(ServerName, DatabaseName, false, UserName, GetDecryptPassword(), Application.ToString);
        //    GetConnectionStringRet = ConnectionString;
        //    return GetConnectionStringRet;
        //}

        //public override string ToString()
        //{
        //    string ToStringRet = default;
        //    ToStringRet = AdvantageFramework.Core.StringUtilities.Methods.AppendTrailingCharacter(ServerName, @"\") + DatabaseName;
        //    return ToStringRet;
        //}

        //public void SetError(string ErrorText)
        //{
        //    string FullErrorText = string.Empty;
        //    FullErrorText = _EntityError;
        //    if (string.IsNullOrWhiteSpace(ErrorText))
        //    {

        //        // _ErrorHashtable("ServerName") = String.Empty
        //        _ErrorHashtable("DatabaseName") = string.Empty;
        //    }
        //    else
        //    {

        //        // _ErrorHashtable("ServerName") = ErrorText
        //        _ErrorHashtable("DatabaseName") = ErrorText;
        //    }

        //    _EntityError = Interaction.IIf(string.IsNullOrEmpty(FullErrorText), ErrorText, FullErrorText + Environment.NewLine + ErrorText);
        //}

        #endregion

    }
}
