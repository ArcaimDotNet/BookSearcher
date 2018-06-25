using System;

namespace BookSearcher.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool? IsEnabled { get; set; }
    }
}