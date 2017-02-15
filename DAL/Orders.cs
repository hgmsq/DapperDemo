using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Model;
using Dapper;


namespace DAL
{
	public partial class Orders
    {
	     string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        #region 向数据库中添加一条记录 +int Insert(Model.Contacts model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(Model.Orders model)
        {
            #region SQL语句
            const string sql = @"
            INSERT INTO [dbo].[Orders] (
            	    [Number]            	   
            	    ,[ProductName]
,[Price]
,[UserId]
,[CreateDate]

            	   
            )
            VALUES (
            	    @Number
            	    ,@ProductName 
,@Price 
,@UserId 
,@CreateDate 

            );select @@IDENTITY";
            #endregion
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
               
                return connection.Execute(sql, model);
            }  
            
        }
        public int Insert(List<Model.Orders> model)
        {
            #region SQL语句
            const string sql = @"
            INSERT INTO [dbo].[Orders] (
            	    [Number]            	   
            	    ,[ProductName]
,[Price]
,[UserId]
,[CreateDate]

            	   
            )
            VALUES (
            	    @Number
            	    ,@ProductName 
,@Price 
,@UserId 
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
            const string sql = "DELETE FROM [dbo].[Orders] WHERE [Id] = @Id";
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
                 return connection.Execute(sql, new{ID=id});
            }  

        }
        
        public int Delete(List<Model.Orders> model)
        {
            const string sql = "DELETE FROM [dbo].[Orders] WHERE [Id] = @Id";
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
                 return connection.Execute(sql, model);
            }  

        }

        #endregion

        #region 根据主键ID更新一条记录 +int Update(Orders model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(Model.Orders model)
        {
            #region SQL语句
            const string sql = @"
            UPDATE [dbo].[Orders]
            SET 
            	    [Number] = @Number
,[ProductName] = @ProductName
,[Price] = @Price
,[UserId] = @UserId
,[CreateDate] = @CreateDate

            	    
                        WHERE [Id] = @Id";
            #endregion
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
               
                return connection.Execute(sql,model);
            }  

        }
        
        public int Update(List<Model.Orders> model)
        {
            #region SQL语句
            const string sql = @"
            UPDATE [dbo].[Orders]
            SET 
            	    [Number] = @Number
,[ProductName] = @ProductName
,[Price] = @Price
,[UserId] = @UserId
,[CreateDate] = @CreateDate

            	    
                        WHERE [Id] = @Id";
            #endregion
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
               
                return connection.Execute(sql,model);
            }  

        }
        #endregion

        #region 获取所有数据集合 +IEnumerable<Orders> GetAllList()
        /// <summary>
        /// 获取所有数据集合
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public IEnumerable<Model.Orders> GetAllList()
        {
            const string sql = "SELECT [Id], [Number],[ProductName],[Price],[UserId],[CreateDate] FROM [dbo].[Orders] ";
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
                return connection.Query<Model.Orders>(sql);
            }
        }
        #endregion      

        #region 根据条件获取集合 +Contacts QueryList(string wheres)
        /// <summary>
        /// 根据条件获取集合
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public IEnumerable<Model.Orders> QueryList(string wheres)
        {
            string sql = "SELECT [Id], [Number],[ProductName],[Price],[UserId],[CreateDate] FROM [dbo].[Orders] " + wheres;
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
                return connection.Query<Model.Orders>(sql);
            }
        }
        #endregion

        #region 查询单个模型实体 +Orders QuerySingle(int id)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public Model.Orders QuerySingle(int id)
        {
            const string sql = "SELECT TOP 1 [Id], [Number],[ProductName],[Price],[UserId],[CreateDate] FROM [dbo].[Orders] WHERE [Id] = @Id";
            using (SqlConnection  connection=new SqlConnection(connstr))
            {
                return connection.Query<Model.Orders>(sql,new{Id=id}).SingleOrDefault();
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
        public IEnumerable<Model.Orders> Page(int pageIndex, int pageSize)
	    {
            const string sql = @"select * from(select *,(ROW_NUMBER() over(order by id asc))as newId from Orders) as t 
                                 where t.newId between (@pageIndex-1)*@pageSize+1 and  @pageSize*@pageIndex";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var reader = connection.Query<Model.Orders>(sql, new { pageIndex = pageIndex, pageSize = pageSize });
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
            const string sql = "SELECT count(*) as id FROM [dbo].[Orders]";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                int list = Convert.ToInt32(connection.ExecuteScalar(sql));
                return list;
            }

        }

        #endregion



	}
}