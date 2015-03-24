using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharSheetApp.Models {
    public class Stat {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public int Modifier { get; private set; }

        public Stat(string name, int score) {
            Name = name;
            Score = score;
            Modifier = (int) (-5 + 0.5 * Score);
        }
    }
}
