using LMS.BLL.Helper;
using LMS.BLL.Model;
using LMS.BLL.Repository;
using LMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LMS.BLL.Service
{
    public class BookService : IBookService
    {
        GenericRepository<Book> _bookRepository;
        public BookService()
        {
            _bookRepository = new GenericRepository<Book>();
        }
        public async Task<BookDTO> CreateBookAsync(BookDTO bookDTO)
        {
            try
            {
                var book = new Book
                {
                    Title = bookDTO.Title,
                    Author = bookDTO.Author,
                    ISBN = bookDTO.ISBN,
                    CategoryId = bookDTO.CategoryId,
                    PublishedYear = bookDTO.PublishedYear,
                    Rate = bookDTO.Rate,
                    IsAvailable = bookDTO.IsAvailable
                };
                var createdBook = await _bookRepository.CreateAsync(book);
                bookDTO.Id = createdBook.Id;
                return bookDTO;
            }
            catch (Exception ex)
            {
                await CustomExceptionLogger.LogException(ex);
                return null;
            }
        }
        public async Task<bool> DeleteBookAsync(Expression<Func<Book, bool>> filter)
        {
            try
            {
                var book = await _bookRepository.GetByAsync(filter);
                if (book == null)
                    return false;
                book.IsActive = false;
                await _bookRepository.UpdateAsync(book);
                return true;
            }
            catch (Exception ex)
            {
                await CustomExceptionLogger.LogException(ex);
                return false;
            }
        }
        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync(Expression<Func<Book, bool>>? filter = null)
        {
            try
            {
                var books = await _bookRepository.GetAllAsync(filter);
                var bookDTOs = new List<BookDTO>();
                foreach (var book in books)
                {
                    bookDTOs.Add(new BookDTO
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        ISBN = book.ISBN,
                        CategoryId = book.CategoryId,
                        PublishedYear = book.PublishedYear,
                        Rate = book.Rate,
                        IsAvailable = book.IsAvailable
                    });
                }
                return bookDTOs;
            }
            catch (Exception ex)
            {
                await CustomExceptionLogger.LogException(ex);
                return null;
            }
        }
        public async Task<BookDTO> GetBookByAsync(Expression<Func<Book, bool>> filter)
        {
            try
            {
                var book = await _bookRepository.GetByAsync(filter);
                return new BookDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    CategoryId = book.CategoryId,
                    PublishedYear = book.PublishedYear,
                    Rate = book.Rate,
                    IsAvailable = book.IsAvailable
                };
            }
            catch (Exception ex)
            {
                await CustomExceptionLogger.LogException(ex);
                return null;
            }
        }
        public async Task<BookDTO> UpdateBookAsync(BookDTO bookDTO)
        {
            try
            {
                var book = new Book
                {
                    Id = bookDTO.Id,
                    Title = bookDTO.Title,
                    Author = bookDTO.Author,
                    ISBN = bookDTO.ISBN,
                    CategoryId = bookDTO.CategoryId,
                    PublishedYear = bookDTO.PublishedYear,
                    Rate = bookDTO.Rate,
                    IsAvailable = bookDTO.IsAvailable
                };
                var updatedBook = await _bookRepository.UpdateAsync(book);
                bookDTO.Id = updatedBook.Id;
                return bookDTO;
            }
            catch (Exception ex)
            {
                await CustomExceptionLogger.LogException(ex);
                return null;

            }
        }
    }
    public interface IBookService
    {
        public Task<BookDTO> CreateBookAsync(BookDTO bookDTO);
        public Task<bool> DeleteBookAsync(Expression<Func<Book, bool>> filter);
        public Task<IEnumerable<BookDTO>> GetAllBooksAsync(Expression<Func<Book, bool>>? filter = null);
        public Task<BookDTO> GetBookByAsync(Expression<Func<Book, bool>> filter);
        public Task<BookDTO> UpdateBookAsync(BookDTO bookDTO);
    }
}
