using Core.Entities;
using Core.Interfaces;

namespace WebUI.ViewModels;

public class HomeViewModel
{
    
    public IEnumerable<SlideItem> SlideItems { get; set; } = null!;
    public IEnumerable<ShippingItem> ShippingItems { get; set; } = null!;
}
