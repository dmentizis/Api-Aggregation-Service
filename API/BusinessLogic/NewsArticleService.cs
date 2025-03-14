using DMSubmission.Objects.DTOs;
using DMSubmission.Objects.Entities;
using DMSubmission.Services;

namespace DMSubmission.BusinessLogic
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly INewsApiService _newsApiService;

        public NewsArticleService(INewsApiService newsApiService)
        {
            _newsApiService = newsApiService;
        }

        public async Task<GetNewsArticlesControllerResponseDTO> FindNewsArticlesAsync(FindNewsControllerRequestDTO request)
        {
            NewsApiServiceRequestDTO apiServiceRequest = new NewsApiServiceRequestDTO()
            {
                q = request.SearchText,
                sortBy = request.SortBy,
                language = request.Language,
            };

            NewsApiServiceResponseDTO apiServiceResponse;
            try
            {
                apiServiceResponse = await _newsApiService.FindRelatedNewsAsync(apiServiceRequest);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            List<NewsArticle> newsArticles = new List<NewsArticle>();

            //if(apiServiceRequest == null )
            //{
            //    throw new Exception("bleh");
            //}

            //if(apiServiceRequest.articles)

            if (apiServiceResponse.articles != null) 
            {
                if (apiServiceResponse.articles.Count > 0)
                {
                    try
                    {
                        foreach (NewsApiServiceResponseDTO.Article article in apiServiceResponse.articles)
                        {
                            NewsArticle newsArticle = new NewsArticle()
                            {
                                SourceName = article.source.name,
                                Author = article.author,
                                Title = article.title,
                                Description = article.description,
                                Url = article.url
                            };

                            newsArticles.Add(newsArticle);
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            GetNewsArticlesControllerResponseDTO response = new GetNewsArticlesControllerResponseDTO()
            {
                NewsArticles = newsArticles
            };

            return response;

        }
    }
}
