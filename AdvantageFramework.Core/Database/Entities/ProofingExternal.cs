
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("PROOFING_EXTERNAL")]
    public partial class ProofingExternal
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
        [Column("EMAIL")]
        [StringLength(1000)]
        public string Email { get; set; }
        [Column("NAME")]
        [StringLength(1000)]
        public string Name { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}