
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("EMP_DP_TM")]
    public partial class EmployeeDepartmentTeam
    {
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
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        [Key]
        [Column("DP_TM_CODE")]
        [StringLength(6)]
        public string DpTmCode { get; set; }
        [Column("DP_TM_DESC")]
        [StringLength(30)]
        public string DpTmDesc { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}