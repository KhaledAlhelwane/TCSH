using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TCSH.Models;
using TCSH.Models.Repository;

namespace TCSH.Controllers
{
    public class TypeOfClothesController : Controller
    {
        private readonly ICRUD<TypeOfClothe> typeOfClothRepo;

        public TypeOfClothesController(ICRUD<TypeOfClothe> TypeOfClothRepo)
        {
            typeOfClothRepo = TypeOfClothRepo;
        }
        // GET: TypeOfClothesController
        public ActionResult Index()
        {
            var Lista = typeOfClothRepo.List();
            if (Lista.Count() == 0)
            {
                ViewBag.success = "false";
                return View();
            }
            return View(Lista);
        }

        // GET: TypeOfClothesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TypeOfClothesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfClothesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypeOfClothe collection)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("TypeOfTitle", "There is aleady type with that name");
                    return View();
                }
                var list = typeOfClothRepo.List();
                if(list.Count()!=0)
                foreach(var x in list)
                {
                    if (x.TypeOfTitle == collection.TypeOfTitle)
                    {
                        ModelState.AddModelError("TypeOfTitle", "There is aleady type with that name");
                        return View();
                    }
                }
                typeOfClothRepo.Add(collection);
              return  RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeOfClothesController/Edit/5
        public ActionResult Edit(int id)
        {
            var type = typeOfClothRepo.find(id);
            return View(type);
        }

        // POST: TypeOfClothesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TypeOfClothe collection)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    ModelState.AddModelError("TypeOfTitle", "There is aleady type with that name");
                //    return View(collection);
                //}
                var list = typeOfClothRepo.List();
                if (list.Count() != 0)
                    foreach (var x in list)
                    {
                        if (x.TypeOfTitle == collection.TypeOfTitle)
                        {
                            ModelState.AddModelError("TypeOfTitle", "There is aleady type with that name");
                            return View();
                        }
                    }
                var newcollection = typeOfClothRepo.find(collection.TypeOfClotheId);
                newcollection.TypeOfTitle = collection.TypeOfTitle;
                typeOfClothRepo.Update(newcollection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeOfClothesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TypeOfClothesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
