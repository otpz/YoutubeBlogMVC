using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlogMVC.Entity.Entities;
using YoutubeBlogMVC.Entity.ModelViews.Articles;
using YoutubeBlogMVC.Entity.ModelViews.Categories;
using YoutubeBlogMVC.Service.Services.Abstraction;
using YoutubeBlogMVC.Web.ResultMessages;

namespace YoutubeBlogMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<Category> _validator;

        public CategoryController(ICategoryService categoryService, IMapper mapper, IToastNotification toastNotification, IValidator<Category> validator)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }
        public async Task<IActionResult> DeletedCategory()
        {
            var categories = await _categoryService.GetAllCategoriesDeleted();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddModelView categoryAddModelView)
        {
            var map = _mapper.Map<Category>(categoryAddModelView);
            var result = await _validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                // yukarıdaki işlemler validation içindir.
                return View();
            }

            _toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddModelView.Name), new ToastrOptions { Title ="Başarılı" });
            await _categoryService.CreateCategoryAsync(categoryAddModelView);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddModelView categoryAddModelView)
        {
            var map = _mapper.Map<Category>(categoryAddModelView);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddModelView);
                _toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddModelView.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return Json(Messages.Category.Add(categoryAddModelView.Name));
            } else
            {
                _toastNotification.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "İşlem Başarısız" });
                return Json(result.Errors.First().ErrorMessage);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            var category = await _categoryService.GetCategoryByGuid(categoryId);
            var categoryUpdateModelViewMap = _mapper.Map<Category, CategoryUpdateModelView>(category);
            return View(categoryUpdateModelViewMap);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateModelView categoryUpdateModelView)
        {
            var map = _mapper.Map<Category>(categoryUpdateModelView);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await _categoryService.UpdateCategoryAsync(categoryUpdateModelView);
                _toastNotification.AddSuccessToastMessage(Messages.Category.Update(categoryUpdateModelView.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            string title = await _categoryService.SafeDeleteCategoryAsync(categoryId);
            _toastNotification.AddSuccessToastMessage(Messages.Category.Delete(title), new ToastrOptions { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UndoDelete(Guid categoryId)
        {
            string title = await _categoryService.UndoDeleteCategoryAsync(categoryId);
            _toastNotification.AddSuccessToastMessage(Messages.Category.UndoDelete(title), new ToastrOptions { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

    }
}
