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
        public int ID { get; set; }
        [NotMapped]
        public string Command { get; set; } //Put that here for better accessibility only -arz
        [NotMapped]
        public string Buffer { get; set; }
    }
}
