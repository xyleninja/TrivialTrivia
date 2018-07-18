using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TrivialTrivia
{
    public partial class App : Application
    {
        public static Player _player { get; set; }
        public static List<Color> _availablePlayerColors = new List<Color>
        {
            Color.Red,
            Color.Blue,
            Color.Turquoise,
            Color.Purple,
            Color.Yellow,
            Color.Orange,
            Color.Green,
            Color.Pink,
            Color.Gray,
            Color.SkyBlue,
            Color.Olive,
        };
        public static ObservableCollection<QuestionSet> _questionSets { get; set; }

        #region Pages
        private static P_WelcomeMaster p_welcomeMasterPage;
        public static P_WelcomeMaster welcomeMasterPage
        {
            get { return p_welcomeMasterPage ?? (p_welcomeMasterPage = new P_WelcomeMaster()); }
            set { p_welcomeMasterPage = value; }
        }

        private static P_WelcomeDetail p_welcomeDetailPage;
        public static P_WelcomeDetail welcomeDetailPage
        {
            get { return p_welcomeDetailPage ?? (p_welcomeDetailPage = new P_WelcomeDetail()); }
            set { p_welcomeDetailPage = value; }
        }

        private static P_Lobby p_lobbyPage;
        public static P_Lobby lobbyPage
        {
            get { return p_lobbyPage ?? (p_lobbyPage = new P_Lobby()); }
            set { p_lobbyPage = value; }
        }

        private static P_SearchLobby p_searchLobbyPage;
        public static P_SearchLobby searchLobbyPage
        {
            get { return p_searchLobbyPage ?? (p_searchLobbyPage = new P_SearchLobby()); }
            set { p_searchLobbyPage = value; }
        }
        #endregion

        public App()
        {
            InitializeComponent();

            MainPage = new P_Welcome();
        }

        protected override void OnStart()
        {
            if (_questionSets == null)
            {
                _questionSets = new ObservableCollection<QuestionSet>();
                _questionSets.Add(new QuestionSet
                {
                    designation = "Demo Set",
                    questions = new ObservableCollection<Question>
                {
                    new Question
                    {
                        text = "What is the capital of france?",
                        answers = new List<string>
                        {
                            "Paris",
                            "paris",
                        },
                        hints = new List<string>
                        {
                            "The Seine is a river flowing through it.",
                            "The Tour de France finishes in it.",
                        }
                    },
                    new Question
                    {
                        text = "Which file format is typically opened by Acrobat Reader?",
                        answers = new List<string>
                        {
                            ".pdf",
                            "pdf",
                            "portable document format",
                        },
                        hints = new List<string>
                        {
                            "It was invented to display a document, independant of it's creating softwarem, operation system or hardware."
                        }
                    }
                }
                });
            }

            if (_player == null)
            {
                _player = new Player
                {
                    name = "UnnamedNewbie",
                    color = Color.Black,
                };
            }

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
