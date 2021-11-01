﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AdvantageFramework.Core.Security.Database.Entities
{
    [Table("SEC_EMP")]
    public partial class UserEmployeeAccess
    {
        [Key]
        [Column("USER_ID")]
        [StringLength(100)]
        public string UserId { get; set; }
        [Key]
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
    }
}
