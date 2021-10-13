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
  }
}