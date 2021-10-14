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

    public ActionResult AddGenre(int id) 
    {
      var thisShow = _db.Shows
        .Include(show => show.JoinGenres)
        .ThenInclude(join => join.Genre)
        .FirstOrDefault(show => show.ShowId == id);
      ViewBag.GenreId = new SelectList(_db.Genres,"GenreId", "GenreType");
      return View(thisShow);
    }

    [HttpPost]
    public ActionResult AddGenre(Show show, int GenreId)
    {
      Console.WriteLine(GenreId);
      Console.WriteLine(show.ShowId);
      if(GenreId != 0 && !_db.ShowGenres.Any( model => model.ShowId == show.ShowId && model.GenreId == GenreId))
      {
        _db.ShowGenres.Add( new ShowGenres() {GenreId = GenreId, ShowId = show.ShowId});
        _db.SaveChanges();
      }
      return RedirectToAction("AddGenre");
    }

    public ActionResult AddNetwork(int id) 
    {
      var thisShow = _db.Shows
        .Include(show => show.JoinNetworks)
        .ThenInclude(join => join.Network)
        .FirstOrDefault(show => show.ShowId == id);
      ViewBag.NetworkId = new SelectList(_db.Networks, "NetworkId", "NetworkName");
      return View(thisShow);
    }

    [HttpPost]
    public ActionResult AddNetwork(Show show, int NetworkId)
    {
      if(NetworkId != 0 && !_db.ShowNetworks.Any( model => model.ShowId == show.ShowId &&model.NetworkId == NetworkId))
      {
        _db.ShowNetworks.Add( new ShowNetworks() {NetworkId = NetworkId, ShowId = show.ShowId});
        _db.SaveChanges();
      }
      return RedirectToAction("AddNetwork");
    }
  }
}