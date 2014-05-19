using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common.Characters
{
    public class Attribute
    {
        [Key]
        public int ID { get; set; }
        public AttributeType Type { get; set; }
        public int Value { get; set; }
        public AttributeBonus Bonus { get; set; }

        [NotMapped]
        public int TotalValue
        {
            get { return Value + Bonus.BonusAmount; }
        }
    }

    
}
