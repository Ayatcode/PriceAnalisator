using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace WebUI.Areas.Admin.ViewModels.Slider;

public class SlideCreateVM:IEntity
{
   
    
    public int Id { get ; set ; }
    
    public IFormFile? Photo { get; set; }
    [MaxLength(100)]
    public string? Offer { get; set; }
    [Required,MaxLength(100)]
    public string? Title { get; set; }
    public string? Description { get; set; }
}
