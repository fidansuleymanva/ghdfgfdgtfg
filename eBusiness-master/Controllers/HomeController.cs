
using eBusiness.Models;
using eBusiness.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eBusiness.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;

        public HomeController(DataContext dataContext) 
        {
            _dataContext = dataContext;
        
        }
      
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                Teams = _dataContext.Teams.ToList(),
            };
            return View(homeViewModel);
        }

       
    }
}