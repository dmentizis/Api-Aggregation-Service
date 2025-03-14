using DMSubmission.Objects.DTOs;
using DMSubmission.Objects.Entities;
using DMSubmission.Services;

namespace DMSubmission.BusinessLogic
{
    public class CityInfoService : ICityInfoService
    {
        private readonly IOpenLibraryApiService _openLibraryApiService;
        private readonly INewsApiService _newsApiService;
        private readonly IWeatherApiService _weatherApiService;

        public CityInfoService(IOpenLibraryApiService openLibraryApiService, IWeatherApiService weatherApiService, INewsApiService newsApiService)
        {
            _openLibraryApiService = openLibraryApiService;
            _newsApiService = newsApiService;
            _weatherApiService = weatherApiService;
        }

        public async Task<GetCityInfoControllerResponseDTO> FindCityAggregatedInfo(GetCityInfoControllerRequestDTO request)
        {
            WeatherServiceApiRequestDTO weatherApiServiceRequest = new WeatherServiceApiRequestDTO()
            {
                CityName = request.CityName
            };

            OpenLibraryApiRequestDTO openLibraryApiRequest = new OpenLibraryApiRequestDTO()
            {
                SearchText = request.CityName
            };

            NewsApiServiceRequestDTO newsApiServiceRequest = new NewsApiServiceRequestDTO()
            {
                q = request.CityName,
                sortBy = request.SortArticlesOrder,
                language = request.ArticleLanguage
            };

            var weatherServiceApiTask = _weatherApiService.GetCurrentWeatherByCityNameAsync(weatherApiServiceRequest);
            var openLibraryApiTask = _openLibraryApiService.GetBooksByKeywordAsync(openLibraryApiRequest);
            var newsApiTask = _newsApiService.FindRelatedNewsAsync(newsApiServiceRequest);

            try
            {
                await Task.WhenAll(weatherServiceApiTask, openLibraryApiTask, newsApiTask);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching city info: {ex.Message}");
            }

            WeatherServiceApiResponseDTO? weatherServiceApiResponse = weatherServiceApiTask.IsCompletedSuccessfully ? weatherServiceApiTask.Result : null;
            OpenLibraryApiResponseDTO? openLibraryApiResponse = openLibraryApiTask.IsCompletedSuccessfully ? openLibraryApiTask.Result : null;
            NewsApiServiceResponseDTO? newsApiServiceResponse = newsApiTask.IsCompletedSuccessfully ? newsApiTask.Result : null;

            CityWeather cityWeather = null;
            if (weatherServiceApiResponse != null)
            {
                try
                {
                    cityWeather = new CityWeather()
                    {
                        CityName = weatherServiceApiResponse.name,
                        WeatherDescription = $"{weatherServiceApiResponse.weather.FirstOrDefault().main}, {weatherServiceApiResponse.weather.FirstOrDefault().description}",
                        Temperature = weatherServiceApiResponse.main.temp,
                        TemperatureFeels = weatherServiceApiResponse.main.feels_like,
                        Humidity = weatherServiceApiResponse.main.humidity,
                        WindSpeed = weatherServiceApiResponse.wind.speed
                    };
                }
                catch (Exception ex)
                {
                    throw new Exception($"Could not convert API request data to City Weather data {ex.Message}");
                }
            }

            List<Book> books = null;

            if (openLibraryApiResponse != null)
            {
                books = new List<Book>();
                try
                {
                    foreach (var doc in openLibraryApiResponse.docs)
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
            }

            List<NewsArticle> articles = null;

            if (newsApiServiceResponse != null )
            {
                try
                {
                    articles = new List<NewsArticle>();
                    foreach (NewsApiServiceResponseDTO.Article article in newsApiServiceResponse.articles)
                    {
                        NewsArticle newsArticle = new NewsArticle()
                        {
                            SourceName = article.source.name,
                            Author = article.author,
                            Title = article.title,
                            Description = article.description,
                            Url = article.url
                        };

                        articles.Add(newsArticle);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            GetCityInfoControllerResponseDTO response = new GetCityInfoControllerResponseDTO()
            {
                CurrentWeather = cityWeather,
                RelatedBooks = books,
                RelatedArtices = articles
            };

            return response;
        }
    }
}

    
