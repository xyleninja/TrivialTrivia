using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TrivialTrivia
{
    public class Lobby
    {
        public string name { get; set; }
        public QuestionSet questionSet { get; set; }
        public int numberOfQuestions { get; set; }
        public bool hasHints { get; set; }
        public int transitionInSeconds { get; set; }
        public int secondsPerQuestion { get; set; }
        public int maximumPlayers { get; set; }

        public List<Player> players { get; set; }
    }
}
