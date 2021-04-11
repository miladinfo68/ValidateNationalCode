

using System.ComponentModel.DataAnnotations;

public class IndexVM
{
    [Display(Name = "کــد استاد")]
    public string CodeOstad { get; set; }

    //=========================================
    [Display(Name = "کــد ملی های نا معتبر")]
    public string CodeMeli { get; set; }
    //=========================================

    [Display(Name = "نام پایگاه داده")]
    public string DbName { get; set; }
}
