using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using task.Models;

namespace task.Controllers;

public class DrugController : Controller
{
    private readonly ILogger<DrugController> _logger;

    List<Drug> drugs = new List<Drug>()
    {
        new Drug()
        {
            ID = 1,
            Name = "Ali",
            Details = "details about drug 1",
            ImagePath = "https://cdn.pixabay.com/photo/2012/12/21/10/06/addiction-71576_960_720.jpg"
        },
        new Drug()
        {
            ID = 2,
            Name = "Hamada",
            Details = "details about drug 2",
            ImagePath =
                "https://cdn.pixabay.com/photo/2016/12/18/12/42/medicines-1915621_960_720.jpg"
        }
    };

    public DrugController(ILogger<DrugController> logger)
    {
        _logger = logger;
    }

    public ViewResult GetAll()
    {
        ViewData["Drugs"] = drugs;

        return View();
    }

    public ViewResult ViewDetails(int id)
    {
        Drug d = drugs.FirstOrDefault(x => x.ID == id);
        ViewData["d"] = d;
        return View();
    }
}
