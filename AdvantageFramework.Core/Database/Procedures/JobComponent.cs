using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdvantageFramework.Core.Database.Procedures
{
    public class JobComponent
    {
        public static Entities.JobComponent LoadByJobNumberAndJobComponentNumber(AdvantageFramework.Core.Database.DbContext DbContext, int JobNumber, short JobComponentNumber)
        {
            AdvantageFramework.Core.Database.Entities.JobComponent rv;
            try
            {
                rv = (from JobComponent in DbContext.JobComponents.AsQueryable()
                      where JobComponent.JobNumber == JobNumber && JobComponent.JobComponentNbr == JobComponentNumber
                      select JobComponent).SingleOrDefault();
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
