using System;
using System.Collections.Generic;

namespace TvShow.Models
{
  public class Show
  {
    public Show()
    {
      this.JoinEntities = new HashSet<ShowGenres>();
    }
    public int ShowId {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public bool Completed {get; set;}

    public virtual ICollection<ShowGenres> JoinEntities {get;}
  }
}