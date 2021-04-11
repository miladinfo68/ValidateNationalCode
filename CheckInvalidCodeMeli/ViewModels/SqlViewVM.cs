
using System.ComponentModel.DataAnnotations;

public class SqlViewVM
{
    [Display(Name ="کــد استاد")]
    public string CodeOstad { get; set; }


    [Display(Name = "کــد ملی استاد")]
    public string IddMeli { get; set; }


    [Display(Name = "نام استاد")]
    public string Name { get; set; }


    [Display(Name = "نام خانوادگی استاد")]
    public string Family { get; set; }


    [Display(Name = "نام پایگاه داده")]
    public string DbName { get; set; }
}
