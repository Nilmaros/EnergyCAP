using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyCAP.Models
{
    public class UsernameRepos
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public virtual List<Repos> Repos { get; set; }
    }
}
