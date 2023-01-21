using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCSH.Models;
using TCSH.Models.Repository;

namespace TCSH.Controllers
{
    public class TypeOfAgesController : Controller
    {
        private readonly ICRUD<AgeType> ageTypeRepo;

        public TypeOfAgesController(ICRUD<AgeType> AgeTypeRepo)
        {
            ageTypeRepo = AgeTypeRepo;
        }
        // GET: TypeOfAgesController
        public ActionResult Index()
        {
            var list = ageTypeRepo.List();
            if (list.Count() == 0)
            {
                ViewBag.success = "false";
                return View();
            }

            return View(list);
        }

      
        // GET: TypeOfAgesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfAgesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgeType collection)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("Error","you have to reach all requirments");
                    return View();
                }
                var list = ageTypeRepo.List();
                foreach(var x in list)
                {
                    if(x.Type_Title==collection.Type_Title)
                    {
                        ViewBag.failedWithTitle = "failed";
                        return View(collection);
                    }
                    
                }
                ageTypeRepo.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeOfAgesController/Edit/5
        public ActionResult Edit(int id)
        {
            var ageType = ageTypeRepo.find(id);
            return View(ageType);
        }

        // POST: TypeOfAgesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AgeType collection)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    ViewBag.failed = "failed";
                //    return View(collection);
                //}
                var list = ageTypeRepo.List();
                foreach (var x in list)
                {
                    if (x.Type_Title == collection.Type_Title)
                    {
                        ViewBag.failedWithTitle = "failed";
                        return View(collection);
                    }

                }
                var UpdateOpject = ageTypeRepo.find(collection.AgeTypeId);
                UpdateOpject.Type_Title = collection.Type_Title;
                ageTypeRepo.Update(UpdateOpject);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypeOfAgesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TypeOfAgesController/Delete/5
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
