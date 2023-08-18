using Ardalis.Specification.EntityFrameworkCore;
using EntityFrameworkTest.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Data
{
    public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        private DbContext _context;

        public Repository(IUnitOfWork unitOfWork)
            : base(unitOfWork.DbContext, new SpecificationEvaluator())
        {
            _context = unitOfWork.DbContext;
        }

        public IQueryable<T> Query
        {
            get { return _context.Set<T>().AsQueryable(); }
            set { Query = value; }
        }
    }
}
