/*
Name: Kate Mudrow
Date: 9/22/2025
Lab: Lab 4-Game of Sticks
Professor: Mike Lewellen*/


Console.Clear();
string welcome = @"
----------------------------
Welcome to a Game of Sticks!
----------------------------";

Console.WriteLine($"{welcome}");
Console.WriteLine("Here are the rules:");
Console.WriteLine("Players will take turns choosing at least 1 and\nno more than 3 of the remaining sticks until the sticks are gone.\nThe player that takes the last stick loses.");
Console.WriteLine();
Console.WriteLine("Press any key to continue:");
Console.ReadKey(true);
Console.Clear();

int totalSticks = 20;
int currentPlayer = 1;
int maxSticksTake = 3;

Console.ForegroundColor = ConsoleColor.Red;
do
{
    if (totalSticks < 3)
    {
        maxSticksTake = totalSticks;
    }
    else
    {
        maxSticksTake = 3;
    }

    Console.SetCursorPosition(0, 0);
    Console.Write($"Sticks left: {totalSticks} ");

    for (int i = 0; i < totalSticks; i++)
    {
        Console.Write("|");
    }

    Console.SetCursorPosition(0, 2);
    Console.Write($"Player {currentPlayer}, how many sticks would you like to take? ");
    string? playerSticksChoice = Console.ReadLine();
    int sticksTaken;
    Console.Clear();

    if (!int.TryParse(playerSticksChoice, out sticksTaken))
    {
        Console.SetCursorPosition(0, 3);
        Console.WriteLine($"Invalid entry. Please enter a number betwen 1 - {maxSticksTake}");
        continue;
    }
    else if (sticksTaken > maxSticksTake)
    {
        Console.SetCursorPosition(0, 3);
        Console.WriteLine("You can't take that many sticks. Pick again.");
        continue;
    }
    else if (sticksTaken <= 0)
    {
        Console.SetCursorPosition(0, 3);
        Console.WriteLine("You must take at least 1 stick.");
        continue;
    }
    else
    {
        totalSticks -= sticksTaken;
    }

    if (currentPlayer == 1)
    {
        currentPlayer = 2;
        Console.ForegroundColor = ConsoleColor.Blue;
    }
    else
    {
        currentPlayer = 1;
        Console.ForegroundColor = ConsoleColor.Red;
    }

}
while (totalSticks > 0);

Console.Clear();
if (currentPlayer == 1)
    Console.ForegroundColor = ConsoleColor.Red;
else
    Console.ForegroundColor = ConsoleColor.Blue;

string winner = @$"
/------------------------\
|Player {currentPlayer} is the winner! |
\------------------------/";

Console.Write($"{winner}");

Console.ForegroundColor = ConsoleColor.White;