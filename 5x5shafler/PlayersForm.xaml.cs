using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _5x5shafler
{
    /// <summary>
    /// Interaction logic for PlayersForm.xaml
    /// </summary>
    public partial class PlayersForm : Window
    {
        MainWindow MainWindow = new MainWindow();
        public PlayersForm()
        {
            InitializeComponent();
            if (!GlobalVariables.AllUsers.Any())
                GlobalVariables.AllUsers = GetPlayersFromFile();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {          
            AllUsers.ItemsSource = GlobalVariables.AllUsers.Keys.ToList();
            Players.ItemsSource = GlobalVariables.PlayersNames;
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in AllUsers.SelectedItems)
            {
                if (GlobalVariables.PlayersNames.Contains(item.ToString()))
                    continue;
                GlobalVariables.PlayersNames.Add(item.ToString());
            }
            Players.ItemsSource = GlobalVariables.PlayersNames;
            RefreshAll();
        }

        private void btnAddNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            var newPlayerForm = new AddNewPlayer();
            newPlayerForm.Show();
            Players.ItemsSource = GlobalVariables.PlayersNames;
            RefreshAll();
        }

        private void btnRemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Players.SelectedItems)
            {
                GlobalVariables.PlayersNames.Remove(item.ToString());
            }
            Players.ItemsSource = GlobalVariables.PlayersNames;
            RefreshAll();

        }

        private Dictionary<string, int> GetPlayersFromFile()
        {
           return File.ReadAllLines(@"players.txt")
                            .Select(x => x.Split(' '))
                            .ToDictionary(x => x[0], x => Convert.ToInt32(x[1]));          
        }

        private void RefreshAll()
        {
            var mainWin = Application.Current.Windows
            .Cast<Window>()
            .FirstOrDefault(window => window is MainWindow) as MainWindow;
            mainWin.lblPleyersSelected.Content = $"{GlobalVariables.PlayersNames.Count()}/10";
            Players.UnselectAll();
            AllUsers.UnselectAll();
            Players.Items.Refresh();
            AllUsers.Items.Refresh();
        }

    }
}
