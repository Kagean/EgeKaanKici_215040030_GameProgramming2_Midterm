using MobileProgramming;

class Starter
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Eilhart is once again threatened by the Dragon.");
        await Task.Delay(2000);
        Console.WriteLine("Fortunately, the Dragon is sleeping in the Ege Castle in the North for now.");
        await Task.Delay(3000);
        Console.WriteLine("Our hero must reforge the shattered Excalibur and confront the Dragon before it's too late.");
        await Task.Delay(3000);
        Console.WriteLine("To do this, his mind must be as sharp as his sword and he must solve the riddles of the Sorcerers.");
        await Task.Delay(2000);
        Console.WriteLine("Use W/A/S/D keys to move and Esc key to exit.");
        await Task.Delay(1000);
        Console.WriteLine("Press Enter to start the game...");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        Console.Clear();
        Game game = new Game();
    }
}