using DikuSharp.Common.Areas;
using DikuSharp.Common.Characters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common.Items
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Keywords { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public bool IsEquipped { get; set; }

        public virtual ICollection<PlayerCharacter> Characters { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
