
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    public class AlertRecipientLookup
    {
        #region Enum
        public enum Properties
        {
            Code,
            FullName,
            IsEmployee,
            IsClientContact,
            InAlertGroup,
            ConceptShareUserID,
            IsConceptShareUser,
            Picture               
        }

        #endregion

        #region Variables



        #endregion

        #region Properties

        public string Code { get; set; }
        public string FullName { get; set; }
        public bool? IsEmployee { get; set; }
        public bool? IsClientContact { get; set; }
        public bool? InAlertGroup { get; set; }
        public int? ConceptShareUserID { get; set; }
        public bool? IsConceptShareUser { get; set; }
        public byte[] Picture { get; set; }
        

        #endregion
    }
}
