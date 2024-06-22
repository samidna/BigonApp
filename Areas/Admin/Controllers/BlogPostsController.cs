using BigonApp.Business.Modules.BlogPostsModules.Commands.BlogPostsAdd;
using BigonApp.Business.Modules.BlogPostsModules.Commands.BlogPostUpdate;
using BigonApp.Business.Modules.BlogPostsModules.Queries.BlogPostsGetAll;
using BigonApp.Business.Modules.BlogPostsModules.Queries.BlogPostsGetById;
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
        private readonly ICategoryService _catService;
        private readonly IMediator _mediator;

        public BlogPostsController(ICategoryService catService,IMediator mediator)
        {
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
        public async Task<IActionResult> Create(BlogPostsAddRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(BlogPostsGetByIdRequest request)
        {
            var categories = _catService.GetAll(c => c.DeletedBy == null);
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            var response = await _mediator.Send(request);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(BlogPostUpdateRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(BlogPostsGetByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }
    }
}
