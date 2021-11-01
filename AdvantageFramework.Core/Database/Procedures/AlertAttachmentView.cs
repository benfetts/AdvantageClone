using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static partial class AlertAttachmentView
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

        public static System.Linq.IQueryable<Views.AlertAttachmentView> LoadByAlertID(Database.DbContext DbContext, int AlertID)
        {
            System.Linq.IQueryable<Views.AlertAttachmentView> LoadByAlertIDRet = default;
            LoadByAlertIDRet = from AlertAttachmentView in DbContext.AlertAttachmentViews.AsQueryable()
                               where AlertAttachmentView.AlertId == AlertID
                               select AlertAttachmentView;
            return LoadByAlertIDRet;
        }

        public static System.Linq.IQueryable<Views.AlertAttachmentView> Load(Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Views.AlertAttachmentView> LoadRet = default;
            LoadRet = from AlertAttachmentView in DbContext.AlertAttachmentViews.AsQueryable()
                      select AlertAttachmentView;
            return LoadRet;
        }

        #endregion
    }
}
