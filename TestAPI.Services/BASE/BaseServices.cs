using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestAPI.IServices.BASE;
using TestAPI.IRepository.BASE;
using TestAPI.Repository.BASE ;
namespace TestAPI.Services.BASE
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> baseDal = new BaseRepository<TEntity>();
        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="model">博文实体类</param>
        /// <returns></returns>
        public async Task<int> Add(TEntity model)
        {
            //throw new NotImplementedException();
            return await baseDal.Add(model);
        }
        /// <summary>
        /// 根据实体删除一条数据
        /// </summary>
        /// <param name="model">博文实体类</param>
        /// <returns></returns>
        public async Task<bool> Delete(TEntity model)
        {
            //throw new NotImplementedException();
            return await baseDal.Delete(model);
        }
        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public async Task<bool> DeleteById(object id)
        {
            //throw new NotImplementedException();
            return await baseDal.DeleteById(id);
        }
        /// <summary>
        /// 删除指定ID集合的数据（批量删除）
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public async Task<bool> DeleteByIds(object[] ids)
        {
            //throw new NotImplementedException();
            return await baseDal.DeleteByIds(ids);
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query()
        {
            //throw new NotImplementedException();
            return await baseDal.Query();
        }
        /// <summary>
        /// 查村数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere)
        {
            // throw new NotImplementedException();
            return await baseDal.Query(strWhere);
        }
        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <param name="whereExpression">whereExpression</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            //throw new NotImplementedException();
            return await baseDal.Query(whereExpression);
        }
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds)
        {
            // throw new NotImplementedException();
            return await baseDal.Query(whereExpression,strOrderByFileds);
        }
        /// <summary>
        /// 查询一个列表
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderByExpression">排序字段，如name,asc,age,desc</param>
        /// <param name="isAsc"></param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            //throw new NotImplementedException();
            return await baseDal.Query(whereExpression,orderByExpression,isAsc);
        }
        /// <summary>
        /// 查询一个列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrderByFileds">排序字段，如name,asc,age,desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere, string strOrderByFileds)
        {
            //throw new NotImplementedException();
            return await baseDal.Query(strWhere, strOrderByFileds);
        }
        /// <summary>
        /// 查询前N条数据
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intTop">前N条</param>
        /// <param name="strOrderByFileds">排序字段，如name,asc,age,desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            //throw new NotImplementedException();
            return await baseDal.Query(whereExpression, strOrderByFileds);
        }
        /// <summary>
        /// 查询前N条数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="intTop">前</param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            //throw new NotImplementedException();
            return await baseDal.Query(strWhere, intTop, strOrderByFileds);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            //throw new NotImplementedException();
            return await baseDal.Query(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }

        public async Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            //throw new NotImplementedException();
            return await baseDal.Query(strWhere,intPageIndex,intPageSize,strOrderByFileds);
        }

        public async Task<TEntity> QueryByID(object objId)
        {
            //throw new NotImplementedException();
            return await baseDal.QueryByID(objId);
        }
        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="objId">id（必须指定主键特性[sugarColumn(IsPrimaryKey=true)]）,如果是联合主键，请使用where条件</param>
        /// <param name="blnUseCache"></param>
        /// <returns>数据实体</returns>
        public async Task<TEntity> QueryByID(object objId, bool blnUseCache = false)
        {
            //throw new NotImplementedException();
            return await baseDal.QueryByID(objId,blnUseCache);
        }
        /// <summary>
        /// 根据ID查询数据
        /// </summary>
        /// <param name="lstIds">id（必须指定主键特性[sugarColumn(IsPrimaryKey=true)]）,如果是联合主键，请使用where条件</param>
        /// <returns>数据实体列表</returns>
        public async Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            //throw new NotImplementedException();
            return await baseDal.QueryByIDs(lstIds);
        }

        public async Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            //throw new NotImplementedException();
            return await baseDal.QueryPage(whereExpression,intPageIndex,intPageSize,strOrderByFileds);
        }
        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="model">博文实体类</param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity model)
        {
            //throw new NotImplementedException();
            return await baseDal.Update(model);
        }

        public async Task<bool> Update(TEntity entity, string strWhere)
        {
            //throw new NotImplementedException();
            return await baseDal.Update(entity, strWhere);
        }

        public async Task<bool> Update(TEntity entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            //throw new NotImplementedException();
            return await baseDal.Update(entity, lstColumns,lstIgnoreColumns,strWhere);
        }
    }
}
