using AutoMapper;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Articles;

namespace YoutubeBlogMVC.Service.AutoMapper.Articles
{
    // burada view model'in profilini oluşturuyoruz.
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            // aşağıda bir map'leme işlemi yaptık. ModelView ile Article birbirine map'lendi.
            CreateMap<ArticleModelView, Article>().ReverseMap();
            CreateMap<ArticleUpdateModelView, Article>().ReverseMap();
            CreateMap<ArticleUpdateModelView, ArticleModelView>().ReverseMap();
            CreateMap<ArticleAddModelView, Article>().ReverseMap();
        }
    }
}
