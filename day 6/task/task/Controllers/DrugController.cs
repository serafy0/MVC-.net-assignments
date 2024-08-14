using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using task.Context;
using task.Models;

namespace task.Controllers
{
    public class DrugController : Controller
    {
        ITIContext _context;

        public DrugController(ITIContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Drugs.ToList());
        }

        public IActionResult ViewDetails(int id)
        {


            var drug = _context.Drugs.Include(d => d.Company).FirstOrDefault(d => d.ID == id); ;

            if (drug == null)
            {
                return NotFound();
            }

            return View(drug);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Create(Drug drug,string CompanyName)
        {
            
            var company = _context.Companies.FirstOrDefault(c => c.Name == CompanyName);
            if (company == null)
            {
                company = new Company { Name = CompanyName };
                            _context.Add(company);
            _context.SaveChanges();

            }
            if (drug.Company != null)
            {
                Company oldCompanyId = _context.Companies.FirstOrDefault(c => c.ID == drug.Company.ID);
                _context.Companies.Remove(oldCompanyId);
            }
            

            drug.Company = company;
            _context.Add(drug);

            _context.SaveChanges();

            


            return RedirectToAction("Index");


        }

        public IActionResult Edit(int id)
        {

            var drug = _context.Drugs.Include(d => d.Company).FirstOrDefault(d => d.ID == id); ;
            if (drug == null)
            {
                return NotFound();
            }
            var CompanyName = drug.Company?.Name;
            return View (drug);
        }

        [HttpPost]
        public IActionResult Edit(Drug drug,string CompanyName)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Name == CompanyName);
            if (company == null)
            {
                company = new Company { Name = CompanyName };
                _context.Add(company);
                _context.SaveChanges();

            }

            drug.Company = company;
            _context.Update(drug);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        

        [HttpPost]
        public  IActionResult Delete(int id)
        {
            var drug =  _context.Drugs.Find(id);
            if (drug == null)
            {
                return NotFound();
            }

           
            _context.Drugs.Remove(drug);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool DrugExists(int id)
        {
            return _context.Drugs.Any(e => e.ID == id);
        }
    }
}
