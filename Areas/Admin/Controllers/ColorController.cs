using BigonApp.Business.Modules.ColorsModules.Commands.ColorsAddCommand;
using BigonApp.Business.Modules.ColorsModules.Commands.ColorsEditCommand;
using BigonApp.Business.Modules.ColorsModules.Commands.ColorsRemoveCommand;
using BigonApp.Business.Modules.ColorsModules.Queries.ColorsGet;
using BigonApp.Business.Modules.ColorsModules.Queries.ColorsGetAll;
using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly IMediator _mediator;

        public ColorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(ColorsGetAllRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ColorsAddRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(ColorsGetByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ColorsEditRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(ColorsGetByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }
        public async Task<IActionResult> Delete(ColorsRemoveRequest request)
        {
            var response = await _mediator.Send(request);
            return PartialView("_Body", response);
        }
    }
}
