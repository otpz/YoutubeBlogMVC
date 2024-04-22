﻿namespace YoutubeBlogMVC.Entity.ModelViews.Articles
{
    public class ArticleModelView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
