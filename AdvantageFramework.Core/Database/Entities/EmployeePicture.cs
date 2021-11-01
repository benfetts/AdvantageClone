
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("EMPLOYEE_PICTURE")]
    public partial class EmployeePicture
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
        [Column("EMP_PICTURE_ID")]
        public int EmpPictureId { get; set; }
        [Required]
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        [Column("EMP_IMAGE", TypeName = "image")]
        public byte[] EmpImage { get; set; }
        [Column("EMP_NICKNAME")]
        [StringLength(10)]
        public string EmpNickname { get; set; }
        [Column("EMP_WALLPAPER", TypeName = "image")]
        public byte[] EmpWallpaper { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}