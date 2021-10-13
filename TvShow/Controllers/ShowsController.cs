using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TvShow.Models;

namespace TvShow.Controllers
{
  public class ShowsController : Controller
  {
    private readonly TvShowContext _db;
    public ShowsController(TvShowContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Show> allShows = _db.Shows.ToList();
      return View(allShows);
    }
  }
}