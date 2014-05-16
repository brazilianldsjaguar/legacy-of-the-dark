using DikuSharp.Common.Areas;
using DikuSharp.Common.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace DikuSharp.Common.Characters
{
    public class PlayerCharacter
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int ClassID { get; set; }
        public int RaceID { get; set; }
        public int RoomID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual Account Account { get; set; }
        public virtual Class Class { get; set; }
        public virtual Race Race { get; set; }
        public virtual Room CurrentRoom { get; set; }

        //Config flags
        public bool ConfigColor { get; set; }

        [NotMapped]
        public bool IsPlaying
        {
            get { return ( this.Account.CurrentConnection != null && this.Account.CurrentConnection.CurrentConnectionState == Common.ConnectionState.Playing ); }
        }

        /// <summary>
        /// Shortcut method to PlayerConnection.Send( message ) method.
        /// </summary>
        /// <param name="message"></param>
        public void Send( string message )
        {
            this.Account.CurrentConnection.Send( message );
        }

        /// <summary>
        /// Shortcut method to PlayerConnection.Send( formatMessage, args ) method.
        /// </summary>
        /// <param name="formatMessage"></param>
        /// <param name="args"></param>
        public void Send( string formatMessage, params object[ ] args )
        {
            this.Account.CurrentConnection.Send( formatMessage, args );
        }

        /// <summary>
        /// Shortcut method to send a message to all the players in the current player's room
        /// </summary>
        /// <param name="message">A message to say to others.</param>
        public void SendToRoom( string message )
        {
            foreach ( PlayerCharacter c in this.CurrentRoom.Characters )
            {
                if ( c != this && c.IsPlaying )
                {
                    c.Send( message );
                }
            }
        }

        /// <summary>
        /// Parameterized message to send to all other connected players in the current room.
        /// </summary>
        /// <param name="formatMessage"></param>
        /// <param name="args"></param>
        public void SendToRoom( string formatMessage, params object[ ] args )
        {
            this.SendToRoom( string.Format( formatMessage, args ) );
        }


    }
}
