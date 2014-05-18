﻿using System;
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
                new Class { Name = "Warrior" },
                new Class { Name = "Mage" },
                new Class { Name = "Cleric" },
                new Class { Name = "Rogue" },
                new Class { Name = "Monk" },
                new Class { Name = "Druid" },
                new Class { Name = "Ranger" },
                new Class { Name = "Psionicist" },
                new Class { Name = "Paladin" },
                new Class { Name = "Bard" }
            };
            context.Classes.AddRange( classes );

            List<Race> races = new List<Race> 
            {
                new Race { Name = "Imperial Human" },
                new Race { Name = "Phasian" },
                new Race { Name = "Zion" },
                new Race { Name = "Gray Dwarf" },
                new Race { Name = "Gerp" },
                new Race { Name = "Gully Dwarf" },
                new Race { Name = "Tinker Dwarf" },
                new Race { Name = "Mountain Dwarf" },
                new Race { Name = "Wood Elf" },
                new Race { Name = "Wild Elf" },
                new Race { Name = "Moon Elf" },
                new Race { Name = "Dark Elf" },
                new Race { Name = "Aquatic Elf" },
                new Race { Name = "Winged Elf" },
                new Race { Name = "Half-Elf" },
                new Race { Name = "Pixie" },
                new Race { Name = "Nixie" },
                new Race { Name = "Succubus" },
                new Race { Name = "Dryad" },
                new Race { Name = "Grig" },
                new Race { Name = "Forest Gnome" },
                new Race { Name = "Rock Gnome" },
                new Race { Name = "Deep Gnome"},
                new Race { Name = "Imperial Halfling" },
                new Race { Name = "Feral Halfling" },
                new Race { Name = "Meadow Halfling" },
                new Race { Name = "Kobold" },
                new Race { Name = "Orc" },
                new Race { Name = "Ogre" },
                new Race { Name = "Goblin" },
                new Race { Name = "Half-Orc" },
                new Race { Name = "Forest Troll" },
                new Race { Name = "Desert Troll" },
                new Race { Name = "Mountain Troll" },
                new Race { Name = "Minotaur" },
                new Race { Name = "Lizardman" },
                new Race { Name = "Satyr" },
                new Race { Name = "Ettercap"}
            };
            context.Races.AddRange( races );

            List<Ancestry> ancestries = new List<Ancestry>( )
            {
                new Ancestry { Name = "Construct"},
                new Ancestry { Name = "Myconid"},
                new Ancestry { Name = "Mindflayer"},
                new Ancestry { Name = "Ooze"},
                new Ancestry { Name = "Thrall"},
                new Ancestry { Name = "Lycanthrope"},
                new Ancestry { Name = "Vampyr"},
                new Ancestry { Name = "Lich"},
                new Ancestry { Name = "Black Dragon"},
                new Ancestry { Name = "Blue Dragon"},
                new Ancestry { Name = "Green Dragon"},
                new Ancestry { Name = "Red Dragon"},
                new Ancestry { Name = "White Dragon"},
                new Ancestry { Name = "Brass Dragon"},
                new Ancestry { Name = "Bronze Dragon"},
                new Ancestry { Name = "Copper Dragon"},
                new Ancestry { Name = "Gold Dragon"},
                new Ancestry { Name = "Silver Dragon"},
                new Ancestry { Name = "Air Elemental"},
                new Ancestry { Name = "Earth Elemental"},
                new Ancestry { Name = "Fire Elemental"},
                new Ancestry { Name = "Lightning Elemental"},
                new Ancestry { Name = "Water Elemental"},
                new Ancestry { Name = "Angelic Ancestor"},
                new Ancestry { Name = "Demonic Ancestor"},
                new Ancestry { Name = "Normal"}
            };
            context.Ancestries.AddRange( ancestries );

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
