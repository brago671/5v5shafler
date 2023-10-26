using System;
using System.Collections.Generic;
using System.Text;

namespace _5x5shafler.Comparers
{
    class OpScoreComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            if (GlobalVariables.AllSheetPlayers[s1] > GlobalVariables.AllSheetPlayers[s2])
                return -1;
            if (GlobalVariables.AllSheetPlayers[s1] < GlobalVariables.AllSheetPlayers[s2])
                return 1;

            return 0;
        }
    }
}
