namespace taskmvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using taskmvc.Models;
using taskmvc.Service;

public class TaskController : Controller
{
    private readonly TaskService _service;

    public TaskController(TaskService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var tasks = _service.GetAll();
        return View(tasks);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        if (!ModelState.IsValid)
            return View(task);

        _service.Create(task);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var task = _service.GetById(id);

        if (task == null)
            return NotFound();

        return View(task);
    }

    [HttpPost]
    public IActionResult Edit(TaskItem task)
    {
        if (!ModelState.IsValid)
            return View(task);

        _service.Update(task);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var task = _service.GetById(id);

        if (task == null)
            return NotFound();

        _service.Delete(id);

        return RedirectToAction(nameof(Index));
    }

}