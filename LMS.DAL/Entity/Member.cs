using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.DAL.Entity
{
    [Table("Members")]
    public class Member : BaseEntity
    {
        [Column("MemberName"), StringLength(50)]
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        [StringLength(14)]
        public string Phone { get; set; } = "";
        public DateTime MembershipDate { get; set; }
    }
}
