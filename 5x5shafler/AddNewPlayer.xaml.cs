using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddNewPlayer.xaml
    /// </summary>
    public partial class AddNewPlayer : Window
    {
        public AddNewPlayer()
        {
            InitializeComponent();
        }

        private void addNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateNewPlayer())
            {
                return;
            }

            GlobalVariables.AllUsers.Add(this.NickName.Text, Convert.ToInt32(this.SkillLvl.Text));
            GlobalVariables.AllSheetPlayers.Add(this.NickName.Text, Convert.ToDouble(this.OPScore.Text.Replace(".", ",")));
            var PlayerWin = Application.Current.Windows
            .Cast<Window>()
            .FirstOrDefault(window => window is PlayersForm) as PlayersForm;
            PlayerWin.AllUsers.ItemsSource = GlobalVariables.AllUsers.Keys.ToList();
            PlayerWin.AllUsers.Items.Refresh();
            this.Close();
        }

        private bool ValidateNewPlayer()
        {
            int result; double resultOpScore;
            var isInt = int.TryParse(this.SkillLvl.Text, out result);
            var isIntOpScore = double.TryParse(this.OPScore.Text.Replace(".",","), out resultOpScore);
            if (this.NickName.Text.Contains(" "))
                return false;
            if (!isInt)
                return false;
            if (!isIntOpScore)
                return false;
            if (result > 5 || result < 1)
                return false;
            if (resultOpScore <= 0)
                return false;
            return true;
        }
    }
}
