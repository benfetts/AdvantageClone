
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("APP_VARS")]
    public partial class AppVar
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
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("USERID")]
        [StringLength(100)]
        public string Userid { get; set; }
        [Column("APPLICATION")]
        [StringLength(100)]
        public string Application { get; set; }
        [Column("VARIABLE_GROUP")]
        [StringLength(200)]
        public string VariableGroup { get; set; }
        [Column("VARIABLE_NAME")]
        [StringLength(200)]
        public string VariableName { get; set; }
        [Column("VARIABLE_TYPE")]
        [StringLength(200)]
        public string VariableType { get; set; }
        [Column("VARIABLE_ORDER")]
        public int? VariableOrder { get; set; }
        [Column("VARIABLE_VALUE", TypeName = "varchar(max)")]
        public string VariableValue { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}