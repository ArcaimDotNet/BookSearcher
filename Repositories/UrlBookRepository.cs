using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BookSearcher.Domain;

namespace BookSearcher.Repositories
{
    public class UrlBookRepository : IUrlBookRepository
    {
        private ISet<SearchParams> _params => new HashSet<SearchParams>
        {
            SearchParams.Create(baseAddress: "www.amazon.com/",
                                request: "s/ref=nb_sb_noss?url=search-alias%3Daps&field-keywords=",
                                httpMethod: HttpMethod.Post,
                                titleStart: "<h2 data-attribute=\"",
                                titleEnd: "\" data-max-rows",
                                priceStart: "<spanclass=\"a-offscreen\">",
                                priceEnd: "</span>",
                                urlStart: "class=\"a-link-normala-text-normal\"href=\"https://",
                                urlEnd: "\">"),
            SearchParams.Create(baseAddress: "www.apress.com/",
                                request: "us/book/",
                                httpMethod: HttpMethod.Get,
                                titleStart: "<meta property=\"og:title\" content=\"",
                                titleEnd: "|",
                                priceStart: "<spanclass=\"cover-type\">Softcover</span><spanclass=\"price-box\"><spanclass=\"price\">",
                                priceEnd: "</span></span>",
                                urlStart: "<linkrel=\"canonical\"href=\"//",
                                urlEnd: "\">"),
        };
        
        public async Task<IEnumerable<SearchParams>> GetAll() => await Task.FromResult(_params);
    }
}