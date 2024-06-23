using BigonApp.Business.Modules.CategoryModules.Commands.CategoryAdd;
using BigonApp.Business.Modules.CategoryModules.Commands.CategoryDelete;
using BigonApp.Business.Modules.CategoryModules.Commands.CategoryUpdate;
using BigonApp.Business.Modules.CategoryModules.Queries.CategoryGetAll;
using BigonApp.Business.Modules.CategoryModules.Queries.CategoryGetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BigonApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator=mediator;
        }
        public async Task<IActionResult> Index(CategoryGetAllRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Create()
        {
            var response = await _mediator.Send(new CategoryGetAllRequest());
            ViewBag.Categories = new SelectList(response, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddRequest request)
        {
            var response = await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(CategoryGetByIdRequest request)
        {
            var categories = await _mediator.Send(new CategoryGetAllRequest());
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            var response = await _mediator.Send(request);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(CategoryGetByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDeleteRequest request)
        {
            var response = await _mediator.Send(request);
            return PartialView("_Body", response);
        }
    }
}
