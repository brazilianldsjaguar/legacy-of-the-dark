using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DikuSharp.Mud
{
    public class MapGen
    {
        public static Common.Map BasicMapGeneration(Common.MapGenTypes Type)
        {
            Common.Map map = new Common.Map();
            switch (Type)
            {
                case Common.MapGenTypes.BasicGrass:
                    map.Name = "Grass Fields";
                    map.TileMap = new Common.Tiles.Tile[100, 100, 20];
                    map.lstActiveCharacters = new List<Common.Characters.Character>();
                    map.lstItems = new List<Common.Items.Item>();
                    for (byte z = 0; z < 20; z++)
                    {
                        for (byte x = 0; x < 100; x++)
                        {
                            for (byte y = 0; y < 100; y++)
                            {
                                Common.Tiles.Tile newTile = new Common.Tiles.Tile();
                                if (z <= 8) { newTile.Material = DikuSharp.Mud.Game.GetMaterial("DIRT"); }
                                if (z == 9) { newTile.Material = DikuSharp.Mud.Game.GetMaterial("GRASS"); }
                                if (z > 9) { newTile.Material = DikuSharp.Mud.Game.GetMaterial("AIR"); }
                                newTile.Health = newTile.Material.Health;
                                newTile.Enabled = true;
                                map.TileMap[x, y, z] = newTile;
                            }
                        }
                    }
                    break;
                default:
                     map.Name = "The Void";
                     map.TileMap = new Common.Tiles.Tile[100, 100, 20];
                     map.lstActiveCharacters = new List<Common.Characters.Character>();
                     map.lstItems = new List<Common.Items.Item>();
                    for (byte z = 0; z < 20; z++)
                    {
                        for (byte x = 0; x < 100; x++)
                        {
                            for (byte y = 0; y < 100; y++)
                            {
                                Common.Tiles.Tile newTile = new Common.Tiles.Tile();
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
