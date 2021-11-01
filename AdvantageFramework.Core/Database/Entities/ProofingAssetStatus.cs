
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("PROOFING_ASSET_STATUS")]
    public partial class ProofingAssetStatus
    {
        #region Constants



        #endregion

        #region Enum

        public enum Properties
        {
            TBD
        }


        #endregion

        #region Variables



        #endregion

        #region Properties

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ALERT_ID")]
        public int? AlertId { get; set; }
        [Column("DOCUMENT_ID")]
        public int? DocumentId { get; set; }
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        [Column("STATUS_ID")]
        public short? StatusId { get; set; }
        [Column("CREATED_DATE", TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}