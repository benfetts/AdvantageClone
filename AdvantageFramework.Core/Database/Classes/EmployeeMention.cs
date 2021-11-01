using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Database.Classes
{
    public partial class EmployeeMention
    {

        #region  Constants 



        #endregion

        #region  Enum 

        public enum Properties
        {
            EmployeeCode,
            EmployeeName
        }

        #endregion

        #region  Variables 



        #endregion

        #region  Properties 

        public string EmployeeCode { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;        

        #endregion

        #region  Methods 

        

        #endregion

    }
}
