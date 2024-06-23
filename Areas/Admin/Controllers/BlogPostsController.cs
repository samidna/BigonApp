using BigonApp.Business.Modules.BlogPostsModules.Commands.BlogPostDelete;
using BigonApp.Business.Modules.BlogPostsModules.Commands.BlogPostsAdd;
using BigonApp.Business.Modules.BlogPostsModules.Commands.BlogPostUpdate;
using BigonApp.Business.Modules.BlogPostsModules.Queries.BlogPostsGetAll;
using BigonApp.Business.Modules.BlogPostsModules.Queries.BlogPostsGetById;
using BigonApp.Business.Modules.CategoryModules.Queries.CategoryGetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BigonApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly IMediator _mediator;

        public BlogPostsController(IMediator mediator)
        {
            _mediator=mediator;
        }
        public async Task<IActionResult> Index(BlogPostsGetAllRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Create(CategoryGetAllRequest request)
        {
            var response = await _mediator.Send(request);
            ViewBag.Categories = new SelectList(response, "Id", "Name");

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
            var categories = await _mediator.Send(new CategoryGetAllRequest());
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
        [HttpPost]
        public async Task<IActionResult> Delete(BlogPostDeleteRequest request)
        {
            var response = await _mediator.Send(request);
            return PartialView("_Body",response);
        }

    }
}
