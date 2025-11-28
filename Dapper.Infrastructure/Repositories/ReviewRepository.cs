using Dapper.Core.Entities;
using Dapper.Core.Interfaces;

namespace Dapper.Infrastructure.Repositories;

public class ReviewRepository: IRepository<Reviews>
{
    public int Insert(Reviews obj)
    {
        throw new NotImplementedException();
    }

    public int Delete(int id)
    {
        throw new NotImplementedException();
    }

    public int Update(Reviews obj)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Reviews> GetAll()
    {
        throw new NotImplementedException();
    }

    public Reviews GetById(int id)
    {
        throw new NotImplementedException();
    }
}