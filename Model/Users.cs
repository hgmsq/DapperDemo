using System; 
using System.ComponentModel.DataAnnotations;

namespace Model
{
	public class Users
	{
        //[Id], [UserName], [Password], [TrueName], [Role],[CreateDate]
        /// <summary>
        /// 编号
        /// </summary>
        [Display(Name = "编号")]
       public int Id { get; set; }
		/// <summary>
		/// 用户名称
        /// </summary>
       [Display(Name = "名称")]
       public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
       public string Password { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Display(Name = "真实姓名")]
        public string TrueName { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        [Display(Name = "用户角色")]
        public int Role { get; set; }      
        /// <summary>
        /// 创建日前
        /// </summary>
        [Display(Name = "创建日前")]
        public DateTime CreateDate { get; set; }


    }
}

