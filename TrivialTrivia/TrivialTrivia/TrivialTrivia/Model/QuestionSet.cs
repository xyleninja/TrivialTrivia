using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TrivialTrivia
{
    public class QuestionSet
    {
        public string designation { get; set; }
        public ObservableCollection<Question> questions { get; set; }
    }
}
