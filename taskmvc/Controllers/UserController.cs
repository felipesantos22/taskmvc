using Microsoft.AspNetCore.Mvc;
using taskmvc.Models;
using taskmvc.Service;
using taskmvc.ViewModel.UserviewModel;


namespace taskmvc.Controllers
{
    public class UserController : Controller
    {

        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            var users = await _service.GetAll();
            return View(users.ToList());

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);

            }
            await _service.Create(user);
            return RedirectToAction(nameof(Index));

        }


        [HttpPost]
        public async Task<ActionResult> Update(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            await _service.Update(user);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> UpdateName(int id)
        {
            var user = await _service.GetById(id);

            if (user == null)
                return NotFound();

            var model = new UserEditViewModel
            {
                Id = user.Id,
                Name = user.Name
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateName(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.UpdateName(model.Id, model.Name);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _service.GetById(id);
            if (user == null)
                return NotFound();

            await _service.Delete(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
