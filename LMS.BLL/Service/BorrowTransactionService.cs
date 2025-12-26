using LMS.BLL.Model;
using LMS.BLL.Repository;
using LMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.BLL.Service
{
    public class BorrowTransactionService : IBorrowTransactionService
    {
        GenericRepository<BorrowTransaction> _borrowTransactionRepository;
        public BorrowTransactionService()
        {
            _borrowTransactionRepository = new GenericRepository<BorrowTransaction>();
        }
        public async Task<bool> BorrowBookAsync(BorrowTransactionDTO borrowTransactionDTO)
        {
            var transaction = new BorrowTransaction
            {
                BookId = borrowTransactionDTO.BookId,
                MemberId = borrowTransactionDTO.MemberId,
                BorrowDate = DateTime.Now,
                DueDate = borrowTransactionDTO.DueDate,
                ReturnDate = borrowTransactionDTO.ReturnDate
                
            };
            await _borrowTransactionRepository.CreateAsync(transaction);
            return true;
        }
        public async Task<bool> ReturnBookAsync(BorrowTransactionDTO borrowTransactionDTO)
        {
            var transaction = await _borrowTransactionRepository.GetByAsync(t => t.BookId == borrowTransactionDTO.BookId && t.MemberId == borrowTransactionDTO.MemberId && t.ReturnDate == borrowTransactionDTO.ReturnDate);
            if (transaction == null)
                return false;
            transaction.ReturnDate = DateTime.Now;
            await _borrowTransactionRepository.UpdateAsync(transaction);
            return true;
        }
    }
    public interface IBorrowTransactionService
    {
        public Task<bool> BorrowBookAsync(BorrowTransactionDTO borrowTransactionDTO);
        public Task<bool> ReturnBookAsync(BorrowTransactionDTO borrowTransactionDTO);

    }
}
