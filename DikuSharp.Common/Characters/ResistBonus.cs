using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common.Characters
{
    public class ResistBonus
    {
        [Key]
        public int ID { get; set; }
        public int BonusAmount { get; set; }
    }

    
}
