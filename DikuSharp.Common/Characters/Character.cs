using DikuSharp.Common.Areas;
using DikuSharp.Common.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common.Characters
{
    public class Character
    {
        public string Name { get; set; }
        public int ClassID { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Item> Equipment { get; set; }
        public Room CurrentRoom { get; set; }
        public Controller Controller { get; set; }
        public int AncestryID { get; set; }
        public int RaceID { get; set; }
        public int RoomID { get; set; }
        public virtual Class Class { get; set; }
        public virtual Ancestry Ancestry { get; set; }
        public virtual Race Race { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public override string ToString( )
        {
            return Name;
        }


        /// <summary>
        /// Shortcut method to send a message to all the players in the current player's room
        /// </summary>
        /// <param name="message">A message to say to others.</param>
        public void SendToRoom(string message)
        {
            
            foreach (Character c in this.CurrentRoom.Characters)
            {
                //Evaluating if controller is PC to avoid sending messages to mobs.
                Type ControllerType = c.Controller.GetType().UnderlyingSystemType;
                if (ControllerType.Name == "PlayerController" )
                {
                    PlayerController PC = (PlayerController)c.Controller;
                    if (PC != this.Controller && PC.IsPlaying)
                    {
                        PC.Send(message);
                    }
                }
            }
        }

        /// <summary>
        /// Parameterized message to send to all other connected players in the current room.
        /// </summary>
        /// <param name="formatMessage"></param>
        /// <param name="args"></param>
        public void SendToRoom(string formatMessage, params object[] args)
        {
            this.SendToRoom(string.Format(formatMessage, args));
        }
        
        #region Equal Overrides

        public override bool Equals( object obj )
        {
            Character a = obj as Character;
            if ( (object)a == null )
            {
                return false;
            }

            return ( a.Name == Name );
        }

        public static bool operator ==( Character a, Character b )
        {
            if ( ReferenceEquals( a, b ) )
                return true;

            if ( ( (object)a == null ) || ( (object)b == null ) )
                return false;

            return ( a.Name == b.Name );
        }

        public static bool operator !=( Character a, Character b )
        {
            return !( a == b );
        }

        public override int GetHashCode( )
        {
            return Name.GetHashCode( );
        }

        #endregion
    }
}
