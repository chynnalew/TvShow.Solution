using System.Collections.Generic;

namespace TvShow.Models
{
  public class Network
  {
    public Network()
    {
      this.JoinEntities = new HashSet<ShowNetworks>();
    }
    public int NetworkId {get; set;}
    public string NetworkName {get; set;}

    public virtual ICollection<ShowNetworks> JoinEntities {get;}
  }
}