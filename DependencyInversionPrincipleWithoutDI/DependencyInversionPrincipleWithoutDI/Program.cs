using System;
using System.IO;

namespace DependencyInversionPrinciple.WithoutDI
{
    public class File
    {
        private static StreamWriter _streamWriter;

        public static void InitializeStreamWriter(string filePath)
        {
            _streamWriter = new StreamWriter(filePath);
        }

        public static void Write(char character)
        {
            _streamWriter.Write(character);
        }

        public static void Dispose()
        {
            _streamWriter.Close();
            _streamWriter = null;
        }
    }

    public enum Target
    {
        Console,
        File
    }

    class Program
    {
        static void Main(string[] args)
        {
            Copy(Target.File);
        }

        private static void Copy(Target target)  //here
        {
            //originally this Copy function only supported writing to the Console
            //this became more complicated when adding the ability to write to file
            //here
            if (target == Target.File)
                File.InitializeStreamWriter("Text.txt");

            while (true)
            {
                var consoleKeyInfo = Console.ReadKey(true);
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                    break;
                //here
                if (target == Target.Console)
                    Console.Write(consoleKeyInfo.KeyChar);
                //here
                else if (target == Target.File)
                    File.Write(consoleKeyInfo.KeyChar);
            }

            //here
            if (target == Target.File)
                File.Dispose();
        }


        /// <summary>
        /// Original
        /// </summary>
        private static void Copy()
        {
            while (true)
            {
                var consoleKeyInfo = Console.ReadKey(true);
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                    return;

                Console.Write(consoleKeyInfo.KeyChar);
            }
        }
    }
}
