using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace TrivialTrivia
{
    public class LobbyViewModel : BaseViewModel
    {
        private Lobby lobby;

        #region Lobby Settings
        public string lobbyName
        {
            get { return lobby.name; }
            set
            {
                lobby.name = value;
                OnPropertyChanged("lobbyName");
            }
        }
        public QuestionSet lobbyQuestionSet
        {
            get { return lobby.questionSet; }
            set
            {
                lobby.questionSet = value;
                OnPropertyChanged("lobbyQuestionSet");
            }
        }
        public int lobbyNumberOfQuestions
        {
            get { return lobby.numberOfQuestions; }
            set
            { lobby.numberOfQuestions = value;
                OnPropertyChanged("lobbyNumberOfQuestions");
            }
        }
        public bool lobbyHasHints
        {
            get { return lobby.hasHints; }
            set
            {
                lobby.hasHints = value;
                OnPropertyChanged("lobbyHasHints");
            }
        }
        public int lobbyTransitionInSeconds
        {
            get { return lobby.transitionInSeconds; }
            set
            {
                lobby.transitionInSeconds = value;
                OnPropertyChanged("lobbyTransitionInSeconds");
            }
        }
        public int lobbySecondsPerQuesetion
        {
            get { return lobby.secondsPerQuestion; }
            set
            {
                lobby.secondsPerQuestion = value;
                OnPropertyChanged("lobbySecondsPerQuesetion");
            }
        }
        public int lobbyMaximumPlayers {
            get { return lobby.maximumPlayers; }
            set
            {
                lobby.maximumPlayers = value;
                OnPropertyChanged("lobbyMaximumPlayers");
            }
        }
        public List<Player> lobbyPlayers
        {
            get { return lobby.players; }
            set
            {
                lobby.players = value;
                OnPropertyChanged("lobbyPlayers");
            }
        }
        #endregion

        #region Player names
        public string playerOneName {
            get { return lobbyPlayers[0].name; }
            set { lobbyPlayers[0].name = value; OnPropertyChanged("playerOneName"); }
        }
        public string playerTwoName {
            get { return lobbyPlayers[1].name; }
            set { lobbyPlayers[1].name = value; OnPropertyChanged("playerTwoName"); }
        }
        public string playerThreeName {
            get { return lobbyPlayers[2].name; }
            set { lobbyPlayers[2].name = value; OnPropertyChanged("playerThreeName"); }
        }
        public string playerFourName {
            get { return lobbyPlayers[3].name; }
            set { lobbyPlayers[3].name = value; OnPropertyChanged("playerFourName"); }
        }
        public string playerFiveName {
            get { return lobbyPlayers[4].name; }
            set { lobbyPlayers[4].name = value; OnPropertyChanged("playerFiveName"); }
        }
        public string playerSixName {
            get { return lobbyPlayers[5].name; }
            set { lobbyPlayers[5].name = value; OnPropertyChanged("playerSixName"); }
        }
        public string playerSevenName {
            get { return lobbyPlayers[6].name; }
            set { lobbyPlayers[6].name = value; OnPropertyChanged("playerSevenName"); }
        }
        public string playerEightName {
            get { return lobbyPlayers[7].name; }
            set { lobbyPlayers[7].name = value; OnPropertyChanged("playerEightName"); }
        }
        #endregion

        #region Player colors
        public Color playerOneColor {
            get { return lobbyPlayers[0].color; }
            set { lobbyPlayers[0].color = value; OnPropertyChanged("playerOneColor"); }
        }
        public Color playerTwoColor {
            get { return lobbyPlayers[1].color; }
            set { lobbyPlayers[1].color = value; OnPropertyChanged("playerTwoColor"); }
        }
        public Color playerThreeColor {
            get { return lobbyPlayers[2].color; }
            set { lobbyPlayers[2].color = value; OnPropertyChanged("playerThreeColor"); }
        }
        public Color playerFourColor {
            get { return lobbyPlayers[3].color; }
            set { lobbyPlayers[3].color = value; OnPropertyChanged("playerFourColor"); }
        }
        public Color playerFiveColor {
            get { return lobbyPlayers[4].color; }
            set { lobbyPlayers[4].color = value; OnPropertyChanged("playerFiveColor"); }
        }
        public Color playerSixColor {
            get { return lobbyPlayers[5].color; }
            set { lobbyPlayers[5].color = value; OnPropertyChanged("playerSixColor"); }
        }
        public Color playerSevenColor {
            get { return lobbyPlayers[6].color; }
            set { lobbyPlayers[6].color = value; OnPropertyChanged("playerSevenColor"); }
        }
        public Color playerEightColor {
            get { return lobbyPlayers[7].color; }
            set { lobbyPlayers[7].color = value; OnPropertyChanged("playerEightColor"); }
        }
        #endregion Player colors

        #region Player ready
        public bool playerOneReady { get; set; } = false;
        public bool playerTwoReady { get; set; } = false;
        public bool playerThreeReady { get; set; } = false;
        public bool playerFourReady { get; set; } = false;
        public bool playerFiveReady { get; set; } = false;
        public bool playerSixReady { get; set; } = false;
        public bool playerSevenReady { get; set; } = false;
        public bool playerEightReady { get; set; } = false;
        #endregion

        #region Player ready string
        public string playerOneReadyString { get { return playerOneReady ? "✔️" : "❌"; } }
        public string playerTwoReadyString { get { return playerTwoReady ? "✔️" : "❌"; } }
        public string playerThreeReadyString { get { return playerThreeReady ? "✔️" : "❌"; } }
        public string playerFourReadyString { get { return playerFourReady ? "✔️" : "❌"; } }
        public string playerFiveReadyString { get { return playerFiveReady ? "✔️" : "❌"; } }
        public string playerSixReadyString { get { return playerSixReady ? "✔️" : "❌"; } }
        public string playerSevenReadyString { get { return playerSevenReady ? "✔️" : "❌"; } }
        public string playerEightReadyString { get { return playerEightReady ? "✔️" : "❌"; } }
        #endregion

        public LobbyViewModel()
        {
            lobby = new Lobby();

            //Default Values
            lobby.name = "Unnamed Lobby";
            lobby.questionSet = null;
            lobby.numberOfQuestions = 10;
            lobby.hasHints = true;
            lobby.transitionInSeconds = 10;
            lobby.secondsPerQuestion = 60;
            lobby.maximumPlayers = 8;

            lobby.players = new List<Player>();

            lobby.players.Add(App._player);

            for (int i = 1; i < 8; i++)
            {
                lobby.players.Add(new Player { color = App._availablePlayerColors[i]});
            }
        }
    }
}
