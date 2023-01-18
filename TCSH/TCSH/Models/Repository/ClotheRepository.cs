
using Microsoft.EntityFrameworkCore;
using TCSH.Data;

namespace TCSH.Models.Repository
{
    public class ClotheRepository : ICRUD<Clothe>
    {
        private readonly ApplicationDbContext dB;

        public ClotheRepository(ApplicationDbContext DB)
        {
            dB = DB;
        }
        public void Add(Clothe entity)
        {
            dB.Clothe.Add(entity);
            dB.SaveChanges();
           
        }

        public void Delete(int id)
        {
            var entity = find(id);
            dB.Clothe.Remove(entity);
            dB.SaveChanges();
        }

        public Clothe find(int id)
        {
            return dB.Clothe.Include(a => a.ApplicationUser).SingleOrDefault(a=>a.ClotheId==id);
        }

        public List<Clothe> List()
        {
            return dB.Clothe.ToList();
        }

        public void Update(Clothe entity)
        {
            dB.Clothe.Update(entity);
            dB.SaveChanges();
        }
    }
}
