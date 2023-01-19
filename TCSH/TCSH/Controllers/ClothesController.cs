using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TCSH.Models;
using TCSH.Models.Repository;
using TCSH.ViewModel;

namespace TCSH.Controllers
{
    public class ClothesController : Controller
    {
        private readonly ICRUD<Clothe> clotheRepo;
        private readonly ICRUD<AgeType> ageTypeRepo;
        private readonly ICRUD<TypeOfClothe> typeOfClothRepo;
        private readonly UserManager<ApplicationUser> userManager;

        // GET: ClothesController
        public ClothesController(ICRUD<Clothe> ClotheRepo, ICRUD<AgeType> AgeTypeRepo,
            ICRUD<TypeOfClothe> TypeOfClothRepo,UserManager<ApplicationUser>_UserManager)
        {
            clotheRepo = ClotheRepo;
            ageTypeRepo = AgeTypeRepo;
            typeOfClothRepo = TypeOfClothRepo;
            userManager = _UserManager;
        }
        public ActionResult Index()
        {
            var listOfClothes = clotheRepo.List();
            if (listOfClothes.Count() == 0)
            {
                ViewBag.success = "false";
                return View();
            }
            return View(listOfClothes);
        }

        // GET: ClothesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClothesController/Create
        public async Task<IActionResult>  Create()
        {
          var user= await userManager.GetUserAsync(User);
            var listTypeOfAge = ageTypeRepo.List();
            var listTypeOfClothe = typeOfClothRepo.List();
          
            if (listTypeOfAge == null && listTypeOfClothe != null)
            {
                var myobject = new ClotheViewModel
                {
                    ApplicationUserId = user.Id,
                    TypeOfClotheLiat=listTypeOfClothe

                }; return View();

            }
           else if (listTypeOfAge != null && listTypeOfClothe == null)
            {
                var myobject = new ClotheViewModel
                {
                    ApplicationUserId = user.Id,
                    AgeTypeList = listTypeOfAge


                }; return View();
            }
            else if(listTypeOfAge == null && listTypeOfClothe == null)
            {
                var myobject = new ClotheViewModel
                {
                    ApplicationUserId = user.Id
                };
                return View();
            }
            else
            {
                var myobject = new ClotheViewModel
                {
                    ApplicationUserId = user.Id,
                    TypeOfClotheLiat = listTypeOfClothe,
                    AgeTypeList=listTypeOfAge

                };
                return View(myobject);
            }
            
        }

        // POST: ClothesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Create(ClotheViewModel collection)
        {
            try
            {
               
                var user = userManager.GetUserAsync(User).Result;
               
                var ClothProduct = new Clothe
                {
                    Title = collection.Title,
                    Market = collection.Market,
                    CareInstruction = collection.CareInstruction,
                    MatrialComposition = collection.MatrialComposition,
                    MostPopular = collection.MostPopular,
                    Price = collection.Price,
                    SaleRate = collection.SaleRate,
                    Size = collection.Size,
                    TypeOfClotheId = collection.TypeId,
                    AgeTypeId = collection.AgeId,
                    ApplicationUser = user,
                    AdditonalInformation = collection.AdditonalInformation
                  
                    };
                if (Request.Form.Files.Count !=0)
                {
                    var file = Request.Form.Files.FirstOrDefault();
                    //check file size and extension
                    using (var datestream = new MemoryStream())
                    {
                      await  file.CopyToAsync(datestream);
                        ClothProduct.productImage = datestream.ToArray();
                    }
                   
                }
                clotheRepo.Add(ClothProduct);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClothesController/Edit/5
        public ActionResult Edit(int id)
        {
            var collection = clotheRepo.find(id);
            var listTypeOfAge = ageTypeRepo.List();
            var listTypeOfClothe = typeOfClothRepo.List();
            var NewCollection = new ClotheViewModel
            {
                AdditonalInformation = collection.AdditonalInformation,
                productImage = collection.productImage,
                AgeId = collection.AgeTypeId,
                ApplicationUserId = collection.ApplicationUser.Id,
                CareInstruction=collection.CareInstruction,
                Market=collection.Market,
                MostPopular=collection.MostPopular,
                Price=collection.Price,
                SaleRate=collection.SaleRate,
                ClotheId=collection.ClotheId,
                Title=collection.Title,
                Size=collection.Size,
                MatrialComposition=collection.MatrialComposition,
                TypeId=collection.TypeOfClotheId,
                AgeTypeList=listTypeOfAge,
                TypeOfClotheLiat=listTypeOfClothe
            };
            return View(NewCollection);
        }

        // POST: ClothesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ClotheViewModel collection)
        {
            try
            {
                var UpdateOpject =clotheRepo.find(collection.ClotheId);
                UpdateOpject.CareInstruction = collection.CareInstruction;
                UpdateOpject.Market = collection.Market;
                UpdateOpject.MatrialComposition = collection.MatrialComposition;
                UpdateOpject.MostPopular = collection.MostPopular;
                UpdateOpject.Price = collection.Price;
                UpdateOpject.Size = collection.Size;
                UpdateOpject.Title = collection.Title;
                UpdateOpject.SaleRate = collection.SaleRate;
                UpdateOpject.TypeOfClotheId = collection.TypeId;
                UpdateOpject.AgeTypeId = collection.AgeId;
                if (Request.Form.Files.Count != 0)
                {
                    var file = Request.Form.Files.FirstOrDefault();
                    //check file size and extension
                    using (var datestream = new MemoryStream())
                    {
                        await file.CopyToAsync(datestream);
                        UpdateOpject.productImage = datestream.ToArray();
                    }

                }
                clotheRepo.Update(UpdateOpject);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      
    }
}
