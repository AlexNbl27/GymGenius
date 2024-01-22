using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.Models
{
    public abstract class ABodyPart
    {
        protected string idname;
        public string Name { get; protected set; }
    }
}
