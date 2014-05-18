using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common.Characters
{
    public class PlayerController : Controller
    {
        public int AccountID { get; set; }
        public virtual Account Account { get; set; }
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
    }
}
