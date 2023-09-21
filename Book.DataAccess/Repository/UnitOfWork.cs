using Book.DataAccess.Data;
using Book.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IMoviesRepository Movies { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Movies = new MoviesRepository(_db);

        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
