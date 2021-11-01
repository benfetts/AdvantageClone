﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AdvantageFramework.Core.Security.Database.Entities
{
    [Table("SERVICE_FEE_REPORT_COL")]
    public partial class ServiceFeeReconciliationReportColumn
    {
        [Key]
        [Column("SERVICE_FEE_REPORT_COL_ID")]
        public int ServiceFeeReportColId { get; set; }
        [Column("SERVICE_FEE_REPORT_ID")]
        public int ServiceFeeReportId { get; set; }
        [Required]
        [Column("FIELD_NAME")]
        [StringLength(50)]
        public string FieldName { get; set; }
        [Required]
        [Column("HEADER_TEXT")]
        [StringLength(50)]
        public string HeaderText { get; set; }
        [Column("IS_VISIBLE")]
        public bool IsVisible { get; set; }
        [Column("SORT_ORDER")]
        public int SortOrder { get; set; }
        [Column("SORT_INDEX")]
        public int SortIndex { get; set; }
        [Column("GROUP_INDEX")]
        public int GroupIndex { get; set; }
        [Column("WIDTH")]
        public int Width { get; set; }
        [Column("VISIBLE_INDEX")]
        public int VisibleIndex { get; set; }
        [Column("GRIDVIEW_ID")]
        public int GridviewId { get; set; }

        [ForeignKey(nameof(ServiceFeeReportId))]
        [InverseProperty("ServiceFeeReportCols")]
        public virtual ServiceFeeReconciliationReport ServiceFeeReport { get; set; }
    }
}
