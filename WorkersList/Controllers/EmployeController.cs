using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkersList.Models;

namespace WorkersList.Controllers
{
    public class EmployeController : Controller
    {

        private static IList<Employe> employes = new List<Employe>()
        {
            new Employe(){ Id = 1, Name = "Jon", Surname = "Wick" },
            new Employe(){ Id = 2, Name = "Tom", Surname = "Cruse" },
            new Employe(){ Id = 3, Name = "Michael", Surname = "Nowak" },
            new Employe(){ Id = 4, Name = "Mark", Surname = "Womart" },
            new Employe(){ Id = 5, Name = "Jan", Surname = "Kowalski" },
        };

        // GET: Employe
        public ActionResult Index()
        {
            return View(employes);
        }

        // GET: Employe/Create
        public ActionResult Create()
        {
            return View(new Employe());
        }

        // POST: Employe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employe employeModel)
        {
            try
            {
                employeModel.Id = employes.Count + 1;
                employes.Add(employeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employes);
            }
        }

        // GET: Employe/Edit/5
        public ActionResult Edit(int id)
        {
            return View(employes.FirstOrDefault(x => x.Id == id));
        }

        // POST: Employe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employe employeModel)
        {
            try
            {
                Employe employe = employes.FirstOrDefault(x => x.Id == id);
                employe.Name = employeModel.Name;
                employe.Surname = employeModel.Surname;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employes);
            }
        }

        // GET: Employe/Delete/5
        public ActionResult Delete(int id)
        {
            return View(employes.FirstOrDefault(x => x.Id == id));
        }

        // POST: Employe/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employe employeModel)
        {
            try
            {
                Employe employe = employes.FirstOrDefault(x => x.Id == id);
                employes.Remove(employe);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employes);
            }
        }
    }
}
