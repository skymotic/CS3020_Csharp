using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBrien_Final
{
    public class CharacterEventArgs : EventArgs
    {
        public object CharacterType { get; set; }
        public bool IsAttackMagic { get; set; }
        public string MessageString { get; set; }
        public string ListOfCharacters { get; set; }

        // ---------- ---------- Objects

        public Hero HeroObject { get; set; }
        public Villian VilObject { get; set; }
    }
}
