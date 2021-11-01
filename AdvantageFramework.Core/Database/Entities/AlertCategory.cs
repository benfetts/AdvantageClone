
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("ALERT_CATEGORY")]
    public partial class AlertCategory
    {
        public AlertCategory()
        {
            AlertGroups = new HashSet<AlertGroup>();
            AlertStates = new HashSet<AlertState>();
            Alerts = new HashSet<Alert>();
        }

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
        [Column("ALERT_CAT_ID")]
        public int AlertCatId { get; set; }
        [Column("ALERT_TYPE_ID")]
        public int AlertTypeId { get; set; }
        [Required]
        [Column("ALERT_DESC")]
        [StringLength(40)]
        public string AlertDesc { get; set; }
        [Column("PROMPT")]
        public short? Prompt { get; set; }
        [Column("GROUP_LVL_SECURITY")]
        public short? GroupLvlSecurity { get; set; }
        [Column("PDF_ATTACHMENT")]
        public short? PdfAttachment { get; set; }
        [Column("IS_USER_DEFINED")]
        public bool? IsUserDefined { get; set; }
        [Column("IS_INACTIVE")]
        public bool? IsInactive { get; set; }
        [Column("COLOR_CODE")]
        [StringLength(25)]
        public string ColorCode { get; set; }
        [Column("BOARD_TMPLT_COL_ID")]
        public int? BoardTmpltColId { get; set; }
        [Column("PARENT_CAT_ID")]
        public int? ParentCatId { get; set; }

        [ForeignKey(nameof(AlertTypeId))]
        [InverseProperty("AlertCategories")]
        public virtual AlertType AlertType { get; set; }
        [InverseProperty(nameof(AlertGroup.AlertCat))]
        public virtual ICollection<AlertGroup> AlertGroups { get; set; }
        [InverseProperty(nameof(AlertState.DfltAlertCat))]
        public virtual ICollection<AlertState> AlertStates { get; set; }
        [InverseProperty(nameof(Alert.AlertCat))]
        public virtual ICollection<Alert> Alerts { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}