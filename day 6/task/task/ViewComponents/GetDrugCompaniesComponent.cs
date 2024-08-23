using Microsoft.AspNetCore.Mvc;
using task.Context;
using task.Controllers;
using task.Models;

namespace task.Components
{
    public class GetDrugCompaniesComponent : ViewComponent
    {
        ITIContext _context;


        public GetDrugCompaniesComponent(ITIContext context)
        {
            _context = context;

        }
        public IViewComponentResult Invoke(string selectedCompanyName)
        {
            // List<int?> companiesList = _context.Drugs.ToList().Select(d => d.CompanyID).Distinct().ToList();
            List<string> companiesList = _context.Companies.Select(c => c.Name).Distinct().ToList();
            ViewBag.SelectedCompanyName = selectedCompanyName;
            return View(companiesList);
        }

    }
}
