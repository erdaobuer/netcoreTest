using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestAPI.IRepository.BASE;
using TestAPI.Repository.sugar;

namespace TestAPI.Repository.BASE
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private DbContext context;
        private SqlSugarClient db;
        private SimpleClient<TEntity> entityDB;


        internal SqlSugarClient Db
        {
            get { return db; }
            private set { db = value; }
        }
        private DbContext Context
        {
            get { return context; }
            set { context = value; }
        }
        internal SimpleClient<TEntity> EntityDB
        {
            get { return entityDB; }
            private set { entityDB = value; }
        }
        public BaseRepository()
        {
            DbContext.Init(BaseDBConfig.ConnectionString);
            context = DbContext.GetDbContext();
            db = context.Db;
            entityDB = context.GetEntityDB<TEntity>(db);
        }


        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        public async Task<int> Add(TEntity model)
        {
            //throw new NotImplementedException();
            var i = await Task.Run(() =>db.Insertable(model).ExecuteReturnBigIdentity());
            return (int)i;
        }

        /// <summary>
        /// 根据实体删除一条数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        public async Task<bool> Delete(TEntity model)
        {
            //throw new NotImplementedException();
            var i = await Task.Run(() => db.Deleteable(model).ExecuteCommand());
            return i > 0;
        }
        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public async Task<bool> DeleteById(object id)
        {
            //throw new NotImplementedException();
            return await Task.Run(() => db.Deleteable<TEntity>(id).ExecuteCommand())>0;
        }
        /// <summary>
        /// 删除指定ID集合的数据（批量删除）
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public async Task<bool> DeleteByIds(object[] ids)
        {
            //throw new NotImplementedException();
            return await Task.Run(() => db.Deleteable<TEntity>().In(ids).ExecuteCommand())>0;
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query()
        {
            //throw new NotImplementedException();
            return await Task.Run(() => entityDB.GetList());
        }

        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere)
        {
            //throw new NotImplementedException();
            return await Task.Run(() => db.Queryable<TEntity>().WhereIF(!string.IsNullOrEmpty(strWhere),strWhere).ToList());
        }
        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <param name="whereExpression">whereExpression</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            //throw new NotImplementedException();
            return await Task.Run(() => entityDB.GetList(whereExpression));
        }
        /// <summary>
        /// 查询一个列表
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds)
        {
            //throw new NotImplementedException();
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds),strOrderByFileds)
            .WhereIF(whereExpression!=null,whereExpression).ToList());
        }
        /// <summary>
        /// 查询一个列表
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            //throw new NotImplementedException();
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(orderByExpression!=null,orderByExpression,isAsc?OrderByType.Asc:OrderByType.Desc)
            .WhereIF(whereExpression!=null,whereExpression).ToList());
        }
        /// <summary>
        /// 查询一个列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere, string strOrderByFileds)
        {
            //throw new NotImplementedException();
            return await Task.Run(() =>db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds),
                strOrderByFileds).WhereIF(!string.IsNullOrEmpty(strWhere),strWhere).ToList());
        }
        /// <summary>
        /// 查询前N条数据
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intTop">前N条</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            //throw new NotImplementedException();
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds),
                strOrderByFileds).WhereIF(whereExpression!=null,whereExpression).Take(intTop).ToList());
        }

        /// <summary>
        /// 查询前N条数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="intTop">前N条</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            //throw new NotImplementedException();
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds),
                strOrderByFileds).WhereIF(!string.IsNullOrEmpty(strWhere),strWhere).Take(intTop).ToList());
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            //throw new NotImplementedException();
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds),
               strOrderByFileds).WhereIF(whereExpression != null, whereExpression).ToPageList(intPageIndex,intPageSize));
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns></returns>
        public async Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            //throw new NotImplementedException();
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds),
                strOrderByFileds).WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).ToPageList(intPageIndex,intPageSize));
        }

        public async Task<TEntity> QueryByID(object objId)
        {
            //throw new NotImplementedException();
            return await Task.Run(() =>db.Queryable<TEntity>().InSingle(objId));
        }
        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="objId">id</param>
        /// <param name="blnUseCache">是否使用缓存</param>
        /// <returns>数据实体</returns>
        public async Task<TEntity> QueryByID(object objId, bool blnUseCache = false)
        {
            //throw new NotImplementedException();
            return await Task.Run(() =>db.Queryable<TEntity>().WithCacheIF(blnUseCache).InSingle(objId));
        }
        /// <summary>
        /// 根据id查询数据
        /// </summary>
        /// <param name="lstIds"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            //throw new NotImplementedException();
            return await Task.Run(() => db.Queryable<TEntity>().In(lstIds).ToList());
        }
        public async Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            //throw new NotImplementedException();
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds),strOrderByFileds)
            .WhereIF(whereExpression!=null,whereExpression)
            .ToPageList(intPageIndex,intPageSize));
        }
        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity model)
        {
            //throw new NotImplementedException();
            //这种方式以主键为条件
            var i = await Task.Run(() =>db.Updateable(model).ExecuteCommand());
            return i > 0;
        }

        public async Task<bool> Update(TEntity entity, string strWhere)
        {
            //throw new NotImplementedException();
            return await Task.Run(() =>db.Updateable(entity).Where(strWhere).ExecuteCommand()>0);
        }

        [Obsolete]
        public async Task<bool> Update(TEntity entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            //throw new NotImplementedException();
            IUpdateable<TEntity> up = await Task.Run(() =>db.Updateable(entity));
            if (lstIgnoreColumns!=null&&lstIgnoreColumns.Count>0)
            {
                up = await Task.Run(() => up.IgnoreColumns(it => lstIgnoreColumns.Contains(it)));
            }
            if (lstColumns!=null&&lstColumns.Count>0)
            {
                up = await Task.Run(() => up.UpdateColumns(it => lstColumns.Contains(it)));
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                up = await Task.Run(() => up.WhereColumns(strWhere));
            }
            return await Task.Run(() => up.ExecuteCommand())>0;
        }
    }
}
