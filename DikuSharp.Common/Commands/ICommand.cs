using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common.Commands
{
    public interface ICommand
    {
        int Priority { get; }
        void Do( object source, List<string> args );
    }
}
