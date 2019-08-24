using System.Collections.Generic;
using System;

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
            public int[] solutions;

            public Data(string name, string note, List<string> variableList, List<string> aimList, string code, int number, int[] solutions)
            {
                this.name = name;
                this.note = note;
                this.variableList = variableList;
                this.aimList = aimList;
                this.code = code;
                this.number = number;
                this.solutions = solutions;
            }
        }

        private static readonly Dictionary<string, Data> database = new Dictionary<string, Data>();

        static MissionDatabase()
        {
            Func<int[]> tutorial1 = delegate 
            {
                int[] solutions = new int[1];
                solutions[0] = 5;
                return solutions;
            };

            database.Add("t1", new Data("Tutorial 1", "This tutorials is made to ",
                new List<string> { "input" },
                new List<string> { "output" },
                "#Lines start with # are comment lines\n" + 
                "#Example:\n" +
                "#SHOOT 5\n" +
                "#SHOOT 3 + 2\n" +
                "#It is possible using value or expression\n" +
                "#SHOOT keyword takes the final results\n\n" +
                "#Important: Only integer calculations are possible\n\n" + 
                "SHOOT 3 + 2",
                1,
                tutorial1()
                ));
        }

        public static Data GetMission(string mission)
        {
            return database[mission];
        }
    }
}