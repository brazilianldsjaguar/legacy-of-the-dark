using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DikuSharp.Common.Characters
{
    
    public class AttributeBonus
    {
        [Key]
        public int ID { get; set; }
        public AttributeType Type { get; set; }
        public int BonusAmount { get; set; }
    }
}
