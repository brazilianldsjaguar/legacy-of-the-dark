using DikuSharp.Common.Areas;
using DikuSharp.Common.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace DikuSharp.Common.Characters
{
    public class Controller
    {
    }

    public class PlayerController : Controller
    {
        public int AccountID { get; set; }
        public virtual Account Account { get; set; }
        //Config flags
        public bool ConfigColor { get; set; }
        [NotMapped]
        public bool IsPlaying
        {
            get { return (this.Account.CurrentConnection != null && this.Account.CurrentConnection.CurrentConnectionState == Common.ConnectionState.Playing); }
        }
        /// <summary>
        /// Shortcut method to PlayerConnection.Send( message ) method.
        /// </summary>
        /// <param name="message"></param>
        public void Send(string message)
        {
            this.Account.CurrentConnection.Send(message);
        }

        /// <summary>
        /// Shortcut method to PlayerConnection.Send( formatMessage, args ) method.
        /// </summary>
        /// <param name="formatMessage"></param>
        /// <param name="args"></param>
        public void Send(string formatMessage, params object[] args)
        {
            this.Account.CurrentConnection.Send(formatMessage, args);
        }
    }

    public class AIController : Controller
    {
        //Different pieces of AI should go here, either Advanced or basic Mob-like behavior.
        //We'll need a few behaviors like Guard, Patrol, Roaming, Reactive, Scripted, Advanced.
        //Guard AI stays in place and only engages troublemakers or natural enemies.
        //Patrol AI follows a pre-established route over and over, engaging enemies if needed.
        //Roaming AI roams in random direction, doing something at random sometimes. Very MobileLike
        //Reactive AI should react to what it sees and act accordingly, fleeing from danger or running into it.
        //--Getting items it sees and like, greeting good looking characters, a little more lifelike behavior.
        //Scripted AI should only follow script assigned to it.
        //Advanced AI should have a natural life, hunting for food, showering, sleeping into his bed, commenting
        //--things they see or do. These will have to be coded individually and used sparingly. (ResourceHungry)
    }
}
