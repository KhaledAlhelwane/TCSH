
using TCSH.Data;

namespace TCSH.Models.Repository
{
    public class TypeOfClotheRepository : ICRUD<TypeOfClothe>
    {
        private readonly ApplicationDbContext dB;

        public TypeOfClotheRepository(ApplicationDbContext DB)
        {
            dB = DB;
        }
        public void Add(TypeOfClothe entity)
        {
            dB.TypeOfClothe.Add(entity);
            dB.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = find(id);
            dB.TypeOfClothe.Remove(entity);
            dB.SaveChanges();
        }

        public TypeOfClothe find(int id)
        {
            return dB.TypeOfClothe.Find(id);
        }

        public List<TypeOfClothe> List()
        {
            return dB.TypeOfClothe.ToList();
        }

        public void Update(TypeOfClothe entity)
        {
            dB.TypeOfClothe.Update(entity);
            dB.SaveChanges();
        }
    }
}
