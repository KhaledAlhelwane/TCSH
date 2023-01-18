using TCSH.Data;

namespace TCSH.Models.Repository
{
    public class AddtionalPictureRepository : ICRUD<AddtionalPicture>
    {
        private readonly ApplicationDbContext db;

        public AddtionalPictureRepository(ApplicationDbContext Db)
        {
            db = Db;
        }
        public void Add(AddtionalPicture entity)
        {
            db.AddtionalPicture.Add(entity);
            db.SaveChanges();
           
        }

        public void Delete(int id)
        {
            var entity = find(id);
            db.AddtionalPicture.Remove(entity);
            db.SaveChanges();
        }

        public AddtionalPicture find(int id)
        {
            return db.AddtionalPicture.Find(id);
        }

        public List<AddtionalPicture> List()
        {
            return db.AddtionalPicture.ToList();
        }

        public void Update(AddtionalPicture entity)
        {
            db.AddtionalPicture.Update(entity);
            db.SaveChanges();
        }
    }
}
