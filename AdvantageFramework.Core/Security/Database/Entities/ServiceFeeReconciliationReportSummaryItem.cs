﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AdvantageFramework.Core.Security.Database.Entities
{
    [Table("SERVICE_FEE_REPORT_SUM")]
    public partial class ServiceFeeReconciliationReportSummaryItem
    {
        [Key]
        [Column("SERVICE_FEE_REPORT_SUM_ID")]
        public int ServiceFeeReportSumId { get; set; }
        [Column("SERVICE_FEE_REPORT_ID")]
        public int ServiceFeeReportId { get; set; }
        [Column("SUM_TYPE")]
        public int SumType { get; set; }
        [Required]
        [Column("FIELD_NAME")]
        [StringLength(100)]
        public string FieldName { get; set; }
        [Required]
        [Column("COLUMN_NAME")]
        [StringLength(100)]
        public string ColumnName { get; set; }
        [Required]
        [Column("DISPLAY_FORMAT")]
        [StringLength(1000)]
        public string DisplayFormat { get; set; }
        [Column("ON_FOOTER")]
        public bool OnFooter { get; set; }
        [Column("GRIDVIEW_ID")]
        public int GridviewId { get; set; }

        [ForeignKey(nameof(ServiceFeeReportId))]
        [InverseProperty("ServiceFeeReportSums")]
        public virtual ServiceFeeReconciliationReport ServiceFeeReport { get; set; }
    }
}
