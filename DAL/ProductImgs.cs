using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Model;
using Dapper;


namespace DAL
{
	public partial class ProductImgs
	{
	     string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        #region 向数据库中添加一条记录 +int Insert(Model.ProductImgs model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(Model.ProductImgs model)
        {
            #region SQL语句
            const string sql = @"
            INSERT INTO [dbo].[ProductImgs] (
            	    [Title]
            	    ,[PorductId]
            	    ,[FilePath]
            	    ,[CreateDate]
            )
            VALUES (
            	    @Title
            	    ,@PorductId
            	    ,@FilePath
            	    ,@CreateDate
            );select @@IDENTITY";
            #endregion
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
               
                return connection.Execute(sql, model);
            }  
            
        }
        public int Insert(List<Model.ProductImgs> model)
        {
            #region SQL语句
            const string sql = @"
            INSERT INTO [dbo].[ProductImgs] (
            	    [Title]
            	    ,[PorductId]
            	    ,[FilePath]
            	    ,[CreateDate]
            )
            VALUES (
            	    @Title
            	    ,@PorductId
            	    ,@FilePath
            	    ,@CreateDate
            );select @@IDENTITY";
            #endregion
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
               
                return connection.Execute(sql, model);
            }  
            
        }

        #endregion

        #region 删除一条记录 +int Delete(int id)
        public int Delete(int id)
        {
            const string sql = "DELETE FROM [dbo].[ProductImgs] WHERE [Id] = @Id";
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
                 return connection.Execute(sql, new{ID=id});
            }  

        }
        
        public int Delete(List<Model.ProductImgs> model)
        {
            const string sql = "DELETE FROM [dbo].[ProductImgs] WHERE [Id] = @Id";
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
                 return connection.Execute(sql, model);
            }  

        }

        #endregion

        #region 根据主键ID更新一条记录 +int Update(ProductImgs model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(Model.ProductImgs model)
        {
            #region SQL语句
            const string sql = @"
            UPDATE [dbo].[ProductImgs]
            SET 
            	    [Title] = @Title
            	    ,[PorductId] = @PorductId
            	    ,[FilePath] = @FilePath
            	    ,[CreateDate] = @CreateDate                  
                        WHERE [Id] = @Id";
            #endregion
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
               
                return connection.Execute(sql,model);
            }  

        }
        
        public int Update(List<Model.ProductImgs> model)
        {
            #region SQL语句
            const string sql = @"
            UPDATE [dbo].[ProductImgs]
            SET 
            	    [Title] = @Title
            	    ,[PorductId] = @PorductId
            	    ,[FilePath] = @FilePath
            	    ,[CreateDate] = @CreateDate                  
                        WHERE [Id] = @Id";
            #endregion
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
               
                return connection.Execute(sql,model);
            }  

        }
        #endregion

        #region 获取所有数据集合 +IEnumerable<ProductImgs> GetAllList()
        /// <summary>
        /// 获取所有数据集合
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public IEnumerable<Model.ProductImgs> GetAllList()
        {
            const string sql = "SELECT [Id], [Title], [PorductId], [FilePath], [CreateDate] FROM [dbo].[ProductImgs] ";
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
                return connection.Query<Model.ProductImgs>(sql);
            }
        }
        #endregion      

        #region 根据条件获取集合 +ProductImgs QueryList(string wheres)
        /// <summary>
        /// 根据条件获取集合
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public IEnumerable<Model.ProductImgs> QueryList(string wheres)
        {
            string sql = "SELECT [Id], [Title], [PorductId], [FilePath], [CreateDate] FROM [dbo].[ProductImgs] " + wheres;
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
                return connection.Query<Model.ProductImgs>(sql);
            }
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
            const string sql = "SELECT TOP 1 [Id], [Title], [PorductId], [FilePath], [CreateDate] FROM [dbo].[ProductImgs] WHERE [Id] = @Id";
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
                return connection.Query<Model.ProductImgs>(sql,new{Id=id}).SingleOrDefault();
            }
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
            const string sql = @"select * from(select *,(ROW_NUMBER() over(order by id asc))as newId from ProductImgs) as t 
                                 where t.newId between (@pageIndex-1)*@pageSize+1 and  @pageSize*@pageIndex";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var reader = connection.Query<Model.ProductImgs>(sql, new { pageIndex = pageIndex, pageSize = pageSize });
                return reader;
            }

	    }
 
	    #endregion

        
        #region 查询记录条数
        /// <summary>
        /// 查询记录条数
        /// </summary>
        /// <returns>记录条数</returns>
        public int Count()
        {
            const string sql = "SELECT count(*) as id FROM [dbo].[ProductImgs]";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                int list = Convert.ToInt32(connection.ExecuteScalar(sql));
                return list;
            }

        }

        #endregion



	}
}