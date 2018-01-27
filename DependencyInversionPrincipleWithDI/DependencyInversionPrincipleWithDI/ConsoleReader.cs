using System;

namespace DependencyInversionPrinciple.WithDI
{
    public interface IReader
    {
        ReadResult Read();
    }

    public class ConsoleReader : IReader
    {
        public ReadResult Read()
        {
            var consoleKeyInfo = Console.ReadKey(true);
            return new ReadResult(consoleKeyInfo.KeyChar,
                                    consoleKeyInfo.Key == ConsoleKey.Escape);

        }
    }
}
