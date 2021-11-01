
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("SEC_USER")]
    public partial class SecurityUser
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
        [Column("SEC_USER_ID")]
        public int SecUserId { get; set; }
        [Required]
        [Column("USER_CODE")]
        [StringLength(100)]
        public string UserCode { get; set; }
        [Required]
        [Column("USER_NAME")]
        [StringLength(128)]
        public string UserName { get; set; }
        [Required]
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        [Column("CHECK_USER_ACCESS")]
        public bool CheckUserAccess { get; set; }
        [Column("MENU_HWND")]
        public int? MenuHwnd { get; set; }
        [Column("WEB_ID")]
        [StringLength(255)]
        public string WebId { get; set; }
        [Column("TIME_HWND")]
        public int? TimeHwnd { get; set; }
        [Column("IS_INACTIVE")]
        public bool IsInactive { get; set; }
        [Column("PASSWORD")]
        public string Password { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}