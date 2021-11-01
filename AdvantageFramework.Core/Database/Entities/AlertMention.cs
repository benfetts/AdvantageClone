
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("ALERT_MENTION")]
    public partial class AlertMention
    {
        #region Constants



        #endregion

        #region Enum

        #endregion

        #region Variables



        #endregion

        #region Properties
        [Required]
        [Column("ALERT_ID")]
        public int AlertId { get; set; }

        [Required]
        [Column("COMMENT_ID")]
        public int CommentId { get; set; }

        [Required]
        [Column("MENTION_EMP_CODE")]
        [StringLength(6)]
        public string MentionEmpCode { get; set; }

        [Required]
        [Column("USER_CODE")]
        [StringLength(6)]
        public string UserCode { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
