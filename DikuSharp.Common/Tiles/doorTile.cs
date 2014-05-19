using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common.Tiles
{
    public class doorTile : Tile
    {
        public bool IsOpen { get; set; }
        public bool IsLocked { get; set; }
        public int KeyID { get; set; }
        
    }
}
