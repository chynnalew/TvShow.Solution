using Microsoft.AspNetCore.Mvc;
using TvShow.Models;

namespace TvShow.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index() 
    { 
      return View(); 
    }
  }
}