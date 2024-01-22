using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymGenius.Controller;

namespace GymGenius.Models
{
    public abstract class AMuscles
    {
        protected string idname;
        public string Name { get; protected set; }

        public ABodyPart bodyPart;
    }
}
 