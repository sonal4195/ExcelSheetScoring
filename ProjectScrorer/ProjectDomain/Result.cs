using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain
{
    public class Result
    {
        public enum colors
        {
            red,
            yellow,
            green
        };
        public colors signalColor { get; set; }
        public int score { get; set; }
    }
}
