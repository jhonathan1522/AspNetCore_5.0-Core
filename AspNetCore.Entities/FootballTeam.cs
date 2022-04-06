using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Entities
{
   public class FootballTeam: Entity
    {
        #region "propiedades

        public string Name { get; set; }

        public string Score { get; set; }

        public string Manager { get; set; }

        #endregion
    }
}
