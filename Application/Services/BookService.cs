using Application.Interfaces;
using Domain;
using Infrastructure.Interfaces;
using Infrastructure.Objects.DTOs.Requests;
using Infrastructure.Objects.DTOs.Responses;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IOpenLibraryApiService _openLibraryApiService;

        public BookService(IOpenLibraryApiService openLibraryApiService)
        {
            _openLibraryApiService = openLibraryApiService;
        }

        /// <summary>
        /// Asynchronously searches for books that match the specified keyword using the Open Library API.
        /// </summary>
        /// <param name="Keyword">The keyword to search for in book titles, authors, or other metadata. Cannot be null or empty.</param>
        /// <returns>A list of books that match the specified keyword. The list will contain one or more Book objects if matches
        /// are found.</returns>
        /// <exception cref="Exception">Thrown if the keyword is null or empty, if no books are found for the given keyword, or if an error occurs
        /// while communicating with the API service.</exception>
        public async Task<List<Book>> FindBooksAsync(string Keyword)
        {
            OpenLibraryApiRequestDTO apiServiceRequest = new OpenLibraryApiRequestDTO()
            {
                SearchText = Keyword
            };

            OpenLibraryApiResponseDTO apiServiceResponse;
            try
            {
                apiServiceResponse = await _openLibraryApiService.GetBooksByKeywordAsync(apiServiceRequest);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (apiServiceResponse == null)
            {
                throw new Exception("Could not fetch data from API service");
            }

            List<Book> books = new List<Book>();

            try
            {
                if (apiServiceResponse.docs == null || apiServiceResponse.docs.Count == 0)
                {
                    throw new Exception("No books found for the given keyword.");
                }

                foreach (var doc in apiServiceResponse.docs)
                {
                    Book book = new Book()
                    {
                        AuthorName = doc.author_name,
                        Language = doc.language,
                        Title = doc.title,
                        Subtitle = doc.subtitle,
                        FirstPublishYear = doc.first_publish_year
                    };
                    books.Add(book);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return books;
        }
    }
}
