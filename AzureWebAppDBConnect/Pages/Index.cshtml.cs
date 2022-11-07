using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AzureWebAppDBConnect.Models;
using AzureWebAppDBConnect.Services;

namespace AzureWebAppDBConnect.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;
        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products = productService.GetProducts();    
        }
    }
}