using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkQChallenge6
{
    class Band
    {
        private string name;
        private string fans;
        private string formed;
        private string orgin;
        private string split;
        private string style;

        public Band(string name, string fans, string formed, string orgin, string split, string style)
        {
            this.name = name;
            this.fans = fans;
            this.formed = formed;
            this.orgin = orgin;
            this.split = split;
            this.style = style;
        }

        public string Name { get => name; set => name = value; }
        public string Fans { get => fans; set => fans = value; }
        public string Formed { get => formed; set => formed = value; }
        public string Orgin { get => orgin; set => orgin = value; }
        public string Split { get => split; set => split = value; }
        public string Style { get => style; set => style = value; }

        public override string ToString()
        {
            return ($"Name: {name}\nOrgin: {orgin}\nStyle: {style}");
        }
    }
}