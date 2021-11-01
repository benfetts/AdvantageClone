
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("ALERT_TYPE")]
    public partial class AlertType
    {
        public AlertType()
        {
            AlertCategories = new HashSet<AlertCategory>();
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
        [Column("ALERT_TYPE_ID")]
        public int AlertTypeId { get; set; }
        [Required]
        [Column("ALERT_TYPE_DESC")]
        [StringLength(40)]
        public string AlertTypeDesc { get; set; }

        [InverseProperty(nameof(AlertCategory.AlertType))]
        public virtual ICollection<AlertCategory> AlertCategories { get; set; }
        [InverseProperty(nameof(Alert.AlertType))]
        public virtual ICollection<Alert> Alerts { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}