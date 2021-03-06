// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AdvantageFramework.Core.Security.Database.Entities
{
    [Table("SEC_MODULE")]
    [Index(nameof(SecModuleCode), nameof(Description), nameof(IsCategory), nameof(SecModuleInfoId), Name = "IDX_SEC_MODULE_SEC_MODULE_CODE")]
    [Index(nameof(SecModuleCode), Name = "UQ__SEC_MODU__E7AE988E4923D2BA", IsUnique = true)]
    public partial class Module
    {
        public Module()
        {
            SecApplicationMods = new HashSet<ApplicationModule>();
            SecCpuserModaccesses = new HashSet<ClientPortalUserModuleAccess>();
            SecGroupModaccesses = new HashSet<GroupModuleAccess>();
            SecModuleSubParentModules = new HashSet<ModuleSub>();
            SecModuleSubSecModules = new HashSet<ModuleSub>();
            SecUserModaccesses = new HashSet<UserModuleAccess>();
        }

        [Key]
        [Column("SEC_MODULE_ID")]
        public int SecModuleId { get; set; }
        [Required]
        [Column("SEC_MODULE_CODE")]
        [StringLength(100)]
        public string SecModuleCode { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(100)]
        public string Description { get; set; }
        [Column("IS_INACTIVE")]
        public bool IsInactive { get; set; }
        [Column("IS_MENU_ITEM")]
        public bool IsMenuItem { get; set; }
        [Column("IS_CATEGORY")]
        public bool IsCategory { get; set; }
        [Column("IS_APPLICATION")]
        public bool IsApplication { get; set; }
        [Column("IS_REPORT")]
        public bool IsReport { get; set; }
        [Column("IS_DESKTOP_OBJECT")]
        public bool IsDesktopObject { get; set; }
        [Column("IS_DASH_QUERY")]
        public bool IsDashQuery { get; set; }
        [Column("SEC_MODULE_INFO_ID")]
        public int SecModuleInfoId { get; set; }

        [ForeignKey(nameof(SecModuleInfoId))]
        [InverseProperty("SecModules")]
        public virtual ModuleInformation SecModuleInfo { get; set; }
        [InverseProperty(nameof(ApplicationModule.SecModule))]
        public virtual ICollection<ApplicationModule> SecApplicationMods { get; set; }
        [InverseProperty(nameof(ClientPortalUserModuleAccess.SecModule))]
        public virtual ICollection<ClientPortalUserModuleAccess> SecCpuserModaccesses { get; set; }
        [InverseProperty(nameof(GroupModuleAccess.SecModule))]
        public virtual ICollection<GroupModuleAccess> SecGroupModaccesses { get; set; }
        [InverseProperty(nameof(ModuleSub.ParentModule))]
        public virtual ICollection<ModuleSub> SecModuleSubParentModules { get; set; }
        [InverseProperty(nameof(ModuleSub.SecModule))]
        public virtual ICollection<ModuleSub> SecModuleSubSecModules { get; set; }
        [InverseProperty(nameof(UserModuleAccess.SecModule))]
        public virtual ICollection<UserModuleAccess> SecUserModaccesses { get; set; }
    }
}
