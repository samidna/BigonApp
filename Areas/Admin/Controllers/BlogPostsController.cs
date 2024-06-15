using BigonApp.Business.Modules.BlogPostsModules.Queries.BlogPostsGetAll;
using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using BigonApp.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BigonApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly IBlogRepository _blogRepo;
        private readonly IFileService _fileService;
        private readonly ICategoryService _catService;
        private readonly IMediator _mediator;

        public BlogPostsController(IBlogRepository blogRepo, IFileService fileService,ICategoryService catService,IMediator mediator)
        {
            _blogRepo=blogRepo;
            _fileService=fileService;
            _catService=catService;
            _mediator=mediator;
        }
        public async Task<IActionResult> Index(BlogPostsGetAllRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }
        public IActionResult Create()
        {
            var categories = _catService.GetAll(c => c.DeletedBy == null);
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogPost blogPost, IFormFile file)
        { 
            var fileName = await _fileService.UploadAsync(file);
            var newBlogPost = new BlogPost
            {
                Title = blogPost.Title,
                Body=blogPost.Body,
                FilePath = fileName,
                Slug=blogPost.Title,
                CategoryId=blogPost.CategoryId
            };
            _blogRepo.Add(newBlogPost);
            return RedirectToAction(nameof(Index));
        }
    }
}
