using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdvantageFramework.Core.Database.Procedures
{
    public class ProofingExternal
    {
        public static Entities.ProofingExternal LoadByProofingExternalReviewerID(AdvantageFramework.Core.Database.DbContext DbContext, int ProofingExternalReviewerID)
        {
            AdvantageFramework.Core.Database.Entities.ProofingExternal rv;
            try
            {
                rv = (from ProofingExternal in DbContext.ProofingExternals.AsQueryable()
                      where ProofingExternal.Id == ProofingExternalReviewerID
                      select ProofingExternal).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return null;
            }
            return rv;
        }
    }
}
