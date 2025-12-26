using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.DAL.Entity
{
    [Table("BorrowTransactions")]
    public class BorrowTransaction : BaseEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; } = new Book();
        public int MemberId { get; set; }
        public Member Member { get; set; } = new Member();
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
