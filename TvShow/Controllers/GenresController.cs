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
  public class GenresController : Controller
  {
    private readonly TvShowContext _db;
    public GenresController(TvShowContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Genre> allGenres = _db.Genres.ToList();
      return View(allGenres);
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Genre genre)
    {
      _db.Genres.Add(genre);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisGenre = _db.Genres
        .Include(genre => genre.JoinEntities)
        .ThenInclude(join => join.Show)
        .FirstOrDefault(genre => genre.GenreId == id);
      return View(thisGenre);
    }
  }
}