using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("AGY_SETTINGS")]
    public partial class Setting
    {
        [Key]
        [Column("AGY_SETTINGS_CODE")]
        [StringLength(20)]
        public string AgySettingsCode { get; set; }
        [Required]
        [Column("AGY_SETTINGS_DESC")]
        [StringLength(100)]
        public string AgySettingsDesc { get; set; }
        [Column("AGY_SETTINGS_VALUE", TypeName = "sql_variant")]
        public object Value { get; set; }
        [Column("AGY_SETTINGS_DEF", TypeName = "sql_variant")]
        public object AgySettingsDef { get; set; }
        [Column("AGY_SETTINGS_MIN")]
        public int? AgySettingsMin { get; set; }
        [Column("AGY_SETTINGS_MAX")]
        public int? AgySettingsMax { get; set; }
        [Column("AGY_SETTINGS_APP")]
        public short? AgySettingsApp { get; set; }
        [Column("AGY_SETTINGS_TAB")]
        public short? AgySettingsTab { get; set; }
        [Column("AGY_SETTINGS_GRP")]
        public short? AgySettingsGrp { get; set; }
        [Column("AGY_SETTINGS_ORDER")]
        public int? AgySettingsOrder { get; set; }
        [Column("DTYPE_ID")]
        public int? DtypeId { get; set; }
        [Column("INACTIVE_FLAG")]
        public short? InactiveFlag { get; set; }
    }
}
