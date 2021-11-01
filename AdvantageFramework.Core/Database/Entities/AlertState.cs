
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("ALERT_STATES")]
    public partial class AlertState
    {
        public AlertState()
        {
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
        [Column("ALERT_STATE_ID")]
        public int AlertStateId { get; set; }
        [Required]
        [Column("ALERT_STATE_NAME")]
        [StringLength(100)]
        public string AlertStateName { get; set; }
        [Column("SORT_ORDER")]
        public int? SortOrder { get; set; }
        [Column("ACTIVE_FLAG")]
        public bool? ActiveFlag { get; set; }
        [Column("DFLT_ALERT_CAT_ID")]
        public int? DfltAlertCatId { get; set; }

        [ForeignKey(nameof(DfltAlertCatId))]
        [InverseProperty(nameof(AlertCategory.AlertStates))]
        public virtual AlertCategory DfltAlertCat { get; set; }
        [InverseProperty(nameof(Alert.AlertState))]
        public virtual ICollection<Alert> Alerts { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}