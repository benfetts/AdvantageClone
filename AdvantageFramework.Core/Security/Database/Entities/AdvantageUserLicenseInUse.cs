﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AdvantageFramework.Core.Security.Database.Entities
{
    [Table("AULU")]
    public partial class AdvantageUserLicenseInUse
    {
        [Key]
        [Column("AULU_ID")]
        public int AuluId { get; set; }
        [Column("AULU_TYPE")]
        public byte AuluType { get; set; }
        [Required]
        [Column("AULU_ASSIGN")]
        public string AuluAssign { get; set; }
    }
}
