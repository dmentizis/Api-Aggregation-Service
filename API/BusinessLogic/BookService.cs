using DMSubmission.Objects.DTOs;
using DMSubmission.Objects.Entities;
using DMSubmission.Services;

namespace DMSubmission.BusinessLogic
{
    public class BookService : IBookService
    {
        private readonly IOpenLibraryApiService _openLibraryApiService;

        public BookService(IOpenLibraryApiService openLibraryApiService)
        {
            _openLibraryApiService = openLibraryApiService;
        }

        /// <summary>
        /// Business Logic method that transforms OpenLibrary API requests to Book controller endpoints responses.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GetBooksByKeywordControllerResponseDTO> FindBooksAsync(FindBooksControllerRequestDTO request)
        {
            OpenLibraryApiRequestDTO apiServiceRequest = new OpenLibraryApiRequestDTO()
            {
                SearchText = request.SearchText
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

            if(apiServiceResponse == null)
            {
                throw new Exception("Could not fetch data from API service");
            }
            
            List<Book> books = new List<Book>();

            try
            {
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

            GetBooksByKeywordControllerResponseDTO response = new GetBooksByKeywordControllerResponseDTO()
            {
                Booklist = books
            };

            return response;
        }
    }
}
