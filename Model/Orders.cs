using System; 
using System.ComponentModel.DataAnnotations;

namespace Model
{
	public class Orders
    {
   		     
      	/// <summary>
		/// 编号
        /// </summary>
       [Display(Name = "编号")]
       public int Id { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        [Display(Name = "商品编号")]
        public string Number { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Display(Name = "商品名称")]
       public string ProductName { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        [Display(Name = "商品价格")]
       public decimal  Price { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        [Display(Name = "客户")]
       public int UserId { get; set; }
		/// <summary>
		/// 创建日期
        /// </summary>
       [Display(Name = "创建日期")]
       public DateTime CreateDate { get; set; }
		
	}
}

