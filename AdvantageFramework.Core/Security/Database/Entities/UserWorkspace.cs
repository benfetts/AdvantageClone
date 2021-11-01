﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AdvantageFramework.Core.Security.Database.Entities
{
    [Table("WV_USER_WORKSPACE")]
    public partial class UserWorkspace
    {
        public UserWorkspace()
        {
            WvWorkspaceObjects = new HashSet<WorkspaceObject>();
        }

        [Key]
        [Column("WORKSPACE_ID")]
        public int WorkspaceId { get; set; }
        [Required]
        [Column("USER_CODE")]
        [StringLength(100)]
        public string UserCode { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(100)]
        public string Description { get; set; }
        [Column("SORT_ORDER")]
        public int? SortOrder { get; set; }
        [Column("CP")]
        public int? Cp { get; set; }

        public virtual User UserCodeNavigation { get; set; }
        [InverseProperty(nameof(WorkspaceObject.Workspace))]
        public virtual ICollection<WorkspaceObject> WvWorkspaceObjects { get; set; }
    }
}
