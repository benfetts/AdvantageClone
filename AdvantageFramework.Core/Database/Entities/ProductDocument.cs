
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("PRODUCT_DOCUMENTS")]
    public partial class ProductDocument
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
        [Column("DOCUMENT_ID")]
        public int DocumentId { get; set; }
        [Required]
        [Column("PRD_CODE")]
        [StringLength(6)]
        public string PrdCode { get; set; }
        [Column("CL_CODE")]
        [StringLength(6)]
        public string ClCode { get; set; }
        [Column("DIV_CODE")]
        [StringLength(6)]
        public string DivCode { get; set; }

        [ForeignKey(nameof(DocumentId))]
        [InverseProperty("ProductDocument")]
        public virtual Document Document { get; set; }
        [ForeignKey("ClCode,DivCode,PrdCode")]
        [InverseProperty("ProductDocuments")]
        public virtual Product Product { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}