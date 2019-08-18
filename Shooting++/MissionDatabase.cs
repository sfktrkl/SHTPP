using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting__
{
    public static class MissionDatabase
    {
        public struct Data
        {
            public string name;
            public string note;
            public List<string> variableList;
            public List<string> aimList;

            public Data(string name, string note, List<string> variableList, List<string> aimList)
            {
                this.name = name;
                this.note = note;
                this.variableList = variableList;
                this.aimList = aimList;
            }
        }

        private static readonly Dictionary<string, Data> database = new Dictionary<string, Data>();

        static MissionDatabase()
        {
            database.Add("t1", new Data( "Tutorial 1", "This tutorials is made to ",
                new List<string> { "input" },
                new List<string> { "output" } ));

            database.Add("t2", new Data("Tutorial 2", "This tutorials is made to ",
                 new List<string> { "input" },
                 new List<string> { "output" }));

            database.Add("t3", new Data("Tutorial 3", "This tutorials is made to ",
                 new List<string> { "input" },
                 new List<string> { "output" }));

            database.Add("t4", new Data("Tutorial 4", "This tutorials is made to ",
                 new List<string> { "input" },
                 new List<string> { "output" }));

            database.Add("t5", new Data("Tutorial 5", "This tutorials is made to ",
                 new List<string> { "input" },
                 new List<string> { "output" }));

            database.Add("t6", new Data("Tutorial 6", "This tutorials is made to ",
                new List<string> { "input" },
                new List<string> { "output" }));

            database.Add("m1", new Data("Mission 1", "This tutorials is made to ",
                new List<string> { "input" },
                new List<string> { "output" }));

            database.Add("m2", new Data("Mission 2", "This tutorials is made to ",
                new List<string> { "input" },
                new List<string> { "output" }));
        }

        public static Data GetMission(string mission)
        {
            return database[mission];
        }
    }
}
