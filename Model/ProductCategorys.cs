using System; 
using System.ComponentModel.DataAnnotations;

namespace Model
{
	public class ProductCategorys
    {
   		     
      	/// <summary>
		/// 编号
        /// </summary>
       [Display(Name = "编号")]
       public int Id { get; set; }
		/// <summary>
		/// 名称
        /// </summary>
       [Display(Name = "名称")]
       public string Name { get; set; }

	}
}

