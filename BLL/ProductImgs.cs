using System.Collections.Generic;
using System.Linq;
using DAL;
using Model;

namespace BLL 
{
	public partial class ProductImgs
    {
   		     
		/// <summary>
        /// 数据库操作对象
        /// </summary>
        private DAL.ProductImgs _dao = new DAL.ProductImgs();

        #region 向数据库中添加一条记录 +int Insert(Model.ProductImgs model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(Model.ProductImgs model)
        {
            return _dao.Insert(model);
        }
        /// <summary>
        /// 向数据库中添加多条记录
        /// </summary>
        /// <param name="model">要添加的实体集合</param>
        /// <returns></returns>
        public int Insert(List<Model.ProductImgs> model)
        {
            return _dao.Insert(model);
        }
        #endregion

        #region 删除一条记录 +int Delete(int id)
        public int Delete(int id)
        {
            return _dao.Delete(id);
        }
        public int Delete(List<Model.ProductImgs> model)
        {
            return _dao.Delete(model);
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(Model.ProductImgs model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(Model.ProductImgs model)
        {
            return _dao.Update(model);
        }
        public int Update(List<Model.ProductImgs> model)
        {
            return _dao.Update(model);
        }
        #endregion

        #region 获取所有数据集合 +IEnumerable<Contacts> GetAllList()
        /// <summary>
        /// 获取所有数据集合
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public IEnumerable<Model.ProductImgs> GetAllList()
        {
            return _dao.GetAllList();
        }
        #endregion    
        #region 根据条件获取集合 +Contacts QueryList(string wheres)
        /// <summary>
        /// 根据条件获取集合
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public IEnumerable<Model.ProductImgs> QueryList(string wheres)
        {
            return _dao.QueryList(wheres);
        }
        #endregion

        #region 查询单个模型实体 +ProductImgs QuerySingle(int id)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public Model.ProductImgs QuerySingle(int id)
        {
            return _dao.QuerySingle(id);
        }
        #endregion
        
        #region 分页
		/// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Model.ProductImgs> Page(int pageIndex, int pageSize)
	    {
            return _dao.Page(pageIndex,pageSize);
	    }
 
	    #endregion

        
        
        
        #region 查询记录条数
        /// <summary>
        /// 查询记录条数
        /// </summary>
        /// <returns>记录条数</returns>
        public int Count()
        {
            
            return _dao.Count();
        }

        #endregion

  }

  
}