using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DikuSharp.Common;
using DikuSharp.Common.Areas;

namespace DikuSharp.Data.Initializer
{
    /// <summary>
    /// Test Class that will allow us to re-create data every time we run without
    /// having to do it all manually
    /// </summary>
    public class DikuSharpDatabaseInitializer : DropCreateDatabaseAlways<DikuSharpDatabase>
    {
        protected override void Seed( DikuSharpDatabase context )
        {
            List<Class> classes = new List<Class> 
            { 
                new Class { Name = "Warrior", ID = 1 },
                new Class { Name = "Mage", ID = 2 },
                new Class { Name = "Cleric", ID = 3 },
                new Class { Name = "Rogue", ID = 4 },
                new Class { Name = "Monk", ID = 5 },
                new Class { Name = "Druid", ID = 6 },
                new Class { Name = "Ranger", ID = 7 },
                new Class { Name = "Psionicist", ID = 8 },
                new Class { Name = "Paladin", ID = 9 },
                new Class { Name = "Bard", ID = 10 }
            };
            context.Classes.AddRange( classes );

            List<Race> races = new List<Race> 
            {
                new Race { Name = "Imperial Human", ID = 1 },
                new Race { Name = "Phasian", ID = 2 },
                new Race { Name = "Zion", ID = 3 },
                new Race { Name = "Gray Dwarf", ID = 4 },
                new Race { Name = "Gerp", ID = 5 },
                new Race { Name = "Gully Dwarf", ID = 6 },
                new Race { Name = "Tinker Dwarf", ID = 7 },
                new Race { Name = "Mountain Dwarf", ID = 8 },
                new Race { Name = "Wood Elf", ID = 9 },
                new Race { Name = "Wild Elf", ID = 10 },
                new Race { Name = "Moon Elf", ID = 11 },
                new Race { Name = "Dark Elf", ID = 12 },
                new Race { Name = "Aquatic Elf", ID = 13 },
                new Race { Name = "Winged Elf", ID = 14 },
                new Race { Name = "Half-Elf", ID = 15 },
                new Race { Name = "Pixie", ID = 16 },
                new Race { Name = "Nixie", ID = 17 },
                new Race { Name = "Succubus", ID = 18 },
                new Race { Name = "Dryad", ID = 19 },
                new Race { Name = "Grig", ID = 20 },
                new Race { Name = "Forest Gnome", ID = 21 },
                new Race { Name = "Rock Gnome", ID = 22 },
                new Race { Name = "Deep Gnome", ID = 23},
                new Race { Name = "Imperial Halfling", ID = 24},
                new Race { Name = "Feral Halfling", ID = 25},
                new Race { Name = "Meadow Halfling", ID = 26},
                new Race { Name = "Kobold", ID = 27},
                new Race { Name = "Orc", ID = 28},
                new Race { Name = "Ogre", ID = 29},
                new Race { Name = "Goblin", ID = 30},
                new Race { Name = "Half-Orc", ID = 31},
                new Race { Name = "Forest Troll", ID = 32},
                new Race { Name = "Desert Troll", ID = 33 },
                new Race { Name = "Mountain Troll", ID = 34 },
                new Race { Name = "Minotaur", ID = 35 },
                new Race { Name = "Lizardman", ID = 36 },
                new Race { Name = "Satyr", ID = 37 },
                new Race { Name = "Ettercap", ID = 38}
            };
            context.Races.AddRange( races );

            List<Ancestry> ancestries = new List<Ancestry>( )
            {
                new Ancestry { Name = "Construct", ID = 1},
                new Ancestry { Name = "Myconid", ID = 2},
                new Ancestry { Name = "Mindflayer", ID = 3},
                new Ancestry { Name = "Ooze", ID = 4},
                new Ancestry { Name = "Thrall", ID = 5},
                new Ancestry { Name = "Lycanthrope", ID = 6},
                new Ancestry { Name = "Vampyr", ID = 7},
                new Ancestry { Name = "Lich", ID = 8},
                new Ancestry { Name = "Black Dragon", ID = 9},
                new Ancestry { Name = "Blue Dragon", ID = 10},
                new Ancestry { Name = "Green Dragon", ID = 11},
                new Ancestry { Name = "Red Dragon", ID = 12},
                new Ancestry { Name = "White Dragon", ID = 13},
                new Ancestry { Name = "Brass Dragon", ID = 14},
                new Ancestry { Name = "Bronze Dragon", ID = 15},
                new Ancestry { Name = "Copper Dragon", ID = 16},
                new Ancestry { Name = "Gold Dragon", ID = 17},
                new Ancestry { Name = "Silver Dragon", ID = 18},
                new Ancestry { Name = "Air Elemental", ID = 19},
                new Ancestry { Name = "Earth Elemental", ID = 20},
                new Ancestry { Name = "Fire Elemental", ID = 21},
                new Ancestry { Name = "Lightning Elemental", ID = 22},
                new Ancestry { Name = "Water Elemental", ID = 23},
                new Ancestry { Name = "Angelic Ancestor", ID = 24},
                new Ancestry { Name = "Demonic Ancestor", ID = 25},
                new Ancestry { Name = "Normal", ID = 26}
            };
            context.Ancestries.AddRange( ancestries );

            List<Starsign> starsigns = new List<Starsign>()
            {
                new Starsign { Name = "The Artist", ID = 1},
                new Starsign { Name = "The Comet", ID = 2},
                new Starsign { Name = "The Fool", ID = 3},
                new Starsign { Name = "The Heirophant", ID = 4},
                new Starsign { Name = "The Hermit", ID = 5},
                new Starsign { Name = "The Hero", ID = 6},
                new Starsign { Name = "The Hospic", ID = 7},
                new Starsign { Name = "The Juggernaut", ID = 8},
                new Starsign { Name = "The Knight", ID = 9},
                new Starsign { Name = "The Pentagram", ID = 10},
                new Starsign { Name = "The Shadow", ID = 11},
                new Starsign { Name = "The Void", ID = 12}
            };
            context.Starsigns.AddRange(starsigns);

            List<Material> materials = new List<Material> 
            { 
                new Material { Name = "GRASS", Hardness = 0, Health = 50, Sharpness = 0, ValueModifier = 0, Weight = 2,ID = 1 },
                new Material { Name ="DIRT", Hardness = 0, Health = 50, Sharpness = 0, ValueModifier = 0, Weight = 2,ID = 2 },
                new Material { Name ="ROCK", Hardness = 3, Health = 50, Sharpness = 1, ValueModifier = 0, Weight = 3,ID = 3 },
                new Material { Name ="SAND", Hardness = 0, Health = 50, Sharpness = 0, ValueModifier = 0, Weight = 2,ID = 4 },
                new Material { Name ="WOOD", Hardness = 2, Health = 50, Sharpness = 1, ValueModifier = 0, Weight = 2,ID = 5 },
                new Material { Name ="STONE", Hardness = 3, Health = 50, Sharpness = 2, ValueModifier = 0, Weight = 3,ID = 6 },
                new Material { Name ="OLDWOOD", Hardness = 1, Health = 50, Sharpness = 1, ValueModifier = 0, Weight = 9,ID = 7 },
                new Material { Name ="GLASS", Hardness = 0, Health = 1, Sharpness = 2, ValueModifier = 0, Weight = 1,ID = 8 },
                new Material { Name ="COPPER", Hardness = 3, Health = 25, Sharpness = 3, ValueModifier = 2, Weight = 2,ID = 9 },
                new Material { Name ="IRON", Hardness = 3, Health = 50, Sharpness = 3, ValueModifier = 3, Weight = 3,ID = 10 },
                new Material { Name ="STEEL", Hardness = 4, Health = 75, Sharpness = 4, ValueModifier = 4, Weight = 4,ID = 11 },
                new Material { Name ="SILVER", Hardness = 3, Health =25, Sharpness = 3, ValueModifier = 5, Weight = 2,ID = 12 },
                new Material { Name ="GOLD", Hardness = 2, Health =50, Sharpness = 1, ValueModifier = 6, Weight = 2,ID = 13 },
                new Material { Name ="FLESH", Hardness = 0, Health = 50, Sharpness = 0, ValueModifier = 0, Weight = 1,ID = 14 },
                new Material { Name ="SKIN", Hardness = 0, Health = 25, Sharpness = 0, ValueModifier = 0, Weight = 1,ID = 15 },
                new Material { Name ="BONE", Hardness = 2, Health = 50, Sharpness = 2, ValueModifier = 0, Weight = 1,ID = 16 },
                new Material { Name ="FUR", Hardness = 1, Health = 25, Sharpness = 0, ValueModifier = 0, Weight = 1,ID = 17 },
                new Material { Name ="LEATHER", Hardness = 2, Health = 50, Sharpness = 0, ValueModifier = 0, Weight = 1,ID = 18 },
                new Material { Name ="SNOW", Hardness = 0, Health = 50, Sharpness = 0, ValueModifier = 0, Weight = 2,ID = 19 },
                new Material { Name ="MITHRIL", Hardness = 4, Health = 75, Sharpness = 4, ValueModifier = 8, Weight = 2,ID = 20 },
                new Material { Name ="ADAMANTIUM", Hardness = 5, Health = 100, Sharpness = 5, ValueModifier = 10, Weight = 2,ID = 21 }
                
            };
            context.Materials.AddRange(materials);

            Area area = new Area( ) { ID = 1, Name = "MudCore", Author = "Frosk", LowLevel = 0, HighLevel = 0 };
            context.Areas.Add( area );

            Room room = new Room( ) { Name = "Limbo", AreaID = 1, Description = "You shouldn't be here." };
            context.Rooms.Add( room );

            List<Account> accounts = new List<Account> 
            { 
                new Account( ) { ID = 1, AccountName = "Frosk", Password = "29DF21D42A8156A94E61EF3DE17C298FFC8AB35461FBA64CECE81720E3611875" },
                new Account( ) { ID = 2, AccountName = "Tradkin", Password = "29DF21D42A8156A94E61EF3DE17C298FFC8AB35461FBA64CECE81720E3611875" },
                //Add new accounts here
            };
            context.Accounts.AddRange( accounts );

            //Save it all
            context.SaveChanges( );

        }
    }
}
