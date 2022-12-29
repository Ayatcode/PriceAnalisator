using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels;

public class ForgotPasswordViewModel
{
    [Required,DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    

}
