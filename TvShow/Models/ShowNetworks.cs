namespace TvShow.Models
{
  public class ShowNetworks
  {
    public int ShowNetworksId {get; set;}
    public int ShowId {get; set;}
    public int NetworkId {get; set;}
    public virtual Show Show {get; set;}
    public virtual Network Network {get; set;}
  }
}