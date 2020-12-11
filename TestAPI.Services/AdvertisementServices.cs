using System;
using System.Collections.Generic;
using System.Text;
using TestAPI.IServices;
using TestAPI.IRepository;
using TestAPI.Repository;
using TestModel.Models;
using System.Linq.Expressions;

namespace TestAPI.Services
{
   public class AdvertisementServices:BASE.BaseServices<Advertisement>,IAdvertisementServices
    {
        //IAdvertisementRepository dal = new AdvertisementRepository();

        //public int Add(Advertisement model)
        //{
        //    // throw new NotImplementedException();
        //    return dal.Add(model);
        //}

        //public bool Delete(Advertisement model)
        //{
        //    //throw new NotImplementedException();
        //    return dal.Delete(model);
        //}

        //public List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression)
        //{
        //    //throw new NotImplementedException();
        //    return dal.Query(whereExpression);
        //}

        //public int Sum(int i,int j)
        //{
        //    return dal.Sum(i,j);
        //}

        //public bool Update(Advertisement model)
        //{
        //    //throw new NotImplementedException();
        //    return dal.Update(model);
        //}
    }
}
