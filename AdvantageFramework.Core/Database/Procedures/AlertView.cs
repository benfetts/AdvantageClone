using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    class AlertView
    {

        #region  Constants 



        #endregion

        #region  Enum 



        #endregion

        #region  Variables 



        #endregion

        #region  Properties 



        #endregion

        #region  Methods 

        public static System.Linq.IQueryable<Database.Views.AlertView> Load(Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Database.Views.AlertView> LoadRet = default;
            LoadRet = from AlertView in DbContext.AlertViews.AsQueryable()
                      select AlertView;
            return LoadRet;
        }

        #endregion

    }
}
