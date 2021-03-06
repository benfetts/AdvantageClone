// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AdvantageFramework.Core.Security.Database.Entities
{
    [Table("DIVISION")]
    [Index(nameof(ActiveFlag), Name = "IDX_DIVISION_ACTIVE_FLAG")]
    [Index(nameof(ClCode), nameof(DivCode), Name = "IDX_DIVISION_CL_CODE")]
    public partial class Division
    {
        public Division()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("CL_CODE")]
        [StringLength(6)]
        public string ClCode { get; set; }
        [Key]
        [Column("DIV_CODE")]
        [StringLength(6)]
        public string DivCode { get; set; }
        [Column("DIV_NAME")]
        [StringLength(40)]
        public string DivName { get; set; }
        [Column("DIV_ATTENTION")]
        [StringLength(40)]
        public string DivAttention { get; set; }
        [Column("DIV_BADDRESS1")]
        [StringLength(40)]
        public string DivBaddress1 { get; set; }
        [Column("DIV_BADDRESS2")]
        [StringLength(40)]
        public string DivBaddress2 { get; set; }
        [Column("DIV_BCITY")]
        [StringLength(30)]
        public string DivBcity { get; set; }
        [Column("DIV_BCOUNTY")]
        [StringLength(20)]
        public string DivBcounty { get; set; }
        [Column("DIV_BSTATE")]
        [StringLength(10)]
        public string DivBstate { get; set; }
        [Column("DIV_BCOUNTRY")]
        [StringLength(20)]
        public string DivBcountry { get; set; }
        [Column("DIV_BZIP")]
        [StringLength(10)]
        public string DivBzip { get; set; }
        [Column("DIV_SADDRESS1")]
        [StringLength(40)]
        public string DivSaddress1 { get; set; }
        [Column("DIV_SADDRESS2")]
        [StringLength(40)]
        public string DivSaddress2 { get; set; }
        [Column("DIV_SCITY")]
        [StringLength(30)]
        public string DivScity { get; set; }
        [Column("DIV_SCOUNTY")]
        [StringLength(20)]
        public string DivScounty { get; set; }
        [Column("DIV_SSTATE")]
        [StringLength(10)]
        public string DivSstate { get; set; }
        [Column("DIV_SCOUNTRY")]
        [StringLength(20)]
        public string DivScountry { get; set; }
        [Column("DIV_SZIP")]
        [StringLength(10)]
        public string DivSzip { get; set; }
        [Column("DIV_ALPHA_SORT")]
        [StringLength(20)]
        public string DivAlphaSort { get; set; }
        [Column("ACTIVE_FLAG")]
        public short? ActiveFlag { get; set; }
        [Column("BATCH_NAME")]
        [StringLength(50)]
        public string BatchName { get; set; }

        [ForeignKey(nameof(ClCode))]
        [InverseProperty(nameof(Client.Divisions))]
        public virtual Client ClCodeNavigation { get; set; }
        [InverseProperty(nameof(Product.Division))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
