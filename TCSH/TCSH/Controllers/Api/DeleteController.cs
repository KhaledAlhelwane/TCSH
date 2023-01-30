using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCSH.Models;
using TCSH.Models.Repository;

namespace TCSH.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly ICRUD<Clothe> clotheRepo;
        private readonly IWebHostEnvironment hosting_;

        public DeleteController(ICRUD<Clothe> ClotheRepo, IWebHostEnvironment hosting_)
        {
            clotheRepo = ClotheRepo;
            this.hosting_ = hosting_;
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var element = clotheRepo.find(id);
            if (element == null)
            {
                return NotFound();
            }
            else
            {
                var product = clotheRepo.find(id);
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                string uploads = Path.Combine(hosting_.WebRootPath, "ProductsImages");
                string fullpath = Path.Combine(uploads, product.ProductImageURL);
                System.IO.File.Delete(fullpath);
                if (product.ProductImageURL != product.ProductImageURLRsized)
                {
                    fullpath = Path.Combine(uploads, product.ProductImageURLRsized);
                    System.IO.File.Delete(fullpath);
                }
                clotheRepo.Delete(id);
                return Ok();
            }
        }

    }
}
