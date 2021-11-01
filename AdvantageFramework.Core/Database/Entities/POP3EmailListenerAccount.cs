using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("AGY_POP3_ACCOUNT")]
    public partial class POP3EmailListenerAccount
    {
        [Key]
        [Column("POP3_ACCOUNT_ID")]
        public int Pop3AccountId { get; set; }
        [Column("POP3_ACCOUNT_TYPE")]
        public short Pop3AccountType { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(30)]
        public string Description { get; set; }
        [Column("USERNAME")]
        [StringLength(100)]
        public string Username { get; set; }
        [Column("PASSWORD")]
        public string Password { get; set; }
        [Column("REPLY_TO")]
        [StringLength(50)]
        public string ReplyTo { get; set; }
        [Column("DELETE_PROCESSED")]
        public short? DeleteProcessed { get; set; }
    }
}
