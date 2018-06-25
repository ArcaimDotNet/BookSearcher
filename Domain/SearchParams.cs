using System.Net.Http;

namespace BookSearcher.Domain
{
    public class SearchParams
    {
        public string BaseAddress { get; protected set; }
        public string Request { get; protected set; }
        public HttpMethod HttpMethod { get; protected set; }
        public string TitleStart { get; protected set; }
        public string TitleEnd { get; protected set; }
        public string PriceStart { get; protected set; }
        public string PriceEnd { get; protected set; }
        public string UrlStart { get; protected set; }
        public string UrlEnd { get; protected set; }

        protected SearchParams()
        {
        }

        protected SearchParams(string baseAddress, string request, HttpMethod httpMethod, string titleStart, string titleEnd, string priceStart, string priceEnd, string urlStart, string urlEnd)
        {
            SetBaseAddress(baseAddress);
            SetRequest(request);
            SetHttpMethod(httpMethod);
            SetTitleStart(titleStart);
            SetTitleEnd(titleEnd);
            SetPriceStart(priceStart);
            SetPriceEnd(priceEnd);
            SetUrlStart(urlStart);
            SetUrlEnd(urlEnd);
        }

        public static SearchParams Create(string baseAddress, string request, HttpMethod httpMethod, string titleStart, string titleEnd, string priceStart, string priceEnd, string urlStart, string urlEnd)
            => new SearchParams(baseAddress, request, httpMethod, titleStart, titleEnd, priceStart, priceEnd, urlStart, urlEnd);

        public void SetBaseAddress(string baseAddress) => BaseAddress = baseAddress; // ToDo: Add validation, Regex?
        public void SetRequest(string request) => Request = request;
        public void SetHttpMethod(HttpMethod httpMethod) => HttpMethod = httpMethod;
        public void SetTitleStart(string titleStart) => TitleStart = titleStart;
        public void SetTitleEnd(string titleEnd) => TitleEnd = titleEnd;
        public void SetPriceStart(string priceStart) => PriceStart = priceStart;
        public void SetPriceEnd(string priceEnd) => PriceEnd = priceEnd;
        public void SetUrlStart(string urlStart) => UrlStart = urlStart;
        public void SetUrlEnd(string urlEnd) => UrlEnd = urlEnd;
    }
}