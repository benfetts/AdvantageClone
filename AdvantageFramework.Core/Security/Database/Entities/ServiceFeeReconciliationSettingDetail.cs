﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AdvantageFramework.Core.Security.Database.Entities
{
    [Table("SERVICE_FEE_DEF_DTL")]
    public partial class ServiceFeeReconciliationSettingDetail
    {
        [Key]
        [Column("USER_ID")]
        [StringLength(100)]
        public string UserId { get; set; }
        [Key]
        [Column("DTL_TYPE")]
        [StringLength(20)]
        public string DtlType { get; set; }
        [Key]
        [Column("DTL_CODE")]
        [StringLength(6)]
        public string DtlCode { get; set; }
    }
}
