using LMS.BLL.Helper;
using LMS.BLL.Model;
using LMS.BLL.Repository;
using LMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.BLL.Service
{
    public class ReservationTransactionService : IReservationTransactionService
    {
        GenericRepository<ReservationTransaction> _reservationTransactionRepository;
        public ReservationTransactionService()
        {
            _reservationTransactionRepository = new GenericRepository<ReservationTransaction>();
        }
        public async Task<bool> ReserveBookAsync(ReservationTransactionDTO reservationTransactionDTO)
        {
            try
            {
                var transaction = new ReservationTransaction
                {
                    BookId = reservationTransactionDTO.BookId,
                    MemberId = reservationTransactionDTO.MemberId,
                    ReservationDate = DateTime.Now,
                    ExpirationDate = reservationTransactionDTO.ExpirationDate,
                    Member = reservationTransactionDTO.Member,
                    Book = reservationTransactionDTO.Book,
                    CreatedOn = DateTime.Now,
                };
                await _reservationTransactionRepository.CreateAsync(transaction);
                return true;
            }
            catch (Exception ex)
            {
                await CustomExceptionLogger.LogException(ex);
                return false;
            }
        }
        public async Task<bool> CancelReservationAsync(ReservationTransactionDTO reservationTransactionDTO)
        {
            try
            {
                var transaction = await _reservationTransactionRepository.GetByAsync(t => t.BookId == reservationTransactionDTO.BookId && t.MemberId == reservationTransactionDTO.MemberId && t.ExpirationDate == reservationTransactionDTO.ExpirationDate);
                if (transaction == null)
                    return false;
                transaction.IsActive = false;
                await _reservationTransactionRepository.UpdateAsync(transaction);
                return true;
            }
            catch (Exception ex)
            {
                await CustomExceptionLogger.LogException(ex);
                return false;
            }
        }
        }
    public interface IReservationTransactionService
    {
        public Task<bool> ReserveBookAsync(ReservationTransactionDTO reservationTransactionDTO);
        public Task<bool> CancelReservationAsync(ReservationTransactionDTO reservationTransactionDTO);

    }
}
