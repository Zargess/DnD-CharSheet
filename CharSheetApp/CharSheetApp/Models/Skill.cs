using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharSheetApp.Models {
    public class Skill {
        public string Name { get; private set; }
        public bool Proficient { get; private set; }
        public int Value { get; private set; }
        private int _bonus;
        private Stat _stat;

        public Skill(Stat stat, string name, bool proficient, int bonus) {
            _stat = stat;
            _bonus = bonus;
            Name = name;
            Proficient = proficient;
        }
    }
}