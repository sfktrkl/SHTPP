#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <direct.h>
#include <ctime>
#include "CppUnitTest.h"
#include "../Interpreter/Interpreter.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace InterpreterTests
{
    TEST_CLASS(InterpreterTests)
    {
    private:
        void saveFile(std::string fileContents)
        {
            _mkdir("..\\TestFiles");
            std::ofstream myfile(filePath);
            myfile << fileContents;
            myfile.close();
        }

        const char* filePath;
        std::string fileContents;
        std::vector<int> inputs;
        std::shared_ptr<Interpreter> interpreter = nullptr;

        void Begin()
        {
            saveFile(fileContents);
            interpreter = std::make_shared<Interpreter>(filePath);
            interpreter->TakeInputs(inputs);
            interpreter->Execute();
        }
    public:
        TEST_METHOD(SHOOT)
        {
            filePath = "..\\TestFiles\\SHOOT.sfk";

            std::ostringstream ss;
            ss << "SHOOT 3 + 2";
            fileContents = ss.str();

            inputs = { };

            Begin();

            std::vector<int> outputs = interpreter->GiveOutputs();

            Assert::AreEqual(size_t(1), outputs.size());
            Assert::AreEqual(5, outputs[0]);
        }

        TEST_METHOD(INPUT)
        {
            filePath = "..\\TestFiles\\INPUT.sfk";

            std::ostringstream ss;
            ss  << "INPUT $MYVARIABLE\n" <<
                "SHOOT 3 + $MYVARIABLE";
            fileContents = ss.str();

            srand((int)time(0));
            int randomNumber = rand();
            inputs = { randomNumber };

            Begin();

            std::vector<int> outputs = interpreter->GiveOutputs();

            Assert::AreEqual(size_t(1), outputs.size());
            Assert::AreEqual(randomNumber + 3, outputs[0]);
        }

        TEST_METHOD(IF)
        {
            filePath = "..\\TestFiles\\IF.sfk";

            std::ostringstream ss;
            ss << "INPUT $NUMBER\n" <<
                "IF $NUMBER % 2 == 0 THEN\n" <<
                "   SHOOT 0\n" <<
                "ELSE\n" <<
                "   SHOOT 1\n" <<
                "ENDIF";

            fileContents = ss.str();

            srand((int)time(0));
            int randomNumber = rand() % 100;
            inputs = { randomNumber };

            Begin();

            std::vector<int> outputs = interpreter->GiveOutputs();

            Assert::AreEqual(size_t(1), outputs.size());
            Assert::AreEqual(randomNumber % 2, outputs[0]);
        }

        TEST_METHOD(NESTEDIF)
        {
            filePath = "..\\TestFiles\\NESTEDIF.sfk";

            std::ostringstream ss;
            ss  << "INPUT $NUMBER\n" <<
                "$RESULT = $NUMBER % 2\n" <<
                "IF $RESULT == 0 THEN\n" <<
                "   SHOOT 0\n" <<
                "   IF $RESULT == 0 THEN\n" <<
                "       SHOOT 0\n" <<
                "       IF $RESULT == 1 THEN\n" <<
                "           SHOOT 0\n" <<
                "       ENDIF\n" <<
                "   ENDIF\n" <<
                "ELSE\n" <<
                "   SHOOT 1\n" <<
                "   IF $RESULT == 1 THEN\n" <<
                "       SHOOT 1\n" <<
                "   ENDIF\n" <<
                "   IF $RESULT == 0 THEN\n" <<
                "       SHOOT 0\n" <<
                "   ENDIF\n" <<
                "ENDIF";

            fileContents = ss.str();

            srand((int)time(0));
            int randomNumber = rand() % 100;
            inputs = { randomNumber };

            Begin();

            std::vector<int> outputs = interpreter->GiveOutputs();

            Assert::AreEqual(size_t(2), outputs.size());
            Assert::AreEqual(randomNumber % 2, outputs[0]);
            Assert::AreEqual(randomNumber % 2, outputs[1]);
        }

	};
}