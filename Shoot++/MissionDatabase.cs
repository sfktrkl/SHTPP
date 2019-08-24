using System.Collections.Generic;

namespace Shoot
{
    public static class MissionDatabase
    {
        public struct Data
        {
            public string name;
            public string note;
            public List<string> variableList;
            public List<string> aimList;
            public string code;
            public int number;

            public Data(string name, string note, List<string> variableList, List<string> aimList, string code, int number)
            {
                this.name = name;
                this.note = note;
                this.variableList = variableList;
                this.aimList = aimList;
                this.code = code;
                this.number = number;
            }
        }

        private static readonly Dictionary<string, Data> database = new Dictionary<string, Data>();

        static MissionDatabase()
        {
            database.Add("t1", new Data("Tutorial 1", "This tutorials is made to ",
                new List<string> { "input" },
                new List<string> { "output" },
                "#Example:\n" + 
                "SHOOT 10",
                1
                ));
        }

        public static Data GetMission(string mission)
        {
            return database[mission];
        }
    }
}