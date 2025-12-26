using LMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.BLL.Model
{
    public class BorrowTransactionDTO : BaseEntityDTO
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
