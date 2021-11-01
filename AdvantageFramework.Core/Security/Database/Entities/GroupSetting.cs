﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AdvantageFramework.Core.Security.Database.Entities
{
    [Table("SEC_GROUP_SETTING")]
    public partial class GroupSetting
    {
        [Column("SEC_GROUP_SETTING_ID")]
        public int SecGroupSettingId { get; set; }
        [Key]
        [Column("SEC_GROUP_ID")]
        public int SecGroupId { get; set; }
        [Key]
        [Column("SETTING_CODE")]
        [StringLength(100)]
        public string SettingCode { get; set; }
        [Column("STRING_VALUE")]
        [StringLength(8000)]
        public string StringValue { get; set; }
        [Column("NUMERIC_VALUE", TypeName = "decimal(9, 4)")]
        public decimal? NumericValue { get; set; }
        [Column("DATE_VALUE", TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        [ForeignKey(nameof(SecGroupId))]
        [InverseProperty("SecGroupSettings")]
        public virtual Group SecGroup { get; set; }
    }
}
