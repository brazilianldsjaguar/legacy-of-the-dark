using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DikuSharp.Common;
using DikuSharp.Common.Tiles;
using DikuSharp.Common.Items;
using DikuSharp.Common.Characters;

namespace DikuSharp.Mud
{
    public class MapGen
    {
        public static Map BasicMapGeneration(MapGenTypes Type)
        {
            Map map = new Map();
            switch (Type)
            {
                case MapGenTypes.BasicGrass:
                    map.Name = "Grass Fields";
                    map.TileMap = new Tile[100, 100, 20];
                    map.lstActiveCharacters = new List<Character>( );
                    map.lstItems = new List<Item>();
                    for (byte z = 0; z < 20; z++)
                    {
                        for (byte x = 0; x < 100; x++)
                        {
                            for (byte y = 0; y < 100; y++)
                            {
                                Tile newTile = new Tile();
                                if (z <= 8) { newTile.Material = Game.GetMaterial("DIRT"); }
                                if (z == 9) { newTile.Material = Game.GetMaterial("GRASS"); }
                                if (z > 9) { newTile.Material = Game.GetMaterial("AIR"); }
                                newTile.Health = newTile.Material.Health;
                                newTile.Enabled = true;
                                map.TileMap[x, y, z] = newTile;
                            }
                        }
                    }
                    break;
                default:
                     map.Name = "The Void";
                     map.TileMap = new Tile[100, 100, 20];
                     map.lstActiveCharacters = new List<Character>();
                     map.lstItems = new List<Item>();
                    for (byte z = 0; z < 20; z++)
                    {
                        for (byte x = 0; x < 100; x++)
                        {
                            for (byte y = 0; y < 100; y++)
                            {
                                Tile newTile = new Tile();
                                newTile.Material = DikuSharp.Mud.Game.GetMaterial("AIR");
                                newTile.Health = newTile.Material.Health;
                                newTile.Enabled = true;
                                map.TileMap[x, y, z] = newTile;
                            }
                        }
                    }
                    break;
            }

            return map;
        }
    }
}
