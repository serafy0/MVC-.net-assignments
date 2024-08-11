using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using task.Models;

namespace task.Controllers;

public class DrugController : Controller
{
    private readonly ILogger<DrugController> _logger;

    static List<Drug> drugs = new List<Drug>()
    {
        new Drug()
        {
            ID = 1,
            Name = "Ametoprine",
            ImagePath =
                "https://cdn.pixabay.com/photo/2012/12/21/10/06/addiction-71576_960_720.jpg",
            CompanyName = "PharmaTech Inc.",
            ManufactureDate = new DateTime(2023, 1, 10),
            ExpirationDate = new DateTime(2025, 1, 10)
        },
        new Drug()
        {
            ID = 2,
            Name = "Virosetin",
            ImagePath =
                "https://cdn.pixabay.com/photo/2016/12/18/12/42/medicines-1915621_960_720.jpg",
            CompanyName = "MedLife Ltd.",
            ManufactureDate = new DateTime(2023, 2, 20),
            ExpirationDate = new DateTime(2025, 2, 20)
        },
        new Drug()
        {
            ID = 3,
            Name = "Cardilox",
            ImagePath =
                "https://cdn.pixabay.com/photo/2012/12/21/10/06/addiction-71576_960_720.jpg",
            CompanyName = "HeartCare Pharma",
            ManufactureDate = new DateTime(2023, 3, 30),
            ExpirationDate = new DateTime(2025, 3, 30)
        },
        new Drug()
        {
            ID = 4,
            Name = "Neurozin",
            ImagePath =
                "https://cdn.pixabay.com/photo/2016/12/18/12/42/medicines-1915621_960_720.jpg",
            CompanyName = "NeuroHealth Inc.",
            ManufactureDate = new DateTime(2023, 4, 15),
            ExpirationDate = new DateTime(2025, 4, 15)
        },
        new Drug()
        {
            ID = 5,
            Name = "Gastroline",
            ImagePath =
                "https://cdn.pixabay.com/photo/2012/12/21/10/06/addiction-71576_960_720.jpg",
            CompanyName = "Digestive Solutions",
            ManufactureDate = new DateTime(2023, 5, 25),
            ExpirationDate = new DateTime(2025, 5, 25)
        },
        new Drug()
        {
            ID = 6,
            Name = "Dermasyl",
            ImagePath =
                "https://cdn.pixabay.com/photo/2016/12/18/12/42/medicines-1915621_960_720.jpg",
            CompanyName = "SkinCare Co.",
            ManufactureDate = new DateTime(2023, 6, 10),
            ExpirationDate = new DateTime(2025, 6, 10)
        }
    };

    public DrugController(ILogger<DrugController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ViewResult Index()
    {
        ViewBag.dd = drugs;

        return View(drugs);
    }

    public ViewResult ViewDetails(int id)
    {
        Drug d = drugs.FirstOrDefault(x => x.ID == id);

        ViewBag.dd = d;
        return View();
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        Drug drug = drugs.Find(x => x.ID == id);
        if (drug == null)
        {
            return NotFound();
        }
        return View(drug);
    }

    [HttpPost]
    public IActionResult Edit(Drug d)
    {
        Drug old = drugs.Find(dr => dr.ID == d.ID);
        old.Name = d.Name;
        old.ImagePath = d.ImagePath;
        old.CompanyName = d.CompanyName;

        old.ManufactureDate = d.ManufactureDate;
        old.ExpirationDate = d.ExpirationDate;

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Drug drug)
    {
        if (drugs.Any(dd => dd.ID == drug.ID))
        {
            return NotFound();
        }

        drugs.Add(drug);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        Drug drug = drugs.FirstOrDefault(d => d.ID == id);
        if (drug == null)
        {
            return NotFound();
        }
        drugs.Remove(drug);
        return RedirectToAction("Index");
    }
}
