using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Database.Classes
{
    public partial class AlertEmailRecipient
    {

        #region  Constants 



        #endregion

        #region  Enum 

        public enum Properties
        {
            RecipientAlertID,
            RecipientID,
            RecipientEmployeeCode,
            RecipientEmailAddress,
            RecipientEmployeeName,
            EmployeeCode,
            EmployeeEmail,
            MailBeeTitle,
            IsAssignee,
            IsCC,
            IsClientPortal,
            IsCurrentRecipient,
            SendEmail,
            IsTaskEmployee
        }

        #endregion

        #region  Variables 



        #endregion

        #region  Properties 

        public int RecipientAlertID { get; set; } = 0;
        public int RecipientID { get; set; } = 0;
        public string RecipientEmployeeCode { get; set; } = string.Empty;
        public string RecipientEmailAddress { get; set; } = string.Empty;
        public string RecipientEmployeeName { get; set; } = string.Empty;
        public string EmployeeCode { get; set; } = string.Empty;
        public string EmployeeEmail { get; set; } = string.Empty;
        public string MailBeeTitle { get; set; } = string.Empty;
        public bool IsAssignee { get; set; } = false;
        public bool IsCC { get; set; } = false;
        public bool IsClientPortal { get; set; } = false;
        public bool IsCurrentRecipient { get; set; } = false;
        public bool SendEmail { get; set; } = false;
        public bool IsTaskEmployee { get; set; } = false;

        #endregion

        #region  Methods 

        public override string ToString()
        {
            string ToStringRet = default;
            ToStringRet = RecipientAlertID.ToString();
            return ToStringRet;
        }

        #endregion

    }
}
