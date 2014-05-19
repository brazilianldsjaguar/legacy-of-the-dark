using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DikuSharp.Common
{
    public class Material
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public int Hardness { get; set; }
        public int Sharpness { get; set; }
        public int Health { get; set; }
        public int Weight { get; set; } //Weight for carrying but also affects required Str to swing.
        public int ValueModifier { get; set; } //Modifier for an item's worth.

        #region Equal Overrides

        public override bool Equals(object obj)
        {
            Material a = obj as Material;
            if ((object)a == null)
            {
                return false;
            }

            return (a.Name == Name);
        }

        public static bool operator ==(Material a, Material b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object)a == null) || ((object)b == null))
                return false;

            return (a.Name == b.Name);
        }

        public static bool operator !=(Material a, Material b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        #endregion
        
    }

}
