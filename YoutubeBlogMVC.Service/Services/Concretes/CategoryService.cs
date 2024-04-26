using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Data.UnitOfWorks;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Categories;
using YoutubeBlogMVC.Service.Services.Abstraction;

namespace YoutubeBlogMVC.Service.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryModelView>> GetAllCategoriesNonDeleted()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);

            var map = _mapper.Map<List<CategoryModelView>>(categories);

            return map;

        }
    }
}
