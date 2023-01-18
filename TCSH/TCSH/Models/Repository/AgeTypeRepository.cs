
using TCSH.Data;

namespace TCSH.Models.Repository
{
    public class AgeTypeRepository : ICRUD<AgeType>
    {
        private readonly ApplicationDbContext dB;

        public AgeTypeRepository(ApplicationDbContext DB)
        {
            dB = DB;
        }
        public void Add(AgeType entity)
        {
            dB.AgeType.Add(entity);
            dB.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = find(id);
            dB.AgeType.Remove(entity);
            dB.SaveChanges();
        }

        public AgeType find(int id)
        {
            return dB.AgeType.Find(id);
        }

        public List<AgeType> List()
        {
            return dB.AgeType.ToList();
        }

        public void Update(AgeType entity)
        {
            dB.AgeType.Update(entity);
            dB.SaveChanges();
        }
    }
}
