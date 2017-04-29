using System;
using System.Collections.Generic;

namespace BlogApp.Frontend.ApiModels
{
    public class ArticleApiModel
    {        
        public int Id { get; set; }

        public int? AuthorId { get; set; }

        public string Description { get; set; }

        public string Slug { get; set; }

        public string FeaturedImageUrl { get; set; }

        public string Title { get; set; }

        public string HtmlContent { get; set; }

        public bool IsPublished { get; set; }

        public DateTime? Published { get; set; }

        public AuthorApiModel Author { get; set; }

        public ICollection<TagApiModel> Tags { get; set; } = new HashSet<TagApiModel>();

        public ICollection<CategoryApiModel> Categories { get; set; }
    }
}