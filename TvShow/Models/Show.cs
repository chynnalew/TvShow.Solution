using System;
using System.Collections.Generic;

namespace TvShow.Models
{
  public class Show
  {
    public Show()
    {
      this.JoinGenres = new HashSet<ShowGenres>();
      this.JoinNetworks = new HashSet<ShowNetworks>();
    }
    public int ShowId {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public bool Completed {get; set;}

    public virtual ICollection<ShowGenres> JoinGenres {get;}
    public virtual ICollection<ShowNetworks> JoinNetworks {get;}
  }
}