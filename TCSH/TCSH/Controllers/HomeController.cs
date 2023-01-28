using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TCSH.Models;
using TCSH.Models.Repository;
using TCSH.ViewModel;

namespace TCSH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICRUD<Clothe> clothRepo;
		private readonly ICRUD<AgeType> ageTypeRepo;
		private readonly ICRUD<TypeOfClothe> clothTypRepo;

		public HomeController(ILogger<HomeController> logger,ICRUD<Clothe>ClothRepo
            ,ICRUD<AgeType>AgeTypeRepo,ICRUD<TypeOfClothe> ClothTypRepo)
        {
            _logger = logger;
            clothRepo = ClothRepo;
			ageTypeRepo = AgeTypeRepo;
			clothTypRepo = ClothTypRepo;
		}

        public IActionResult Index()
        {
            var listOfClothes = clothRepo.List();
            if (listOfClothes.Count() == 0)
            {
                ViewBag.faild = "faild";
                return View();
            }
          var Orderdlist=  listOfClothes.OrderByDescending(x => x.ClotheId);
            var IndexList=new List<Clothe>();
            int counter = 0;
            foreach(var x in Orderdlist)
            {
                IndexList.Add(x);
                counter += 1;
                if (counter == 5)
                    break;
            }
            return View(IndexList);
        }


        public IActionResult Details(int id)
        {
            var Product = clothRepo.find(id);
            if (Product == null)
            {
                ViewBag.faild = "faild";
                return View();
            }

            var ProductDetails = new ProductDetailsViewModel
            {
                ClotheId = Product.ClotheId,
                AdditonalInformation = Product.AdditonalInformation,
                Market = Product.Market,
                Price = Product.Price,
                productImageUrl=Product.ProductImageURL,
                Title = Product.Title,
                CareInstruction = Product.CareInstruction,
                SaleRate = Product.SaleRate,
                MostPopular = Product.MostPopular,
                MatrialComposition = Product.MatrialComposition,
                AgeType=ageTypeRepo.find(Product.AgeTypeId).Type_Title,
                ClotheType=clothTypRepo.find(Product.TypeOfClotheId).TypeOfTitle
                
            };

            return View(ProductDetails);
        }

        public IActionResult AllProducts()
        {
            var lista = clothRepo.List();
            if (lista.Count() == 0) {
                ViewBag.faild = "faild";
                return View();
            }
            return View(lista);


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}