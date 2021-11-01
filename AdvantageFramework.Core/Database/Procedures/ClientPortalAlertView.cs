using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static partial class ClientPortalAlertView
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

        public static System.Linq.IQueryable<Database.Views.ClientPortalAlertView> Load(Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Database.Views.ClientPortalAlertView> LoadRet = default;
            LoadRet = from ClientPortalAlertView in DbContext.ClientPortalAlertView.AsQueryable()
                      select ClientPortalAlertView;
            return LoadRet;
        }

        #endregion
    }
}
