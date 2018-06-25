using System.Collections.Generic;
using System.Threading.Tasks;
using BookSearcher.DTOs;
using BookSearcher.Models;

namespace BookSearcher.Services
{
    public interface IBookService
    {
         Task<IEnumerable<BookDto>> Search(Book isbn);
    }
}