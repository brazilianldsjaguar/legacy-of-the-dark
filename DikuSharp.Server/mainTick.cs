using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DikuSharp.Common;

namespace DikuSharp.Server
{
    public class maintick
    {
        public void mainTick()
        {
           while (true)
           {
               Console.WriteLine("mainTick has started.");
               foreach (PlayerConnection MC in staticholder.MudConnections  )
               {
                   DikuSharp.Mud.InputParser.ParseCommand(MC,MC.controller.Command);
                   MC.BufferSend();
               }
               System.Threading.Thread.Sleep(1000);
               Console.WriteLine("mainTick has slept 1s.");
           }
        }
    }
}
