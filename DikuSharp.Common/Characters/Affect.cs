using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DikuSharp.Common.Characters
{
    public class Affect
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int basePotency { get; set; }
        public int baseDuration { get; set; }
        public int baseRange { get; set; }
        public bool Dispellable { get; set; }
    }
}
