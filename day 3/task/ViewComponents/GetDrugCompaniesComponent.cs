using Microsoft.AspNetCore.Mvc;
using task.Controllers;
using task.Models;

namespace task.ViewComponents
{
    public class GetDrugCompaniesComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<Drug> drugList = DrugController.drugs;
            List<string> companiesList = drugList.Select(d => d.CompanyName).Distinct().ToList();
            return View(companiesList);
        }

    }
}
