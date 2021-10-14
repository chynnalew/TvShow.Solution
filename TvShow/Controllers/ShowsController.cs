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
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Show show)
    {
      _db.Shows.Add(show);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisShow = _db.Shows
        .Include(show => show.JoinGenres)
        .ThenInclude(join => join.Genre)
        .Include(show => show.JoinNetworks)
        .ThenInclude(join => join.Network)
        .FirstOrDefault(show => show.ShowId == id);
      return View(thisShow);
    }
  }
}