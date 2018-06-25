using System.Collections.Generic;
using System.Threading.Tasks;
using BookSearcher.Domain;

namespace BookSearcher.Repositories
{
    public interface IUrlBookRepository : IRepository
    {
        Task<IEnumerable<SearchParams>> GetAll();
    }
}