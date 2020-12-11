using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TestModel.Models;
namespace TestAPI.IRepository
{
   public interface IAdvertisementRepository:BASE.IBaseRepository<Advertisement>
    {
        //int Sum(int i,int j);

        //CRUD
        //int Add(Advertisement model);
        //bool Delete(Advertisement model);
        //bool Update(Advertisement model);
        //List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression);
    }
}
