using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivialTrivia
{
    public class WelcomeMenuItem
    {
        public WelcomeMenuItem()
        {
            targetType = typeof(P_WelcomeDetail);
        }
        public int id { get; set; }
        public string title { get; set; }

        public Type targetType { get; set; }
    }
}