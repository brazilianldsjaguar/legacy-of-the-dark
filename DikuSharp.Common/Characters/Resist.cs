using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common.Characters
{
    public class Resist
    {
        [Key]
        public int ID { get; set; }
        public ResistType Type { get; set; }
        public int Value { get; set; }
        public ResistBonus Bonus { get; set; }

        [NotMapped]
        public int TotalValue
        {
            get { return Value + Bonus.BonusAmount; }
        }
    }

    
}
