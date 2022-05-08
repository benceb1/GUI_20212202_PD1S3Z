using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformer
{
    public class MeleeAttack
    {
        private int damage;
        private int range;
        public int Damage
        {
            get { return damage; }
            set
            {
                damage = value;
            }
        }
        public int Range
        {
            get { return range; }
            set
            {
                range = value;
            }
        }
        public MeleeAttack(int damage=10,int range=25)
        {
            this.Damage = damage;
            this.Range = range;

        }
    }
}
