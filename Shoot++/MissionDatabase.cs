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
            public string code;
            public int number;
            public int[] inputs;
            public int[] solutions;

            public Data(int number, string name, string note, string code, int[] inputs, int[] solutions)
            {
                this.number = number;
                this.name = name;
                this.note = note;
                this.code = code;
                this.inputs = inputs;
                this.solutions = solutions;
            }
        }

        static MissionDatabase()
        {
        }

        public static Data GetMission(string mission)
        {
            if (mission == "t1")
                return Tutorial1();
            else if (mission == "t3")
                return Tutorial3();
            else
                return new Data();
        }

        private static Data Tutorial1()
        {
            int[] inputs = new int[1];

            Func<int[]> Solutions = delegate
            {
                int[] solutions = new int[inputs.Length];

                for (int i = 0; i < inputs.Length; i++)
                    solutions[i] = 5;

                return solutions;
            };

            return new Data(
            //Mission number
            1,
            // Mission Name
            "Tutorial 1", 
            // Mission Note
            "Aim of this tutorial is to learn how to use the comment lines, and returning the calculated values. " +
            "Comment lines are starting with # and ends with the line endings. " +
            "SHOOT keyword is used for giving the calculated values as results. " +
            "If your return values are match with the solution, then you will succeed in the mission.\n" +
            "Be careful, interpreter only allows integer calculations.",
            // Mission default code
            "#Lines start with # are comment lines\n" +
            "#Example:\n" +
            "#SHOOT 5\n" +
            "#SHOOT 3 + 2\n" +
            "#It is possible using a value or an expression\n" +
            "#Use SHOOT keyword to give your final results\n\n" +
            "#Important: Only integer calculations are possible\n\n" +
            "SHOOT 3 + 2",
            // Mission inputs
            inputs,
            // Mission solutions
            Solutions()
            );
        }

        private static Data Tutorial3()
        {
            Func<int[]> CreateInputs = delegate
            {
                int[] created = new int[1];
                Random randomNumber = new Random();
                created[0] = randomNumber.Next(0, 100);
                return created;
            };

            int[] inputs = CreateInputs();

            Func<int[]> Solutions = delegate
            {
                int[] solutions = new int[inputs.Length];

                for (int i = 0; i < inputs.Length; i++)
                    solutions[i] = inputs[i] + 3;

                return solutions;
            };

            return new Data(
                //Mission number
                3,
                // Mission Name
                "Tutorial 3",
                // Mission Note
                "Aim of this tutorial is to learn how to take inputs and use them as variables. " +
                "In every mission you will be informed if there is any input. " +
                "For this mission output is given to you as the first number in the calculation. " +
                "INPUT keyword is used for taking this input. You can take it with any variable name you choose.\n" +
                "Inputs: First number in the calculation.",
                // Mission default code
                "#Use input keyword to take inputs.\n" +
                "#Example:\n" +
                "#Input $FIRSTNUMBER\n" +
                "#SHOOT $FIRSTNUMBER + 3\n" +
                "#OR\n" +
                "#Input $FIRSTNUMBER\n" +
                "#$CALCULATEDVALUE = $FIRSTNUMBER + 3\n" +
                "#SHOOT $CALCULATEDVALUE\n\n" +
                "INPUT $MYVARIABLE\n" +
                "SHOOT 3 + $MYVARIABLE",
                // Mission inputs
                inputs,
                // Mission solutions
                Solutions()
                );
        }
    }
}