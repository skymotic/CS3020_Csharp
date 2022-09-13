using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBrien_Final
{
    public class CharacterEventArgs : EventArgs
    {
        public int AttackAmount { get; set; }
        public object AttackedCharacter { get; set; }
        public bool IsAttackMagic { get; set; }
        public int DefendEvent { get; set; }
    }
}
