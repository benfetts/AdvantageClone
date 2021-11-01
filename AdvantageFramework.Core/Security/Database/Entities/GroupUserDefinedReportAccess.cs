﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AdvantageFramework.Core.Security.Database.Entities
{
    [Table("SEC_GROUP_UDRACCESS")]
    public partial class GroupUserDefinedReportAccess
    {
        [Key]
        [Column("SEC_GROUP_UDRACCESS_ID")]
        public int SecGroupUdraccessId { get; set; }
        [Column("SEC_GROUP_ID")]
        public int SecGroupId { get; set; }
        [Column("USER_DEF_REPORT_ID")]
        public int UserDefReportId { get; set; }
        [Column("IS_BLOCKED")]
        public bool IsBlocked { get; set; }

        [ForeignKey(nameof(SecGroupId))]
        [InverseProperty("SecGroupUdraccesses")]
        public virtual Group SecGroup { get; set; }
    }
}
