using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DikuSharp.Common.Characters
{
    public class Language
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Fluency { get; set; }
    }
}
