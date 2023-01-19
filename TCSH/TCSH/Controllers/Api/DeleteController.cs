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

        public DeleteController(ICRUD<Clothe> ClotheRepo)
        {
            clotheRepo = ClotheRepo;
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
                clotheRepo.Delete(id);
                return Ok();
            }
        }

    }
}
