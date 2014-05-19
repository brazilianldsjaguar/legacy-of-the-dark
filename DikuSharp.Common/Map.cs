using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DikuSharp.Common
{
    public class Map
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public Tiles.Tile[, ,] TileMap;
        public List<Characters.Character> lstActiveCharacters;
        public List<Items.Item> lstItems;
    }
}
