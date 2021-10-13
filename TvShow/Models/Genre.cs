using System.Collections.Generic;

namespace TvShow.Models
{
  public class Genre
  {
    public Genre()
    {
      this.JoinEntities = new HashSet<ShowGenres>();
    }
    public int GenreId {get; set;}
    public string GenreType {get; set;}

    public virtual ICollection<ShowGenres> JoinEntities {get;}
  }
}