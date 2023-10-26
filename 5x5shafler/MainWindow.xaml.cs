using _5x5shafler.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace _5x5shafler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int counter = 0;
        private bool isScoreShown = false;
        private Method lastMethod = Method.Nothing;
        public MainWindow()
        {
            InitializeComponent();
            ReadPlayers();
        }

        private void ReadPlayers()
        {
            try
            {
                if (!GlobalVariables.AllSheetPlayers.Any())
                    GoogleSheet.ReadGoogleSheet();
            }
            catch (Exception ex)
            {
                this.Output.Content = $"Couldn't read the google sheet \n\n {ex.Message}";
                return;
            }
        }
        private void btnSelectPlayers_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var PlayersForm = new PlayersForm();
                PlayersForm.Show();
            }
            catch
            {
                this.Output.Content = "Error while reading the file.";
            }
        }

        private void btnMakeTeams_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.TeamB.Clear();
            GlobalVariables.TeamA.Clear();
            if (GlobalVariables.PlayersNames.Count() != 10)
            {
                this.Output.Content = "Select 10 players, dawg";
                return;
            }
            var playersArray = GlobalVariables.PlayersNames.ToArray();
            Shuffle(playersArray);
            Array.Sort(playersArray, new PlayersComparer());
            var random = new Random();
            switch (random.Next(0, 2))
            {
                case 0:
                    StrategyA(playersArray);
                    break;
                case 1:
                    StrategyB(playersArray);
                    break;
            }
            ListBoxTeamB.ItemsSource = GlobalVariables.TeamB;
            ListBoxTeamA.ItemsSource = GlobalVariables.TeamA;

            RefreshAll();
            UpdateTeamRank(false);
            lastMethod = Method.Skill;
            isScoreShown = false;
        }

        private void btnMakeTeamsByOP_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.TeamB.Clear();
            GlobalVariables.TeamA.Clear();
            if (GlobalVariables.PlayersNames.Count() != 10)
            {
                this.Output.Content = "Select 10 players, dawg";
                return;
            }

            foreach (var name in GlobalVariables.PlayersNames)
            {
                if (!GlobalVariables.AllSheetPlayers.Keys.Contains(name))
                {
                    this.Output.Content = $"Player {name} was not found in sheet";
                    return;
                }
            }

            var playersArray = GlobalVariables.PlayersNames.ToArray();
            Array.Sort(playersArray, new OpScoreComparer());

            if (counter == 0)
            {
                StrategyOPScore(playersArray);
                counter = 1;
            }
            else if (counter == 1)
            {
                StrategyA(playersArray);
                counter = 2;
            }
            else
            {
                StrategyB(playersArray);
                counter = 0;
            }

            ListBoxTeamB.ItemsSource = GlobalVariables.TeamB;
            ListBoxTeamA.ItemsSource = GlobalVariables.TeamA;

            RefreshAll();
            UpdateTeamRank(true);
            lastMethod = Method.OpScore;
            isScoreShown = false;
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.TeamB.Clear();
            GlobalVariables.TeamA.Clear();
            if (GlobalVariables.PlayersNames.Count() != 10)
            {
                this.Output.Content = "Select 10 players, dawg";
                return;
            }

            var players = GlobalVariables.PlayersNames.ToArray();
            Shuffle(players);
            StrategyA(players);
            ListBoxTeamB.ItemsSource = GlobalVariables.TeamB;
            ListBoxTeamA.ItemsSource = GlobalVariables.TeamA;

            RefreshAll();
            UpdateTeamRank(false);
            lastMethod = Method.Random;
            isScoreShown = false;
        }

        private void ClickOnTeams(object sender, RoutedEventArgs e)
        {
            if (!GlobalVariables.TeamA.Any() || !GlobalVariables.TeamA.Any() || lastMethod == Method.Nothing || lastMethod == Method.Random)
            {
                return;
            }
            if (lastMethod == Method.OpScore && !isScoreShown)
            {
                ListBoxTeamB.ItemsSource = TeamsWithScore(GlobalVariables.TeamB, true);
                ListBoxTeamA.ItemsSource = TeamsWithScore(GlobalVariables.TeamA, true);
                isScoreShown = true;
            }
            else if (lastMethod == Method.OpScore && isScoreShown)
            {
                ListBoxTeamB.ItemsSource = GlobalVariables.TeamB;
                ListBoxTeamA.ItemsSource = GlobalVariables.TeamA;
                isScoreShown = false;
            }
            if (lastMethod == Method.Skill && !isScoreShown)
            {
                ListBoxTeamB.ItemsSource = TeamsWithScore(GlobalVariables.TeamB, false);
                ListBoxTeamA.ItemsSource = TeamsWithScore(GlobalVariables.TeamA, false);
                isScoreShown = true;
            }
            else if (lastMethod == Method.Skill && isScoreShown)
            {
                ListBoxTeamB.ItemsSource = GlobalVariables.TeamB;
                ListBoxTeamA.ItemsSource = GlobalVariables.TeamA;
                isScoreShown = false;
            }
            RefreshAll();
        }

        private static Random random = new Random();

        private static void Shuffle<T>(T[] array)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length - 1; ++i)
            {
                int r = random.Next(i, array.Length);
                (array[r], array[i]) = (array[i], array[r]);
            }
        }

        private void StrategyA(string[] players)
        {
            GlobalVariables.TeamA.Add(players[0]);
            GlobalVariables.TeamA.Add(players[2]);
            GlobalVariables.TeamA.Add(players[4]);
            GlobalVariables.TeamA.Add(players[7]);
            GlobalVariables.TeamA.Add(players[9]);

            GlobalVariables.TeamB.Add(players[1]);
            GlobalVariables.TeamB.Add(players[3]);
            GlobalVariables.TeamB.Add(players[5]);
            GlobalVariables.TeamB.Add(players[6]);
            GlobalVariables.TeamB.Add(players[8]);
        }

        private void StrategyB(string[] players)
        {

            GlobalVariables.TeamA.Add(players[0]);
            GlobalVariables.TeamA.Add(players[1]);
            GlobalVariables.TeamA.Add(players[5]);
            GlobalVariables.TeamA.Add(players[8]);
            GlobalVariables.TeamA.Add(players[9]);

            GlobalVariables.TeamB.Add(players[2]);
            GlobalVariables.TeamB.Add(players[3]);
            GlobalVariables.TeamB.Add(players[4]);
            GlobalVariables.TeamB.Add(players[6]);
            GlobalVariables.TeamB.Add(players[7]);
        }

        private void StrategyOPScore(string[] players)
        {
            double totalSkill = 0;
            foreach (var player in GlobalVariables.PlayersNames)
            {
                totalSkill += GlobalVariables.AllSheetPlayers[$"{player}"];
            }
            double avgPlayerSkill = totalSkill / GlobalVariables.PlayersNames.Count();

            double teamSkill = GlobalVariables.AllSheetPlayers[players[0]];
            GlobalVariables.TeamA.Add(players[0]);
            players = players.Where(i => i != players[0]).ToArray();

            for (int i = 1; i < GlobalVariables.PlayersNames.Count / 2; i++)
            {
                if (teamSkill > avgPlayerSkill * GlobalVariables.TeamA.Count())
                {
                    teamSkill += GlobalVariables.AllSheetPlayers[players[players.Length - 1]];
                    GlobalVariables.TeamA.Add(players[players.Length - 1]);
                    players = players.Where(i => i != players[players.Length - 1]).ToArray();
                }
                else
                {
                    teamSkill += GlobalVariables.AllSheetPlayers[players[0]];
                    GlobalVariables.TeamA.Add(players[0]);
                    players = players.Where(i => i != players[0]).ToArray();
                }
            }
            GlobalVariables.TeamB.AddRange(players);
        }

        private void UpdateTeamRank(bool isOPScore)
        {
            double sum = 0;
            foreach (var member in GlobalVariables.TeamB)
            {
                if (isOPScore)
                {
                    sum += GlobalVariables.AllSheetPlayers[$"{member}"];
                }
                else
                {
                    sum += GlobalVariables.AllUsers[$"{member}"];
                }
            }
            this.TeamBRank.Content = sum;
            sum = 0;
            foreach (var member in GlobalVariables.TeamA)
            {
                if (isOPScore)
                {
                    sum += GlobalVariables.AllSheetPlayers[$"{member}"];
                }
                else
                {
                    sum += GlobalVariables.AllUsers[$"{member}"];
                }
            }
            this.TeamARank.Content = sum;
        }

        private void RefreshAll()
        {
            Output.Content = $":D";
            ListBoxTeamB.Items.Refresh();
            ListBoxTeamA.Items.Refresh();
        }

        private IEnumerable<string> TeamsWithScore(List<string> players, bool isOpScore)
        {
            if (isOpScore)
                return players.Select(player => player + " -- " + GlobalVariables.AllSheetPlayers[$"{player}"]);
            return players.Select(player => player + " -- " + GlobalVariables.AllUsers[$"{player}"]);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
        enum Method
          {
            Nothing,
            Random,
            OpScore,
            Skill
          }
    
    }
}
