using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TestAPI.IRepository;
using TestAPI.Repository.sugar;
using TestModel.Models;
using TestAPI.Repository.BASE;
namespace TestAPI.Repository
{
    public class AdvertisementRepository : BaseRepository<Advertisement>,IAdvertisementRepository
    {
        //private DbContext context;
        //private SqlSugarClient db;
        //private SimpleClient<Advertisement> entityDB;


        //internal SqlSugarClient Db
        //{
        //    get { return db; }
        //    private set { db = value; }
        //}
        //private DbContext Context
        //{
        //    get { return context; }
        //    set { context = value; }
        //}
        //public AdvertisementRepository()
        //{
        //    DbContext.Init(BaseDBConfig.ConnectionString);
        //    context = DbContext.GetDbContext();
        //    db = context.Db;
        //    entityDB = context.GetEntityDB<Advertisement>(db);
        //}


        //public int Add(Advertisement model)
        //{
        //    //throw new NotImplementedException();
        //    var i = db.Insertable(model).ExecuteReturnBigIdentity();//返回值为long类型，可选
        //    return i.ObjToInt();
        //}

        //public bool Delete(Advertisement model)
        //{
        //    //throw new NotImplementedException();
        //    var i = db.Deleteable(model).ExecuteCommand();
        //    return i > 0;
        //}

        //public List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression)
        //{
        //    //throw new NotImplementedException();
        //    return entityDB.GetList(whereExpression);
        //}

        //public int Sum(int i, int j)
        //{
        //    return i + j;
        //}

        //public bool Update(Advertisement model)
        //{
        //    //throw new NotImplementedException();
        //    var i = db.Updateable(model).ExecuteCommand();
        //    return i > 0;
    }
}

