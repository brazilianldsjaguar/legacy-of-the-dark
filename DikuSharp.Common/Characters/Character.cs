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
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoomID { get; set; }
        public virtual Room CurrentRoom { get; set; }
        public int? ControllerID { get; set; }
        public virtual Controller Controller { get; set; }
        public int AncestryID { get; set; }
        public virtual Ancestry Ancestry { get; set; }
        public int StarsignID { get; set; }
        public virtual Starsign Starsign { get; set; }
        public int RaceID { get; set; }
        public virtual Race Race { get; set; }
        public int ClassID { get; set; }
        public virtual Class Class { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual IList<Attribute> Attributes { get; set; }
        public virtual IList<Resist> Resists { get; set; }

        public Attribute Strength
        {
            get { return ( (List<Attribute>)Attributes ).Find( a => a.Type == AttributeType.Strength ); }
        }

        public Attribute Dexterity
        {
            get { return ( (List<Attribute>)Attributes ).Find( a => a.Type == AttributeType.Dexterity ); }
        }

        public Attribute Constituion
        {
            get { return ( (List<Attribute>)Attributes ).Find( a => a.Type == AttributeType.Constituion ); }
        }

        public Attribute Intelligence
        {
            get { return ( (List<Attribute>)Attributes ).Find( a => a.Type == AttributeType.Intelligence ); }
        }

        public Attribute Wisdom
        {
            get { return ( (List<Attribute>)Attributes ).Find( a => a.Type == AttributeType.Wisdom ); }
        }

        public Attribute Charisma
        {
            get { return ( (List<Attribute>)Attributes ).Find( a => a.Type == AttributeType.Charisma ); }
        }

        public Attribute Luck
        {
            get { return ( (List<Attribute>)Attributes ).Find( a => a.Type == AttributeType.Luck ); }
        }
        public Resist Fire 
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Fire); }
        }
        public Resist Cold 
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Cold); }
        }
        public Resist Electricity 
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Electricity); }
        }
        public Resist Air 
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Air); }
        }
        public Resist Blunt 
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Blunt); }
        }
        public Resist Pierce 
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Pierce); }
        }
        public Resist Slash 
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Slash); }
        }
        public Resist Acid 
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Acid); }
        }
        public Resist Poison 
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Poison); }
        }
        public Resist Nature 
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Nature); }
        }
        public Resist Crystal 
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Crystal); }
        }
        public Resist Earth 
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Earth); }
        }
        public Resist Magic
        {
            get { return ((List<Resist>)Resists).Find(a => a.Type == ResistType.Magic); }
        }

        /// <summary>
        /// Get a string representation of the character.
        /// </summary>
        /// <returns>The name of the character.</returns>
        public override string ToString( )
        {
            return Name;
        }

        /// <summary>
        /// Shortcut to send a message to a player. Will send nothing to non-player characters.
        /// </summary>
        /// <param name="message"></param>
        public void Send( string message )
        {
            Type ControllerType = this.Controller.GetType( ).UnderlyingSystemType;
            if ( ControllerType.Name == "PlayerController" )
            {
                PlayerController PC = (PlayerController)this.Controller;
                if ( PC.IsPlaying )
                {
                    PC.Send( message );
                }
            }
        }

        /// <summary>
        /// Shortcut to send a format-message to character.
        /// </summary>
        /// <param name="formatMessage"></param>
        /// <param name="args"></param>
        public void Send( string formatMessage, object[ ] args )
        {
            this.Send( string.Format( formatMessage, args ) );
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
