using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdvantageFramework.Core.Security.Database.Procedures
{
    public static partial class ClientContact
    {
        #region Constants

        #endregion

        #region Enums

        #endregion

        #region Variables

        #endregion

        #region Properties

        #endregion

        #region Methods
        public static IQueryable<AdvantageFramework.Core.Security.Database.Entities.ClientContact> LoadAllAvailableByClientCode(Security.Database.DbContext DbContext, string ClientCode)
        {
            IQueryable<AdvantageFramework.Core.Security.Database.Entities.ClientContact> LoadAllAvailableByClientCodeRet = default;
            LoadAllAvailableByClientCodeRet = from ClientContact in DbContext.ClientContact.AsQueryable()
                                              where ClientContact.ClCode == ClientCode && ClientContact.CpUser == 1 && (ClientContact.InactiveFlag == null || ClientContact.InactiveFlag == 0) && ClientContact.CpUsers.Count == 0
                                              select ClientContact;
            return LoadAllAvailableByClientCodeRet;
        }

        public static IQueryable<AdvantageFramework.Core.Security.Database.Entities.ClientContact> LoadByClientCode(Security.Database.DbContext DbContext, string ClientCode)
        {
            IQueryable<AdvantageFramework.Core.Security.Database.Entities.ClientContact> LoadByClientCodeRet = default;
            LoadByClientCodeRet = from ClientContact in DbContext.ClientContact.AsQueryable()
                                  where ClientContact.ClCode == ClientCode
                                  select ClientContact;
            return LoadByClientCodeRet;
        }

        public static AdvantageFramework.Core.Security.Database.Entities.ClientContact LoadByClientContactID(Database.DbContext DbContext, int ClientContactID)
        {
            AdvantageFramework.Core.Security.Database.Entities.ClientContact LoadByClientContactIDRet = default;
            try
            {
                LoadByClientContactIDRet = (from ClientContact in DbContext.ClientContact.AsQueryable()
                                            where ClientContact.CdpContactId == ClientContactID
                                            select ClientContact).SingleOrDefault();
            }
            catch (Exception ex)
            {
                LoadByClientContactIDRet = default;
            }

            return LoadByClientContactIDRet;
        }

        public static IQueryable<AdvantageFramework.Core.Security.Database.Entities.ClientContact> LoadAllActive(Database.DbContext DbContext)
        {
            IQueryable<AdvantageFramework.Core.Security.Database.Entities.ClientContact> LoadAllActiveRet = default;
            LoadAllActiveRet = from ClientContact in DbContext.ClientContact.AsQueryable()
                               where ClientContact.InactiveFlag == null || ClientContact.InactiveFlag == 0
                               select ClientContact;
            return LoadAllActiveRet;
        }

        public static IQueryable<AdvantageFramework.Core.Security.Database.Entities.ClientContact> Load(Database.DbContext DbContext)
        {
            IQueryable<AdvantageFramework.Core.Security.Database.Entities.ClientContact> LoadRet = default;
            LoadRet = from ClientContact in DbContext.ClientContact.AsQueryable()
                      select ClientContact;
            return LoadRet;
        }

        #endregion
    }
}
