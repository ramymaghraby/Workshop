using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DAL.Entity
{
    public class BorrowTransaction : BaseEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
