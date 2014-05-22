using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DikuSharp.Server
{
    public class maintick
    {
        public void mainTick()
        {
           while (true)
           {
               Console.WriteLine("mainTick has started.");
               System.Threading.Thread.Sleep(1000);
               Console.WriteLine("mainTick has slept 1s.");
           }
        }
    }
}
