namespace TvShow.Models
{
  public class ShowGenres
  {
    public int ShowGenresId {get; set;}
    public int ShowId {get; set;}
    public int GenreId {get; set;}
    public virtual Show Show {get; set;}
    public virtual Genre Genre {get; set;}
  }
}