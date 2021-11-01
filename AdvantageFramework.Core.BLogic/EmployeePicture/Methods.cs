using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.BLogic.EmployeePicture
{
    public class Methods
    {
        #region Constants



        #endregion

        #region Enum



        #endregion

        #region Variables



        #endregion

        #region  Properties



        #endregion
        #region Methods

        public static Database.Entities.EmployeePicture LoadByEmployeeCode(AdvantageFramework.Core.Web.QueryString queryString, string EmployeeCode)
        {
            if (string.IsNullOrWhiteSpace(queryString.ConnectionString) == false)
            {
                using (var DbContext = new AdvantageFramework.Core.Database.DbContext(queryString.ConnectionString))
                {
                    return AdvantageFramework.Core.Database.Procedures.EmployeePicture.LoadByEmployeeCode(DbContext, EmployeeCode);
                }
            }

            return null;

        }

        #endregion
    }
}
