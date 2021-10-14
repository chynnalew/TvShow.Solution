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
  public class NetworksController : Controller
  {
    private readonly TvShowContext _db;
    public NetworksController(TvShowContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Network> allNetworks = _db.Networks.ToList();
      return View(allNetworks);
    }

    public ActionResult Create()
    {
      return View();
    }
  }
}