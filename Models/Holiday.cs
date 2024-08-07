using System;

namespace JetSetAPI.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Label { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }
    }
}
