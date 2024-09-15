int R1_C1 = 0, R1_C2 = 0, R1_C3 = 0;
int R2_C1 = 0, R2_C2 = 0, R2_C3 = 0;
int R3_C1 = 0, R3_C2 = 0, R3_C3 = 0;

string colorR1_C1, colorR1_C2, colorR1_C3;
string colorR2_C1, colorR2_C2, colorR2_C3;
string colorR3_C1, colorR3_C2, colorR3_C3;

int tempR1_C1, tempR1_C2, tempR1_C3;
int tempR2_C1, tempR2_C2, tempR2_C3;
int tempR3_C1, tempR3_C2, tempR3_C3;

int resetR1_C1, resetR1_C2, resetR1_C3;
int resetR2_C1, resetR2_C2, resetR2_C3;
int resetR3_C1, resetR3_C2, resetR3_C3;

// Values For Game Screen
string playerNumber = "";
char playerCommand = ' ';
bool scoreIsValid = false;
bool newRound = false;
int playerScore = 0;
int opponentScore = 0;
int roundCount = 1;

//Values For Score Calculation
int boardScore;
int minMoveScore;
int maxMoveScore;

int minNextMove;
int bestNextMove;
int crossMove;
bool crossCheck;

// Values For Turn Determination
bool playerTurn;
bool computerTurn;

// Values For Random Board Creation
Random random = new Random();
int varAssign;
bool varAssigned;

// 
char modeCommand;
char diffCommand;
int gameMode;
int computerDiff = 0;

// Game Info Screen
Console.Write(
"                \x1b[33mWelcome to the SHIFT                                ---------------------------------------------------\x1b[39m\n" +
"-SHIFT is played on a 3x3 board contain 1-9 numbers.                \x1b[33m|\x1b[39m\n" +
"-You will play against to a computer or player by turns.            \x1b[33m|\x1b[39m\n" +
"-Your goal is trying to get the maximum score.                      \x1b[33m|\x1b[39m\n" +
"-You can get score by creating number series                        \x1b[33m|\x1b[39m\n" +
"ascending or descending order in horizontal, vertical or diagonal.  \x1b[33m|\x1b[39m\n" +
"\x1b[92m--You will get:\x1b[39m                                                     \x1b[33m|\x1b[39m\n" +
"    \x1b[92m1 point for 1 series \x1b[39m                                           \x1b[33m|\x1b[39m\n" +
"    \x1b[92m4 point for 2 series \x1b[39m                                           \x1b[33m|\x1b[39m\n" +
"    \x1b[92m9 point for 3 series \x1b[39m                                           \x1b[33m|\x1b[39m\n" +
"\x1b[94m--You can change the board with 6 different types of move:\x1b[39m          \x1b[33m|\x1b[39m\n" +
"    \x1b[94mMove 1: Shifts First Row       Move 4: Shifts First Column\x1b[39m      \x1b[33m|\x1b[39m\n" +
"    \x1b[94mMove 2: Shifts Second Row      Move 5: Shifts Second Column\x1b[39m     \x1b[33m|\x1b[39m\n" +
"    \x1b[94mMove 3: Shifts Third Row       Move 6: Shifts Third Column\x1b[39m      \x1b[33m|\x1b[39m\n" +
"\x1b[94m-You can just shifts rows to right and columns to down.\x1b[39m             \x1b[33m|\x1b[39m\n" +
"\x1b[94m-You can get a tip about current board with typing \"\x1b[92m?\x1b[94m\".\x1b[39m             \x1b[33m|\x1b[39m\n" +
"\x1b[95mNote: You can only get points from board\x1b[39m                            \x1b[33m|\x1b[39m\n" +
"\x1b[95mafter that round's board score drops to 0 at least once.\x1b[39m            \x1b[33m|\x1b[39m\n" +
"Sample Round:                                                       \x1b[33m|\x1b[39m\n" +
"    Round Start       After \x1b[94mMove 1\x1b[39m      After Move 3                \x1b[33m|\x1b[39m\n" +
"                                        Round Ends                  \x1b[33m|\x1b[39m\n" +
"    # # # # # # #     # # # # # # #     # # # # # # #               \x1b[33m|\x1b[39m\n" +
"    # \x1b[92m3   4   5\x1b[39m #     # \x1b[94m5   3   4\x1b[39m #     # 5   3   4 #               \x1b[33m|\x1b[39m\n" +
"    # 2   1   \x1b[92m6\x1b[39m #     # 2   1   6 #     # 2   1   6 #               \x1b[33m|\x1b[39m\n" +
"    # 8   9   \x1b[92m7\x1b[39m #     # 8   9   7 #     # \x1b[92m7   8   9\x1b[39m #               \x1b[33m|\x1b[39m\n" +
"    # # # # # # #     # # # # # # #     # # # # # # #               \x1b[33m|\x1b[39m\n" +
"                                                                    \x1b[33m|\x1b[39m\n" +
"    Board Score:4     Board Score:0     Board Score:1               \x1b[33m|\x1b[39m\n" +
"  \x1b[31mScore is Not Valid\x1b[39m                    \x1b[92mScore is Valid\x1b[39m              \x1b[33m|\x1b[39m\n" +
"\x1b[33m----------------------------------------------------------------------------------------------------------------------\x1b[39m");

// Reading Game Mode
while (true)
{

    Console.SetCursorPosition(69, 1);
    Console.WriteLine("Default Game Mode");
    Console.SetCursorPosition(69, 2);
    Console.WriteLine("    -Mode 0:Player vs Computer");
    Console.SetCursorPosition(69, 3);
    Console.WriteLine("Other Game Modes");
    Console.SetCursorPosition(69, 4);
    Console.WriteLine("    -Mode 1:Player vs Player");

    Console.SetCursorPosition(69, 5);
    Console.Write("\x1b[95mPls Enter Which Mode Do You Want to Play:    ");
    Console.SetCursorPosition(110, 5);

    char tempCommand = ' ';
    do
    {
        modeCommand = tempCommand;
        tempCommand = Console.ReadKey(true).KeyChar;
        Console.SetCursorPosition(110, 5);
        if (tempCommand == 8)
        {
            Console.Write("  ");
            Console.SetCursorPosition(110, 5);
            tempCommand = ' ';
        }
        else if (tempCommand != '\r')
        {
            Console.Write(tempCommand + " ");
            Console.SetCursorPosition(111, 5);
        }
    }
    while (tempCommand != '\r');
    Console.WriteLine("\x1b[39m");


    // Checking for the Validaiton of Game Mode
    if ((47 < modeCommand) && (modeCommand < 50))
    {
        gameMode = Convert.ToInt32(modeCommand) - 48;
        break;
    }
    else
    {
        Console.SetCursorPosition(69, 6);
        Console.WriteLine("\x1b[31mPls Enter a Valid Mode\x1b[39m");
        Console.SetCursorPosition(69, 6);
        Thread.Sleep(500);
        Console.SetCursorPosition(69, 6);
        Console.WriteLine("                                      ");
    }
}

if (gameMode == 1)
    playerNumber = "1";

// Reading Computer Difficulty
while (gameMode == 0)
{

    Console.SetCursorPosition(69, 7);
    Console.WriteLine("Computer Difficulties");
    Console.SetCursorPosition(69, 8);
    Console.WriteLine("    \x1b[92m-Difficulty 1:Newbie\x1b[39m");
    Console.SetCursorPosition(69, 9);
    Console.WriteLine("    \x1b[94m-Difficulty 2:Default(Normal)\x1b[39m");
    Console.SetCursorPosition(69, 10);
    Console.WriteLine("    \x1b[31m-Difficulty 3:Heartbreaker\x1b[39m");
    Console.SetCursorPosition(69, 11);

    Console.Write("\x1b[95mPls Enter Which Computer Difficulty Do You Want: ");
    Console.SetCursorPosition(117, 11);

    char tempCommand = ' ';
    do
    {
        diffCommand = tempCommand;
        tempCommand = Console.ReadKey(true).KeyChar;
        Console.SetCursorPosition(117, 11);
        if (tempCommand == 8)
        {
            Console.Write("  ");
            Console.SetCursorPosition(117, 11);
            tempCommand = ' ';
        }
        else if (tempCommand != '\r')
        {
            Console.Write(tempCommand + " ");
            Console.SetCursorPosition(118, 11);
        }
    }
    while (tempCommand != '\r');
    Console.WriteLine("\x1b[39m");


    // Checking for the Validaiton of Player Move
    if ((48 < diffCommand) && (diffCommand < 52))
    {
        computerDiff = Convert.ToInt32(diffCommand) - 48;
        break;
    }
    else
    {
        Console.SetCursorPosition(69, 12);
        Console.WriteLine("\x1b[31mPls Enter a Valid Difficulty\x1b[39m");
        Console.SetCursorPosition(69, 12);
        Thread.Sleep(500);
        Console.SetCursorPosition(69, 12);
        Console.WriteLine("                                      ");
    }
}

// Cleaning Screen
for (int top = 1; top < 27; top++)
{
    Console.SetCursorPosition(69, top);
    Console.WriteLine("                                                   ");
}
Console.SetCursorPosition(69, 1);
Console.WriteLine("        \x1b[95mPls Enter the Board(Digit by Digit)\x1b[39m");

Console.WriteLine("\x1b[95m");
Console.SetCursorPosition(85, 4);
Console.WriteLine("###################");
for (int top = 5; top < 12; top++)
{
    Console.SetCursorPosition(85, top);
    Console.WriteLine("##               ##");
}
Console.SetCursorPosition(85, 12);
Console.WriteLine("###################");
Console.WriteLine("\x1b[39m");

// Reading the Board From Initiator
char tempReading;
int tempReadingInt;
int varAssigment = 0;

// top and left Variables Set Cursor Position
for (int top = 6; top < 11; top += 2)
{
    for (int left = 90; left < 99; left += 4)
    {
        while (true)
        {
            Console.SetCursorPosition(left, top);
            char tempCommand = ' ';
            do
            {
                tempReading = tempCommand;
                tempCommand = Console.ReadKey(true).KeyChar;
                Console.SetCursorPosition(left, top);
                if (tempCommand == 8)
                {
                    Console.Write("  ");
                    Console.SetCursorPosition(left, top);
                    tempCommand = ' ';
                }
                else if (tempCommand != '\r')
                {
                    Console.Write(tempCommand + " ");
                    Console.SetCursorPosition(left + 1, top);
                }
            }
            while (tempCommand != '\r');
            if (!((48 < tempReading) && (tempReading < 58)))
            {
                Console.SetCursorPosition(left, top);
                Console.Write(" ");
                Console.SetCursorPosition(80, 13);
                Console.WriteLine("\x1b[31mPls Enter a Digit Except Zero\x1b[39m");
                Console.SetCursorPosition(left, top);
                Thread.Sleep(1000);
                Console.SetCursorPosition(80, 13);
                Console.WriteLine("                             ");
                continue;
            }
            tempReadingInt = Convert.ToInt32(tempReading) - 48;
            if ((tempReadingInt != R1_C1) && (tempReadingInt != R1_C2) && (tempReadingInt != R1_C3) &&
                (tempReadingInt != R2_C1) && (tempReadingInt != R2_C2) && (tempReadingInt != R2_C3) &&
                (tempReadingInt != R3_C1) && (tempReadingInt != R3_C2) && (tempReadingInt != R3_C3))
            {
                break;
            }
            else
            {
                Console.SetCursorPosition(left, top);
                Console.Write(" ");
                Console.SetCursorPosition(78, 13);
                Console.WriteLine("\x1b[31mBoard Can Not Contain Same Digits\x1b[39m");
                Console.SetCursorPosition(78, 14);
                Console.WriteLine("\x1b[31mPls Enter a Different Digit\x1b[39m");
                Console.SetCursorPosition(left, top);
                Thread.Sleep(2000);
                Console.SetCursorPosition(78, 13);
                Console.WriteLine("                                   ");
                Console.SetCursorPosition(78, 14);
                Console.WriteLine("                              ");

            }
        }
        varAssigment++;
        if (varAssigment == 1) R1_C1 = tempReadingInt;
        else if (varAssigment == 2) R1_C2 = tempReadingInt;
        else if (varAssigment == 3) R1_C3 = tempReadingInt;
        else if (varAssigment == 4) R2_C1 = tempReadingInt;
        else if (varAssigment == 5) R2_C2 = tempReadingInt;
        else if (varAssigment == 6) R2_C3 = tempReadingInt;
        else if (varAssigment == 7) R3_C1 = tempReadingInt;
        else if (varAssigment == 8) R3_C2 = tempReadingInt;
        else if (varAssigment == 9) R3_C3 = tempReadingInt;
    }
}

// Cleaning Screen
for (int top = 1; top < 27; top++)
{
    Console.SetCursorPosition(69, top);
    Console.WriteLine("                                                   ");
}
// Creating Game Play Screen
Console.SetCursorPosition(90, 6);
Console.WriteLine("\x1b[94m4   5   6\x1b[39m");
Console.SetCursorPosition(90, 7);
Console.WriteLine("\x1b[94m↓   ↓   ↓\x1b[39m");
Console.SetCursorPosition(85, 8);
Console.WriteLine("\x1b[33m###################\x1b[39m");
int moveName = 1;
for (int top = 9; top < 16; top++)
{
    if (top % 2 == 1)
    {
        Console.SetCursorPosition(85, top);
        Console.WriteLine("##               ##");
    }
    else
    {
        Console.SetCursorPosition(81, top);
        Console.WriteLine("\x1b[94m" + moveName + " → \x1b[33m##               ##\x1b[39m");
        moveName++;
    }
}

Console.SetCursorPosition(85, 16);
Console.WriteLine("\x1b[33m###################\x1b[39m");


Console.SetCursorPosition(69, 1);
if (gameMode == 0)
    Console.WriteLine("\x1b[92mPlayer Score: 0\x1b[39m                   \x1b[31mComputer Score: 0\x1b[39m");
else
    Console.WriteLine("\x1b[92mPlayer 1 Score: 0\x1b[39m                \x1b[31mPlayer 2 Score: 0\x1b[39m");

Console.SetCursorPosition(69, 2);
Console.WriteLine("                 \x1b[95m-----Round 1-----\x1b[39m                 ");
Console.SetCursorPosition(69, 3);
Console.WriteLine("                 \x1b[33m-Board Score:  0-\x1b[39m                 ");
Console.SetCursorPosition(90, 10);
Console.WriteLine(R1_C1 + "   " + R1_C2 + "   " + R1_C3);
Console.SetCursorPosition(90, 12);
Console.WriteLine(R2_C1 + "   " + R2_C2 + "   " + R2_C3);
Console.SetCursorPosition(90, 14);
Console.WriteLine(R3_C1 + "   " + R3_C2 + "   " + R3_C3);

while (roundCount < 6)
{
    if (newRound)
    {
        // -- Random Board Creation

        // Resetting Board Values to 0
        R1_C1 = 0; R1_C2 = 0; R1_C3 = 0;
        R2_C1 = 0; R2_C2 = 0; R2_C3 = 0;
        R3_C1 = 0; R3_C2 = 0; R3_C3 = 0;

        // Assign Values to the Board Variables 
        for (int Value = 1; Value < 10; Value++)
        {
            varAssign = random.Next(1, 10);
            varAssigned = false;
            while (!varAssigned)
            {
                switch (varAssign)
                {
                    case 1:
                        if (R1_C1 == 0)
                        {
                            R1_C1 = Value;
                            varAssigned = true;
                        }
                        else
                            varAssign++;
                        break;

                    case 2:
                        if (R1_C2 == 0)
                        {
                            R1_C2 = Value;
                            varAssigned = true;
                        }
                        else
                            varAssign++;
                        break;
                    case 3:
                        if (R1_C3 == 0)
                        {
                            R1_C3 = Value;
                            varAssigned = true;
                        }
                        else
                            varAssign++;
                        break;
                    case 4:
                        if (R2_C1 == 0)
                        {
                            R2_C1 = Value;
                            varAssigned = true;
                        }

                        else
                            varAssign++;
                        break;
                    case 5:
                        if (R2_C2 == 0)
                        {
                            R2_C2 = Value;
                            varAssigned = true;
                        }
                        else
                            varAssign++;
                        break;
                    case 6:
                        if (R2_C3 == 0)
                        {
                            R2_C3 = Value;
                            varAssigned = true;
                        }
                        else
                            varAssign++;
                        break;
                    case 7:
                        if (R3_C1 == 0)
                        {
                            R3_C1 = Value;
                            varAssigned = true;
                        }
                        else
                            varAssign++;
                        break;
                    case 8:
                        if (R3_C2 == 0)
                        {
                            R3_C2 = Value;
                            varAssigned = true;
                        }
                        else
                            varAssign++;
                        break;
                    case 9:
                        if (R3_C3 == 0)
                        {
                            R3_C3 = Value;
                            varAssigned = true;
                        }
                        else
                            varAssign = 1;
                        break;
                }
            }
        }


        scoreIsValid = false;
        newRound = false;

        Console.SetCursorPosition(69, 1);
        Console.WriteLine("                                                    ");
        Console.SetCursorPosition(69, 1);
        if (gameMode == 0)
            Console.WriteLine("\x1b[92mPlayer Score: " + playerScore + "\x1b[39m                   \x1b[31mComputer Score: " + opponentScore + "\x1b[39m");
        else
            Console.WriteLine("\x1b[92mPlayer 1 Score: " + playerScore + "\x1b[39m                \x1b[31mPlayer 2 Score: " + opponentScore + "\x1b[39m");
        Thread.Sleep(1000);
        Console.SetCursorPosition(69, 2);
        Console.WriteLine("                 \x1b[95m-----Round " + roundCount + "-----\x1b[39m                 ");
        Console.SetCursorPosition(90, 10);
        Console.Write(R1_C1 + "   " + R1_C2 + "   " + R1_C3);
        Console.SetCursorPosition(90, 12);
        Console.Write(R2_C1 + "   " + R2_C2 + "   " + R2_C3);
        Console.SetCursorPosition(90, 14);
        Console.Write(R3_C1 + "   " + R3_C2 + "   " + R3_C3);
    }
    //Values For Score and Move Calculations
    minMoveScore = 9;
    maxMoveScore = 0;

    minNextMove = random.Next(1, 7);
    bestNextMove = random.Next(1, 7);
    crossMove = random.Next(1, 7);

    // Values For Turn Determination
    playerTurn = true;
    computerTurn = false;


    // Saving Board For Help Command
    resetR1_C1 = R1_C1; resetR1_C2 = R1_C2; resetR1_C3 = R1_C3;
    resetR2_C1 = R2_C1; resetR2_C2 = R2_C2; resetR2_C3 = R2_C3;
    resetR3_C1 = R3_C1; resetR3_C2 = R3_C2; resetR3_C3 = R3_C3;

    // Move Command  -1: Score Check For Board Validation
    // Move Command   0: Reading Player Move
    // Move Command 1-6: Move Score Calculations

    for (int moveCommand = -1; moveCommand < 7; moveCommand++)
    {
        // Reading Player Move
        if (moveCommand == 0)
        {
            Console.SetCursorPosition(69, 4);
            Console.WriteLine("                                                   ");
            Console.SetCursorPosition(69, 4);
            if (gameMode == 0)
                Console.WriteLine("                 \x1b[92m-  Player Turn  -\x1b[39m                 ");
            else if (gameMode == 1)
                Console.WriteLine("                 \x1b[92m- Player " + playerNumber + " Turn -\x1b[39m                 ");

            while (playerTurn)
            {
                // Reading Player Move
                Console.SetCursorPosition(69, 18);
                Console.Write("\x1b[94mPls Enter Which Move Do You Want to Make: ");
                Console.SetCursorPosition(110, 18);
                char tempCommand = ' ';
                do
                {
                    playerCommand = tempCommand;
                    tempCommand = Console.ReadKey(true).KeyChar;
                    Console.SetCursorPosition(110, 18);
                    if (tempCommand == 8)
                    {
                        Console.Write("  ");
                        Console.SetCursorPosition(110, 18);
                        tempCommand = ' ';
                    }
                    else if (tempCommand != '\r')
                    {
                        Console.Write(tempCommand + " ");
                        Console.SetCursorPosition(111, 18);
                    }
                }
                while (tempCommand != '\r');

                Console.SetCursorPosition(112, 18);
                Console.WriteLine("\x1b[39m");


                // Checking For the Validaiton of Player Move
                if (playerCommand == '?')
                {
                    playerTurn = false;
                    moveCommand = 1;
                    break;
                }
                else if ((48 < playerCommand) && (playerCommand < 55))
                {
                    moveCommand = Convert.ToInt32(playerCommand) - 48;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(69, 19);
                    Console.WriteLine("\x1b[31mPls Enter a Valid Move\x1b[39m");
                    Console.SetCursorPosition(69, 19);
                    Thread.Sleep(500);
                    Console.SetCursorPosition(69, 19);
                    Console.WriteLine("                                      ");
                }
            }
        }

        // Reset Board Values Color
        colorR1_C1 = "\x1b[39m"; colorR1_C2 = "\x1b[39m"; colorR1_C3 = "\x1b[39m";
        colorR2_C1 = "\x1b[39m"; colorR2_C2 = "\x1b[39m"; colorR2_C3 = "\x1b[39m";
        colorR3_C1 = "\x1b[39m"; colorR3_C2 = "\x1b[39m"; colorR3_C3 = "\x1b[39m";

        // Shift Row_1
        if (moveCommand == 1)
        {
            tempR1_C1 = R1_C1;
            tempR1_C2 = R1_C2;
            tempR1_C3 = R1_C3;

            R1_C1 = tempR1_C3;
            R1_C2 = tempR1_C1;
            R1_C3 = tempR1_C2;

            colorR1_C1 = "\x1b[94m"; colorR1_C2 = "\x1b[94m"; colorR1_C3 = "\x1b[94m";
        }
        // Shift Row_2
        else if (moveCommand == 2)
        {
            tempR2_C1 = R2_C1;
            tempR2_C2 = R2_C2;
            tempR2_C3 = R2_C3;

            R2_C1 = tempR2_C3;
            R2_C2 = tempR2_C1;
            R2_C3 = tempR2_C2;

            colorR2_C1 = "\x1b[94m"; colorR2_C2 = "\x1b[94m"; colorR2_C3 = "\x1b[94m";
        }
        // Shift Row_3
        else if (moveCommand == 3)
        {
            tempR3_C1 = R3_C1;
            tempR3_C2 = R3_C2;
            tempR3_C3 = R3_C3;

            R3_C1 = tempR3_C3;
            R3_C2 = tempR3_C1;
            R3_C3 = tempR3_C2;

            colorR3_C1 = "\x1b[94m"; colorR3_C2 = "\x1b[94m"; colorR3_C3 = "\x1b[94m";
        }
        // Shift Column_1
        else if (moveCommand == 4)
        {
            tempR1_C1 = R1_C1;
            tempR2_C1 = R2_C1;
            tempR3_C1 = R3_C1;

            R1_C1 = tempR3_C1;
            R2_C1 = tempR1_C1;
            R3_C1 = tempR2_C1;

            colorR1_C1 = "\x1b[94m"; colorR2_C1 = "\x1b[94m"; colorR3_C1 = "\x1b[94m";
        }
        // Shift Column_2
        else if (moveCommand == 5)
        {
            tempR1_C2 = R1_C2;
            tempR2_C2 = R2_C2;
            tempR3_C2 = R3_C2;

            R1_C2 = tempR3_C2;
            R2_C2 = tempR1_C2;
            R3_C2 = tempR2_C2;

            colorR1_C2 = "\x1b[94m"; colorR2_C2 = "\x1b[94m"; colorR3_C2 = "\x1b[94m";
        }
        // Shift Column_3
        else if (moveCommand == 6)
        {
            tempR1_C3 = R1_C3;
            tempR2_C3 = R2_C3;
            tempR3_C3 = R3_C3;

            R1_C3 = tempR3_C3;
            R2_C3 = tempR1_C3;
            R3_C3 = tempR2_C3;

            colorR1_C3 = "\x1b[94m"; colorR2_C3 = "\x1b[94m"; colorR3_C3 = "\x1b[94m";
        }

        boardScore = 0;
        crossCheck = false;
        //First Row Score Check 
        if ((R1_C1 + 1 == R1_C2) && (R1_C2 == R1_C3 - 1) ||
            (R1_C1 - 1 == R1_C2) && (R1_C2 == R1_C3 + 1))
        {
            boardScore++;
            colorR1_C1 = "\x1b[92m"; colorR1_C2 = "\x1b[92m"; colorR1_C3 = "\x1b[92m";
        }
        //Second Row Score Check
        if ((R2_C1 + 1 == R2_C2) && (R2_C2 == R2_C3 - 1) ||
            (R2_C1 - 1 == R2_C2) && (R2_C2 == R2_C3 + 1))
        {
            boardScore++;
            colorR2_C1 = "\x1b[92m"; colorR2_C2 = "\x1b[92m"; colorR2_C3 = "\x1b[92m";
        }
        //Third Row Score Check
        if ((R3_C1 + 1 == R3_C2) && (R3_C2 == R3_C3 - 1) ||
            (R3_C1 - 1 == R3_C2) && (R3_C2 == R3_C3 + 1))
        {
            boardScore++;
            colorR3_C1 = "\x1b[92m"; colorR3_C2 = "\x1b[92m"; colorR3_C3 = "\x1b[92m";
        }
        //First Column  Score Check
        if ((R1_C1 + 1 == R2_C1) && (R2_C1 == R3_C1 - 1) ||
            (R1_C1 - 1 == R2_C1) && (R2_C1 == R3_C1 + 1))
        {
            boardScore++;
            colorR1_C1 = "\x1b[92m"; colorR2_C1 = "\x1b[92m"; colorR3_C1 = "\x1b[92m";
        }
        //Second Column Score Check
        if ((R1_C2 + 1 == R2_C2) && (R2_C2 == R3_C2 - 1) ||
            (R1_C2 - 1 == R2_C2) && (R2_C2 == R3_C2 + 1))
        {
            boardScore++;
            colorR1_C2 = "\x1b[92m"; colorR2_C2 = "\x1b[92m"; colorR3_C2 = "\x1b[92m";
        }
        //Third Column Score Check
        if ((R1_C3 - 1 == R2_C3) && (R2_C3 == R3_C3 + 1) ||
            (R1_C3 + 1 == R2_C3) && (R2_C3 == R3_C3 - 1))
        {
            boardScore++;
            colorR1_C3 = "\x1b[92m"; colorR2_C3 = "\x1b[92m"; colorR3_C3 = "\x1b[92m";
        }
        //Rigth To Left Cross Score Check
        if ((R1_C1 - 1 == R2_C2) && (R2_C2 == R3_C3 + 1) ||
            (R1_C1 + 1 == R2_C2) && (R2_C2 == R3_C3 - 1))
        {
            boardScore++;
            crossCheck = true;
            colorR1_C1 = "\x1b[92m"; colorR2_C2 = "\x1b[92m"; colorR3_C3 = "\x1b[92m";
        }
        //Left To Right Cross Score Check
        if ((R1_C3 - 1 == R2_C2) && (R2_C2 == R3_C1 + 1) ||
            (R1_C3 + 1 == R2_C2) && (R2_C2 == R3_C1 - 1))
        {
            boardScore++;
            crossCheck = true;
            colorR1_C3 = "\x1b[92m"; colorR2_C2 = "\x1b[92m"; colorR3_C1 = "\x1b[92m";
        }
        // Final Real Board Score
        boardScore = Convert.ToInt32(Math.Pow(boardScore, 2));

        // Check The Board Score Before Turn for Score Validation
        if (moveCommand == -1)
        {
            Console.SetCursorPosition(69, 3);
            Console.WriteLine("                 \x1b[33m-Board Score:  " + boardScore + "-\x1b[39m                 ");
            if (boardScore == 0)
                scoreIsValid = true;
            continue;
        }

        // Comparing Moves
        if (!computerTurn && !playerTurn)
        {
            if (crossCheck)
            {
                crossMove = moveCommand;
            }
            if (maxMoveScore < boardScore)
            {
                maxMoveScore = boardScore;
                bestNextMove = moveCommand;
            }
            if (minMoveScore > boardScore)
            {
                minMoveScore = boardScore;
                minNextMove = moveCommand;
            }
            // Reseting Board
            R1_C1 = resetR1_C1; R1_C2 = resetR1_C2; R1_C3 = resetR1_C3;
            R2_C1 = resetR2_C1; R2_C2 = resetR2_C2; R2_C3 = resetR2_C3;
            R3_C1 = resetR3_C1; R3_C2 = resetR3_C2; R3_C3 = resetR3_C3;
        }

        // Player Turn
        if (playerTurn)
        {
            Console.SetCursorPosition(69, 3);
            Console.WriteLine("                 \x1b[33m-Board Score:  " + boardScore + "-\x1b[39m                 ");
            Console.SetCursorPosition(90, 10);
            Console.Write(colorR1_C1 + R1_C1 + "   \x1b[39m" + colorR1_C2 + R1_C2 + "   \x1b[39m" + colorR1_C3 + R1_C3 + "\x1b[39m");
            Console.SetCursorPosition(90, 12);
            Console.Write(colorR2_C1 + R2_C1 + "   \x1b[39m" + colorR2_C2 + R2_C2 + "   \x1b[39m" + colorR2_C3 + R2_C3 + "\x1b[39m");
            Console.SetCursorPosition(90, 14);
            Console.Write(colorR3_C1 + R3_C1 + "   \x1b[39m" + colorR3_C2 + R3_C2 + "   \x1b[39m" + colorR3_C3 + R3_C3 + "\x1b[39m");

            // Giving Score to Player and Ending Round
            if (boardScore > 0 && scoreIsValid)
            {
                if (playerNumber == "1" || playerNumber == "")
                    playerScore += boardScore;
                else if (playerNumber == "2")
                    opponentScore += boardScore;
                newRound = true;
                roundCount += 1;
                Console.SetCursorPosition(69, 4);
                Console.WriteLine("                                                   ");
                Console.SetCursorPosition(69, 4);
                Console.WriteLine("                 \x1b[95m-   Round End   -\x1b[39m                 ");
                break;
            }

            // Checking Score Validation After Player Move
            if (boardScore == 0)
                scoreIsValid = true;

            if (gameMode == 0)
            {
                Console.SetCursorPosition(69, 4);
                Console.WriteLine("                                                   ");
                Console.SetCursorPosition(69, 4);
                Console.WriteLine("                 \x1b[31m- Computer Turn -\x1b[39m                 ");
            }
            else if (gameMode == 1)
            {
                if (playerNumber == "1")
                    playerNumber = "2";
                else if (playerNumber == "2")
                    playerNumber = "1";
                break;
            }

            // Computer Newbie Difficulty
            if (computerDiff == 1)
            {
                // Set MoveCommand to Avoid Unnecessary Move Calculations
                moveCommand = 6;
            }
            else
            {
                //Saving Board for Best Move Score Calculation
                resetR1_C1 = R1_C1; resetR1_C2 = R1_C2; resetR1_C3 = R1_C3;
                resetR2_C1 = R2_C1; resetR2_C2 = R2_C2; resetR2_C3 = R2_C3;
                resetR3_C1 = R3_C1; resetR3_C2 = R3_C2; resetR3_C3 = R3_C3;

                // Prepearing Move Command for Move Calculations
                moveCommand = 0;

            }
            playerTurn = false;
        }

        // Computer Turn
        if (computerTurn)
        {
            Console.SetCursorPosition(111, 18);
            Thread.Sleep(1500);
            Console.SetCursorPosition(90, 10);
            Console.Write(colorR1_C1 + R1_C1 + "   \x1b[39m" + colorR1_C2 + R1_C2 + "   \x1b[39m" + colorR1_C3 + R1_C3 + "\x1b[39m");
            Console.SetCursorPosition(90, 12);
            Console.Write(colorR2_C1 + R2_C1 + "   \x1b[39m" + colorR2_C2 + R2_C2 + "   \x1b[39m" + colorR2_C3 + R2_C3 + "\x1b[39m");
            Console.SetCursorPosition(90, 14);
            Console.Write(colorR3_C1 + R3_C1 + "   \x1b[39m" + colorR3_C2 + R3_C2 + "   \x1b[39m" + colorR3_C3 + R3_C3 + "\x1b[39m");

            // Giving Score to Computer and Ending Round
            if (boardScore > 0 && scoreIsValid)
            {
                opponentScore += boardScore;
                newRound = true;
                roundCount += 1;
            }
            // Checking Score Validation After Computer Move
            if (boardScore == 0)
                scoreIsValid = true;
            break;
        }

        // Ending Score Calculations
        if (moveCommand == 6)
        {
            // Player Help Command
            if (playerCommand == '?')
            {
                Console.SetCursorPosition(69, 19);
                if (!scoreIsValid)
                    Console.WriteLine("\x1b[95mScore Will be Not Valid.\x1b[39m");
                else if (maxMoveScore == 0)
                    Console.WriteLine("\x1b[31mThere is No Move With a Score.\x1b[39m");
                else
                    Console.WriteLine("\x1b[92mThe Next Best Move is:" + bestNextMove + "\x1b[39m");
                Thread.Sleep(1200);
                Console.SetCursorPosition(69, 19);
                Console.WriteLine("                                           ");

                // Reseting the Values for Player Turn
                moveCommand = -1;
                playerTurn = true;

                // Resetting the Values For Score and Move Calculations
                minMoveScore = 9;
                maxMoveScore = 0;

                minNextMove = random.Next(1, 7);
                bestNextMove = random.Next(1, 7);
                crossMove = random.Next(1, 7);
            }
            // Setting Computer's Next Move According to Selected Difficulty
            else if (computerDiff == 1)
            {
                moveCommand = random.Next(1, 7) - 1;
                computerTurn = true;
            }
            else if (computerDiff == 2)
            {
                if (scoreIsValid)
                    moveCommand = bestNextMove - 1;
                else
                    moveCommand = minNextMove - 1;
                computerTurn = true;
            }
            else if (computerDiff == 3)
            {
                if (scoreIsValid)
                    moveCommand = bestNextMove - 1;
                else
                    moveCommand = crossMove - 1;
                computerTurn = true;
            }
        }
    }
}
// Updating the Scores After Game Ends
Console.SetCursorPosition(69, 1);
if (gameMode == 0)
    Console.WriteLine("\x1b[92mPlayer Score: " + playerScore + "\x1b[39m                   \x1b[31mComputer Score: " + opponentScore + "\x1b[39m");
else
    Console.WriteLine("\x1b[92mPlayer 1 Score: " + playerScore + "\x1b[39m                \x1b[31mPlayer 2 Score: " + opponentScore + "\x1b[39m");


string GameEndColor;
if (playerScore > opponentScore)
    GameEndColor = "\x1b[92m";
else if (playerScore > opponentScore)
    GameEndColor = "";
else
    GameEndColor = "\x1b[95m";

Console.SetCursorPosition(69, 18);
Console.WriteLine("\x1b[33m--------------------------------------------------\x1b[39m");

Console.SetCursorPosition(69, 20);
Console.WriteLine("                 " + GameEndColor + "**************** \x1b[39m                 ");
Console.SetCursorPosition(69, 21);
Console.WriteLine("                 " + GameEndColor + "*              * \x1b[39m                 ");
Console.SetCursorPosition(69, 22);

if (playerScore > opponentScore)
{
    if (gameMode == 0)
        Console.WriteLine("                 \x1b[92m   Player Wins   \x1b[39m                 ");
    else
        Console.WriteLine("                 \x1b[92m  Player 1 Wins  \x1b[39m                 ");
}
else if (opponentScore > playerScore)
{
    if (gameMode == 0)
        Console.WriteLine("                \x1b[33m   Computer Wins   \x1b[39m                ");
    else
        Console.WriteLine("                 \x1b[33m  Player 2 Wins  \x1b[39m                 ");
}
else
{
    Console.WriteLine("                 \x1b[35m        Tie      \x1b[39m                 ");

}
Console.SetCursorPosition(69, 23);
Console.WriteLine("                 " + GameEndColor + "*              * \x1b[39m                 ");
Console.SetCursorPosition(69, 24);
Console.WriteLine("                 " + GameEndColor + "**************** \x1b[39m                 ");
Console.SetCursorPosition(69, 24);
// To See the Results After Game Ends
Console.ReadLine();