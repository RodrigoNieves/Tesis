using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class GraphicCreatedEventArgs: EventArgs
    {
        public string location { get; set; }
        public string name { get; set; }
    }
}
