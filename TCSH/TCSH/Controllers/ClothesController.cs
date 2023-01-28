using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TCSH.Models;
using TCSH.Models.Repository;
using TCSH.ViewModel;
using ImageMagick;

namespace TCSH.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClothesController : Controller
    {
        private readonly ICRUD<Clothe> clotheRepo;
        private readonly ICRUD<AgeType> ageTypeRepo;
        private readonly ICRUD<TypeOfClothe> typeOfClothRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment hosting_;

        // GET: ClothesController
        public ClothesController(ICRUD<Clothe> ClotheRepo, ICRUD<AgeType> AgeTypeRepo,
            ICRUD<TypeOfClothe> TypeOfClothRepo, UserManager<ApplicationUser> _UserManager,
              IWebHostEnvironment hosting_)
        {
            clotheRepo = ClotheRepo;
            ageTypeRepo = AgeTypeRepo;
            typeOfClothRepo = TypeOfClothRepo;
            userManager = _UserManager;
            this.hosting_ = hosting_;
            MagickNET.Initialize();
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

      

        // GET: ClothesController/Create
        public async Task<IActionResult> Create()
        {
            var user = await userManager.GetUserAsync(User);
            var listTypeOfAge = AgeList();
            var listTypeOfClothe = TypeClotheList();

            if (listTypeOfAge == null && listTypeOfClothe != null)
            {
                var myobject = new ClotheViewModel
                {
                    ApplicationUserId = user.Id,
                    TypeOfClotheLiat = listTypeOfClothe

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
            else if (listTypeOfAge == null && listTypeOfClothe == null)
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
                    AgeTypeList = listTypeOfAge

                };
                return View(myobject);
            }

        }

        // POST: ClothesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClotheViewModel collection)
        {
            try
            {
             

                if (!ModelState.IsValid)
                {
                    ViewBag.faild = "faild";
                    collection.AgeTypeList = AgeList();
                    collection.TypeOfClotheLiat = TypeClotheList();
                  
                    return View(collection);
                }
                string filenameIMa = string.Empty;
                if (collection.productImage != null)
                {
                    var listindex = clotheRepo.List();
                    if (listindex.Count() == 0)
                    {
                        filenameIMa = "1".ToString() + collection.productImage.FileName;
                    }
                    else
                    {
                        filenameIMa = (listindex.Last().ClotheId + 1).ToString() + collection.productImage.FileName;
                    }

                    string uploads = Path.Combine(hosting_.WebRootPath, "ProductsImages");
                    string fullpath = Path.Combine(uploads, filenameIMa);
                    collection.productImage.CopyTo(new FileStream(fullpath, FileMode.Create));
                    ImageResizing(uploads,filenameIMa);

                }
                var user =userManager.GetUserAsync(User).Result;
                var ClothProduct = new Clothe
                {
                    Title = collection.Title,
                    Market = collection.Market,
                    CareInstruction = collection.CareInstruction,
                    MatrialComposition = collection.MatrialComposition,
                    MostPopular = collection.MostPopular,
                    Price = collection.Price,
                    SaleRate = collection.SaleRate,
                      TypeOfClotheId = collection.TypeId,
                    AgeTypeId = collection.AgeId,
                    ApplicationUser = user,
                    AdditonalInformation = collection.AdditonalInformation,
                    ProductImageURL=filenameIMa,
                    ProductImageURLRsized= "Resized"+filenameIMa
                };
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
            var NewCollection = new EditClotheViewModel
            {
                AdditonalInformation = collection.AdditonalInformation,
                productImageUrl = collection.ProductImageURL,
                AgeId = collection.AgeTypeId,
                ApplicationUserId = collection.ApplicationUser.Id,
                CareInstruction = collection.CareInstruction,
                Market = collection.Market,
                MostPopular = collection.MostPopular,
                Price = collection.Price,
                SaleRate = collection.SaleRate,
                ClotheId = collection.ClotheId,
                Title = collection.Title,
                MatrialComposition = collection.MatrialComposition,
                TypeId = collection.TypeOfClotheId,
                AgeTypeList = listTypeOfAge,
                TypeOfClotheLiat = listTypeOfClothe
            };
            return View(NewCollection);
        }

        // POST: ClothesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditClotheViewModel collection)
        {
            try
            {
                var Mycollection = clotheRepo.find(collection.ClotheId);

                if (!ModelState.IsValid)
                {
                    ViewBag.faild = "faild";
                    collection.AgeTypeList = AgeList();
                    collection.TypeOfClotheLiat = TypeClotheList();
                    
                    return View(collection);
                }
                var UpdateOpject = clotheRepo.find(collection.ClotheId);
                UpdateOpject.CareInstruction = collection.CareInstruction;
                UpdateOpject.Market = collection.Market;
                UpdateOpject.MatrialComposition = collection.MatrialComposition;
                UpdateOpject.MostPopular = collection.MostPopular;
                UpdateOpject.Price = collection.Price;
                UpdateOpject.AdditonalInformation = collection.AdditonalInformation;
                UpdateOpject.Title = collection.Title;
                UpdateOpject.SaleRate = collection.SaleRate;
                UpdateOpject.TypeOfClotheId = collection.TypeId;
                UpdateOpject.AgeTypeId = collection.AgeId;
                 string filenameIMa;
                if (collection.productImage != null)
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();

                    string uploads = Path.Combine(hosting_.WebRootPath, "ProductsImages");
                    filenameIMa = collection.ClotheId.ToString() + collection.productImage.FileName;
                    string fullpath = Path.Combine(uploads, filenameIMa);
                    //delete Old File
                    string oldFileName = collection.productImageUrl;
                    string fullOldPath = Path.Combine(uploads, oldFileName);
                    if (fullpath != fullOldPath)
                    {
                        System.IO.File.Delete(fullOldPath);
                        System.IO.File.Delete(uploads+ "\\Resized"+collection.productImage);
                        //save new image
                        UpdateOpject.ProductImageURL = filenameIMa;
                        collection.productImage.CopyTo(new FileStream(fullpath, FileMode.Create));
                        ImageResizing(uploads, filenameIMa);
                        UpdateOpject.ProductImageURLRsized = "Resized" + filenameIMa;

                    }
                    clotheRepo.Update(UpdateOpject);

                   
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public List<AgeType> AgeList()
        {
            return ageTypeRepo.List();
        }
        public List<TypeOfClothe> TypeClotheList()
        {
            return typeOfClothRepo.List();
    
        }

        private void ImageResizing(string path,string filename)
        {var ImageUrl = Path.Combine(path, filename);
            using (var image = new MagickImage(ImageUrl))
            {
                try
                {
                    var size = new MagickGeometry(1000, 1000);
                    //// This will resize the image to a fixed size without maintaining the aspect ratio.
                    // Normally an image will be resized to fit inside the specified size.
                    size.IgnoreAspectRatio = false;


                    image.Resize(size);
                    image.Quality = 75;
                    //   Save the result
                    image.Write(path+"\\Resized"+filename);
                }catch(Exception e)
                {
                   
                }
                }

        }
}
}
