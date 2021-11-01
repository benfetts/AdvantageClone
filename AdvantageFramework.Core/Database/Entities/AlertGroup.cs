
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("ALERT_GROUP")]
    public partial class AlertGroup
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
        [Column("E_GROUP")]
        [StringLength(50)]
        public string EGroup { get; set; }
        [Key]
        [Column("ALERT_CAT_ID")]
        public int AlertCatId { get; set; }
        [Column("ACTIVE_FLAG")]
        public short? ActiveFlag { get; set; }

        [ForeignKey(nameof(AlertCatId))]
        [InverseProperty(nameof(AlertCategory.AlertGroups))]
        public virtual AlertCategory AlertCat { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}