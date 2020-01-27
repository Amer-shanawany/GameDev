using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev
{
    public abstract class Input
    {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Up{ get; set; }
        public bool Down { get; set; }
        public bool Jump { get; set; }
        public bool Shoot { get; set; }
        public abstract void Update();

    }
}
