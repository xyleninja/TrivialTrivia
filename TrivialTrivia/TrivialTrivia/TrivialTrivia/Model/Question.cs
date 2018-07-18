using System;
using System.Collections.Generic;
using System.Text;

namespace TrivialTrivia
{
    public class Question
    {
        public string text { get; set; }
        public List<string> answers { get; set; }
        public List<string> hints { get; set; }
    }
}
