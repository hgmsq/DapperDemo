using System; 
using System.ComponentModel.DataAnnotations;

namespace Model
{
	public class ProductImgs
    {
   		     
      	/// <summary>
		/// 编号
        /// </summary>
       [Display(Name = "编号")]
       public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Display(Name = "标题")]
       public string Title { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        [Display(Name = "商品Id")]
       public string PorductId { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        [Display(Name = "文件路径")]
       public string FilePath { get; set; }
		/// <summary>
		/// 创建日期
        /// </summary>
       [Display(Name = "创建日期")]
       public DateTime CreateDate { get; set; }
		
	}
}

