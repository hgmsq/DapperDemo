using System; 
using System.ComponentModel.DataAnnotations;

namespace Model
{
	public class Products
    {
   		     
      	/// <summary>
		/// 编号
        /// </summary>
       [Display(Name = "编号")]
       public int Id { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Display(Name = "商品名称")]
       public string ProductName { get; set; }
		/// <summary>
		/// 商品简介
        /// </summary>
       [Display(Name = "商品简介")]
       public string Instruction { get; set; }
        /// <summary>
        /// 商品分类
        /// </summary>
        [Display(Name = "商品分类")]
        public string CategoryId { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        [Display(Name = "商品价格")]
        public decimal Price { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [Display(Name = "创建日期")]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [Display(Name = "创建者")]
        public string  Creater { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        [Display(Name = "库存")]
        public  int Stock { get; set; }

    }
}

