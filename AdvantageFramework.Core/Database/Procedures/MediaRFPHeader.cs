using System.Linq;

namespace AdvantageFramework.Core.Database.Procedures
{
    public static partial class MediaRFPHeader
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

        public static Database.Entities.MediaRFPHeader LoadByID(Database.DbContext DbContext, int ID)
        {
            Database.Entities.MediaRFPHeader LoadByIDRet = default;
            if ((from MediaRFPHeader in DbContext.MediaRfpHeaders.AsQueryable()
                 where MediaRFPHeader.MediaRfpHeaderId == ID
                 select MediaRFPHeader).Count() == 1)
            {
                LoadByIDRet = (from MediaRFPHeader in DbContext.MediaRfpHeaders.AsQueryable()
                               where MediaRFPHeader.MediaRfpHeaderId == ID
                               select MediaRFPHeader).Single();
            }
            else
            {
                LoadByIDRet = default;
            }

            return LoadByIDRet;
        }

        public static System.Linq.IQueryable<Entities.MediaRFPHeader> LoadByMediaBroadcastWorksheetMarketID(Database.DbContext DbContext, int MediaBroadcastWorksheetMarketID)
        {
            System.Linq.IQueryable<Entities.MediaRFPHeader> LoadByMediaBroadcastWorksheetMarketIDRet = default;
            LoadByMediaBroadcastWorksheetMarketIDRet = from MediaRFPHeader in DbContext.MediaRfpHeaders.AsQueryable()
                                                       where MediaRFPHeader.MediaBroadcastWorksheetMarketId == MediaBroadcastWorksheetMarketID
                                                       select MediaRFPHeader;
            return LoadByMediaBroadcastWorksheetMarketIDRet;
        }

        public static System.Linq.IQueryable<Entities.MediaRFPHeader> Load(Database.DbContext DbContext)
        {
            System.Linq.IQueryable<Entities.MediaRFPHeader> LoadRet = default;
            LoadRet = from MediaRFPHeader in DbContext.MediaRfpHeaders.AsQueryable()
                      select MediaRFPHeader;
            return LoadRet;
        }

        #endregion
    }
}
