using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BookSearcher.Domain;
using BookSearcher.DTOs;
using BookSearcher.Extensions;
using BookSearcher.Models;
using BookSearcher.Repositories;

namespace BookSearcher.Services
{
    public class BookService : IBookService
    {
        public readonly IUrlBookRepository UrlBookRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        protected BookService()
        {
        }

        public BookService(IUrlBookRepository urlBookRepository, IHttpClientFactory httpClientFactory)
        {
            UrlBookRepository = urlBookRepository;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<BookDto>> Search(Book book)
        {
            var bookUrls = new List<BookDto>();
            var isbn = book.ISBN.Replace("-", "").Replace(" ", "");;

            foreach(var parameters in await UrlBookRepository.GetAll())
            {
                var bookDto = await GetBookDto(parameters, isbn);
                if(bookDto is null)
                    continue;

                bookUrls.Add(bookDto);
            }

            return bookUrls;
        }

        private async Task<BookDto> GetBookDto(SearchParams parameters, string isbn)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://" + parameters.BaseAddress);
            var stringContent = new StringContent(content: "{\"name\":\"Json Webapi\",\"age\":33}",
                                            encoding: Encoding.UTF8,
                                            mediaType:"application/json");

            var request = new HttpRequestMessage(parameters.HttpMethod, parameters.Request + isbn) { Content = stringContent };

            var result = await client.SendAsync(request);
            if (!result.IsSuccessStatusCode && result.RequestMessage.RequestUri.AbsoluteUri != client.BaseAddress + "/" + parameters.Request + isbn)
            {
                result = await client.SendAsync(new HttpRequestMessage(parameters.HttpMethod, result.RequestMessage.RequestUri.PathAndQuery)
                { Content = stringContent });
            }

            if(!result.IsSuccessStatusCode)
                return null;
                
            var content = await result.Content.ReadAsStringAsync();
            
            var title = content.Match(parameters.TitleStart, parameters.TitleEnd).Trim().Replace(" -", ":");
            content = content.Replace(" ", "").Replace("\n", "");
            var price = content.Match(parameters.PriceStart, parameters.PriceEnd);
            var url = result.RequestMessage.RequestUri.AbsoluteUri;
            var websiteName = parameters.BaseAddress.Match("www.", ".com/");

            if (title is null || price is null || url is null)
                return null;

            return new BookDto { WebsiteName = websiteName, Title = title, Price = price, Url = url };
        }
    }
}