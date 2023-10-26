using System;
using System.Collections.Generic;
using System.Text;

namespace _5x5shafler.Comparers
{
    class PlayersComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            if(GlobalVariables.AllUsers[s1] > GlobalVariables.AllUsers[s2])
                return -1;
            if (GlobalVariables.AllUsers[s1] < GlobalVariables.AllUsers[s2])
                return 1;

            return 0;
        }
    }
}
