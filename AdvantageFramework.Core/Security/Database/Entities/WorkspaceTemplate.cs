// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AdvantageFramework.Core.Security.Database.Entities
{
    [Table("WV_WORKSPACE_TMPLT_HDR")]
    public partial class WorkspaceTemplate
    {
        public WorkspaceTemplate()
        {
            WvWorkspaceTmpltDtls = new HashSet<WorkspaceTemplateDetail>();
        }

        [Key]
        [Column("TEMPLATE_ID")]
        public int TemplateId { get; set; }
        [Column("CREATED_BY_ID")]
        public int CreatedById { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(100)]
        public string Description { get; set; }
        [Column("CREATE_DATE", TypeName = "smalldatetime")]
        public DateTime? CreateDate { get; set; }
        [Column("CP")]
        public int? Cp { get; set; }

        [InverseProperty(nameof(WorkspaceTemplateDetail.Template))]
        public virtual ICollection<WorkspaceTemplateDetail> WvWorkspaceTmpltDtls { get; set; }
    }
}
