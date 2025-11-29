using Domain;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> FindBooksAsync(string Keyword);
    }
}
