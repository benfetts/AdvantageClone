// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AdvantageFramework.Core.Security.Database.Entities
{
    [Table("SEC_GROUP")]
    [Index(nameof(Name), Name = "UQ__SEC_GROU__D9C1FA003CBDFBD5", IsUnique = true)]
    public partial class Group
    {
        public Group()
        {
            SecGroupAppaccesses = new HashSet<GroupApplicationAccess>();
            SecGroupModaccesses = new HashSet<GroupModuleAccess>();
            SecGroupSettings = new HashSet<GroupSetting>();
            SecGroupUdraccesses = new HashSet<GroupUserDefinedReportAccess>();
            SecGroupUsers = new HashSet<GroupUser>();
        }

        [Key]
        [Column("SEC_GROUP_ID")]
        public int SecGroupId { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(100)]
        public string Description { get; set; }

        [InverseProperty(nameof(GroupApplicationAccess.SecGroup))]
        public virtual ICollection<GroupApplicationAccess> SecGroupAppaccesses { get; set; }
        [InverseProperty(nameof(GroupModuleAccess.SecGroup))]
        public virtual ICollection<GroupModuleAccess> SecGroupModaccesses { get; set; }
        [InverseProperty(nameof(GroupSetting.SecGroup))]
        public virtual ICollection<GroupSetting> SecGroupSettings { get; set; }
        [InverseProperty(nameof(GroupUserDefinedReportAccess.SecGroup))]
        public virtual ICollection<GroupUserDefinedReportAccess> SecGroupUdraccesses { get; set; }
        [InverseProperty(nameof(GroupUser.SecGroup))]
        public virtual ICollection<GroupUser> SecGroupUsers { get; set; }
    }
}
