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
            if (mission == "1")
                return Tutorial1();
            else if (mission == "2")
                return Tutorial2();
            else if (mission == "3")
                return Tutorial3();
            else if (mission == "4")
                return Tutorial4();
            else if (mission == "6")
                return Tutorial6();
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

        private static Data Tutorial2()
        {
            int[] inputs = new int[1];

            Func<int[]> Solutions = delegate
            {
                int[] solutions = new int[inputs.Length];

                for (int i = 0; i < inputs.Length; i++)
                    solutions[i] = 20;

                return solutions;
            };

            return new Data(
            //Mission number
            2,
            // Mission Name
            "Tutorial 2",
            // Mission Note
            "Aim of this tutorial is to learn how to create variables and use them. " +
            "To declare a variable use $ and give a variable name. " +
            "To define this variable you can simply use = with giving its value. " +
            "It is again possible using any expression or value.\n" +
            "Be careful, pressing ENTER is meant to pass to the next instruction.\n" +
            "If you keep writing without pressing ENTER to the next line, it will be considered as one line. ",
            // Mission default code
            "#Create a variable using $\n" +
            "#It is possible using a value or an expression\n" +
            "#Example:\n" +
            "#$NUMBER = 3 + 2\n" +
            "#SHOOT $NUMBER\n" +
            "#OR\n" +
            "#$NUMBER = 5\n" +
            "#SHOOT $NUMBER\n" +
            "#OR\n" +
            "#SHOOT 20\n\n" +
            "$FIRST = 3 + 2\n" +
            "$SECOND = 7 + 8\n\n" +
            "SHOOT $FIRST + $SECOND",
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

        private static Data Tutorial4()
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
                    solutions[i] = inputs[i] % 2;

                return solutions;
            };

            return new Data(
                //Mission number
                4,
                // Mission Name
                "Tutorial 4",
                // Mission Note
                "Aim of this tutorial is to learn how to use if else statements. " +
                "IF keyword is used for evaluating the test expression. " +
                "After the test expression THEN keyword should be used to jump to body. " +
                "Body should also end with the ENDIF keyword.\n" +
                "Inputs: Single integer number. \n" + 
                "Output: Shoot 1 for odd, 0 for even number.",
                // Mission default code
                "#Use IF, THEN and ENDIF keywords.\n" +
                "#Example:\n" +
                "#IF 5 == 5 THEN\n" +
                "#   SHOOT 1\n" +
                "#ENDIF\n\n" +
                "INPUT $NUMBER\n\n" +
                "IF $NUMBER % 2 == 0 THEN\n" +
                "   SHOOT 0\n" +
                "ELSE\n" + 
                "   SHOOT 1\n" +
                "ENDIF\n\n",
                // Mission inputs
                inputs,
                // Mission solutions
                Solutions()
                );
        }

        private static Data Tutorial6()
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
                    solutions[i] = inputs[i] % 2;

                return solutions;
            };

            return new Data(
                //Mission number
                6,
                // Mission Name
                "Tutorial 6",
                // Mission Note
                "Aim of this tutorial is to learn how to use debugging. " +
                "DEBUG keyword is used for printing any variable, expression or value to debug screen. " +
                "SHOOT keyword can also prints the results to the debug screen. " +
                "You can choose printing SHOOT keyword outputs or not.\n" +
                "Relax, Debug keyword will not effect any of your return values.\n" +
                "Inputs: Single integer number. " +
                "Output: SHOOT 1 for odd, 0 for even number.",
                // Mission default code
                "#Use DEBUG keyword to print to debug screen.\n" +
                "#Example:\n" +
                "#DEBUG 5\n" +
                "#DEBUG 3 + 2\n" +
                "#$FIVE = 5\n" +
                "#DEBUG \"GIVE ME FIVE\"\n" +
                "#DEBUG $FIVE\n\n" +
                "INPUT $NUMBER\n\n" +
                "$RESULT = $NUMBER % 2\n" +
                "DEBUG $RESULT\n" +
                "IF $RESULT == 0 THEN\n" +
                "   SHOOT 0\n" +
                "ELSE\n" +
                "   SHOOT 1\n" +
                "ENDIF\n\n" +
                "DEBUG \"HAVE FUN\"",
                // Mission inputs
                inputs,
                // Mission solutions
                Solutions()
                );
        }
    }
}