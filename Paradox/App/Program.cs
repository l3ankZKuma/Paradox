using System;

try
{
    using var game = new Paradox.Main();
    game.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
