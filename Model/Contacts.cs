using System; 
using System.ComponentModel.DataAnnotations;

namespace Model
{
	public class Contacts
	{
   		     
      	/// <summary>
		/// 编号
        /// </summary>
       [Display(Name = "编号")]
       public int Id { get; set; }
		/// <summary>
		/// 姓名
        /// </summary>
       [Display(Name = "姓名")]
       public string UserName { get; set; }
		/// <summary>
		/// 手机号码
        /// </summary>
       [Display(Name = "手机号码")]
       public string Tel { get; set; }
		/// <summary>
		/// 固话
        /// </summary>
       [Display(Name = "固话")]
       public string Tel1 { get; set; }
		/// <summary>
		/// 地址
        /// </summary>
       [Display(Name = "地址")]
       public string Address { get; set; }
		   public decimal Price { get; set; }
	}
}

