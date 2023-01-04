using System.ComponentModel.DataAnnotations;

namespace JuanProj.ViewModels;
public class ForgotPasswordViewModel
{
    [Required, DataType(DataType.EmailAddress)]
    public string? Email { get; set; }


}
