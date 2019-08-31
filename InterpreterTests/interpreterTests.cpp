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

        void Begin(bool isDebugShoot = true)
        {
            saveFile(fileContents);
            interpreter = std::make_shared<Interpreter>(filePath);
            interpreter->SetDebugMode(isDebugShoot);
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
            ss << "INPUT $MYVARIABLE\n" <<
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
            ss << "INPUT $NUMBER\n" <<
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

        TEST_METHOD(DEBUG)
        {
            filePath = "..\\TestFiles\\DEBUG.sfk";

            std::ostringstream ss;
            ss << "DEBUG 5\n" <<
                "DEBUG 7 + 8\n" <<
                "$FIVE = 5\n" <<
                "DEBUG $FIVE\n" <<
                "DEBUG \"GOOD GAME\"\n" <<
                "INPUT $NUMBER\n" <<
                "$RESULT = $NUMBER % 2\n" <<
                "DEBUG $RESULT\n" <<
                "IF $RESULT == 0 THEN\n" <<
                "   SHOOT 0\n" <<
                "ELSE\n" <<
                "   SHOOT 1\n" <<
                "ENDIF" <<
                "DEBUG \"HAVE FUN\"";

            fileContents = ss.str();

            srand((int)time(0));
            int randomNumber = rand() % 100;
            inputs = { randomNumber };

            Begin();

            std::vector<int> outputs = interpreter->GiveOutputs();

            Assert::AreEqual(size_t(1), outputs.size());
            Assert::AreEqual(randomNumber % 2, outputs[0]);

            std::vector<std::string> debugOutputs = interpreter->GiveDebugOutputs();

            Assert::AreEqual(size_t(7), debugOutputs.size());
            Assert::AreEqual("DEBUG: \"NUMBER\": 5", debugOutputs[0].c_str());
            Assert::AreEqual("DEBUG: \"EXPRESSION\": 7+8 = 15", debugOutputs[1].c_str());
            Assert::AreEqual("DEBUG: \"VARIABLE\": FIVE = 5", debugOutputs[2].c_str());
            Assert::AreEqual("DEBUG: \"STRING\": GOOD GAME", debugOutputs[3].c_str());
            Assert::AreEqual("DEBUG: \"VARIABLE\": RESULT = " + std::to_string(randomNumber % 2), debugOutputs[4]);
            Assert::AreEqual("SHOOT: \"NUMBER\": " + std::to_string(randomNumber % 2), debugOutputs[5]);
            Assert::AreEqual("DEBUG: \"STRING\": HAVE FUN", debugOutputs[6].c_str());

            Begin(false);

            outputs = interpreter->GiveOutputs();

            Assert::AreEqual(size_t(1), outputs.size());
            Assert::AreEqual(randomNumber % 2, outputs[0]);

            debugOutputs = interpreter->GiveDebugOutputs();

            Assert::AreEqual(size_t(6), debugOutputs.size());
            Assert::AreEqual("DEBUG: \"NUMBER\": 5", debugOutputs[0].c_str());
            Assert::AreEqual("DEBUG: \"EXPRESSION\": 7+8 = 15", debugOutputs[1].c_str());
            Assert::AreEqual("DEBUG: \"VARIABLE\": FIVE = 5", debugOutputs[2].c_str());
            Assert::AreEqual("DEBUG: \"STRING\": GOOD GAME", debugOutputs[3].c_str());
            Assert::AreEqual("DEBUG: \"VARIABLE\": RESULT = " + std::to_string(randomNumber % 2), debugOutputs[4]);
            Assert::AreEqual("DEBUG: \"STRING\": HAVE FUN", debugOutputs[5].c_str());
        }
    };
}