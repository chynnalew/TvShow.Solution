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

    [HttpPost]
    public ActionResult Create(Network network)
    {
      _db.Networks.Add(network);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisNetwork = _db.Networks
        .Include(network => network.JoinEntities)
        .ThenInclude(join => join.Show)
        .FirstOrDefault(network => network.NetworkId == id);
      return View(thisNetwork);
    }

    public ActionResult AddShow(int id) 
    {
      var thisNetwork = _db.Networks
        .Include(network => network.JoinEntities)
        .ThenInclude(join => join.Show)
        .FirstOrDefault(network => network.NetworkId == id);
      ViewBag.ShowId = new SelectList(_db.Shows, "ShowId", "Title");
      return View(thisNetwork); 
    }

    [HttpPost]
    public ActionResult AddShow(Network network, int ShowId)
    {
      if(ShowId != 0 && !_db.ShowNetworks.Any( model => model.NetworkId == network.NetworkId && model.ShowId == ShowId))
      {
        _db.ShowNetworks.Add(new ShowNetworks() {ShowId = ShowId, NetworkId = network.NetworkId});
        _db.SaveChanges();
      }
      return RedirectToAction("AddShow");
    }
    
    public ActionResult Edit(int id)
    {
      var thisNetwork = _db.Networks.FirstOrDefault(network => network.NetworkId == id);
      return View(thisNetwork);
    }

    [HttpPost]
    public ActionResult Edit(Network network)
    {
      _db.Entry(network).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisNetwork = _db.Networks.FirstOrDefault(network => network.NetworkId == id);
      _db.Networks.Remove(thisNetwork);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteShow(int joinId, int id)
    {
      var joinEntry = _db.ShowNetworks.FirstOrDefault(entry => entry.ShowNetworksId == joinId);
      _db.ShowNetworks.Remove(joinEntry);
      _db.SaveChanges();
      var thisNetwork = _db.Networks.FirstOrDefault(network => network.NetworkId == id);
      return View("Details", thisNetwork);
    }
  }
}