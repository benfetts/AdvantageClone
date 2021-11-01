﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("OFFICE")]
    public partial class Office
    {
        public Office()
        {
            JobLogs = new HashSet<Job>();
            Products = new HashSet<Product>();
        }

        #region Constants



        #endregion

        #region Enum

        public enum Properties
        {
            TBD
        }


        #endregion

        #region Variables



        #endregion

        #region Properties

        [Key]
        [Column("OFFICE_CODE")]
        [StringLength(4)]
        public string OfficeCode { get; set; }
        [Column("OFFICE_NAME")]
        [StringLength(30)]
        public string OfficeName { get; set; }
        [Column("GLACODE_AR")]
        [StringLength(30)]
        public string GlacodeAr { get; set; }
        [Column("GLACODE_AP")]
        [StringLength(30)]
        public string GlacodeAp { get; set; }
        [Column("GLACODE_AP_DISC")]
        [StringLength(30)]
        public string GlacodeApDisc { get; set; }
        [Column("PGLACODE_SALES")]
        [StringLength(30)]
        public string PglacodeSales { get; set; }
        [Column("PGLACODE_COS")]
        [StringLength(30)]
        public string PglacodeCos { get; set; }
        [Column("PGLACODE_WIP")]
        [StringLength(30)]
        public string PglacodeWip { get; set; }
        [Column("PGLACODE_DEF_SALES")]
        [StringLength(30)]
        public string PglacodeDefSales { get; set; }
        [Column("PGLACODE_DEF_COS")]
        [StringLength(30)]
        public string PglacodeDefCos { get; set; }
        [Column("PGLACODE_ACC_COS")]
        [StringLength(30)]
        public string PglacodeAccCos { get; set; }
        [Column("PGLACODE_ACC_AP")]
        [StringLength(30)]
        public string PglacodeAccAp { get; set; }
        [Column("PGLACODE_ACC_TAX")]
        [StringLength(30)]
        public string PglacodeAccTax { get; set; }
        [Column("MGLACODE_ACC_AP")]
        [StringLength(30)]
        public string MglacodeAccAp { get; set; }
        [Column("MGLACODE_ACC_COS")]
        [StringLength(30)]
        public string MglacodeAccCos { get; set; }
        [Column("MGLACODE_COS")]
        [StringLength(30)]
        public string MglacodeCos { get; set; }
        [Column("MGLACODE_DEF_COS")]
        [StringLength(30)]
        public string MglacodeDefCos { get; set; }
        [Column("MGLACODE_DEF_SALES")]
        [StringLength(30)]
        public string MglacodeDefSales { get; set; }
        [Column("MGLACODE_SALES")]
        [StringLength(30)]
        public string MglacodeSales { get; set; }
        [Column("MGLACODE_WIP")]
        [StringLength(30)]
        public string MglacodeWip { get; set; }
        [Column("MGLACODE_ACC_TAX")]
        [StringLength(30)]
        public string MglacodeAccTax { get; set; }
        [Column("GLACODE_SUSPENSE")]
        [StringLength(30)]
        public string GlacodeSuspense { get; set; }
        [Column("GLACODE_STATE")]
        [StringLength(30)]
        public string GlacodeState { get; set; }
        [Column("GLACODE_COUNTY")]
        [StringLength(30)]
        public string GlacodeCounty { get; set; }
        [Column("GLACODE_CITY")]
        [StringLength(30)]
        public string GlacodeCity { get; set; }
        [Column("PRD_AB_INCOME")]
        public short? PrdAbIncome { get; set; }
        [Column("MED_AB_INCOME")]
        public short? MedAbIncome { get; set; }
        [Column("GLACODE_VOL_DISC")]
        [StringLength(30)]
        public string GlacodeVolDisc { get; set; }
        [Column("GLACODE_AP_WH")]
        [StringLength(30)]
        public string GlacodeApWh { get; set; }
        [Column("INACTIVE_FLAG")]
        public short? InactiveFlag { get; set; }
        [Column("AVATAX_COMPANY_CODE")]
        [StringLength(25)]
        public string AvataxCompanyCode { get; set; }
        [Column("GLACODE_CRNCY_GAIN_LOSS")]
        [StringLength(30)]
        public string GlacodeCrncyGainLoss { get; set; }
        [Column("GLACODE_CLIENT_LATE_PAYMENT_FEE")]
        [StringLength(30)]
        public string GlacodeClientLatePaymentFee { get; set; }

        [InverseProperty(nameof(Job.OfficeCodeNavigation))]
        public virtual ICollection<Job> JobLogs { get; set; }
        [InverseProperty(nameof(Product.OfficeCodeNavigation))]
        public virtual ICollection<Product> Products { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}