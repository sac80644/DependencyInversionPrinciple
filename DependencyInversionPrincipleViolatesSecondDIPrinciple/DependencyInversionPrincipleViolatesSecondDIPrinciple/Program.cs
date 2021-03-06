﻿using System;
using System.IO;

namespace DependencyInversionPrinciple.ViolatesSecondDIPrinciple
{
    public interface IReader
    {
        //This violates the 2nd part of DI.  The abstraction should not depend on details.
        //What is we wanted to read from another input instead of Console?
        ConsoleKeyInfo Read();
    }

    //New Console Reader class to implement the abstraction IReader
    public class ConsoleReader : IReader
    {
        public interface IReader
        {
            //This violates the 2nd part of DI.  The abstraction should not depend on details.
            //What is we wanted to read from another input instead of Console?
            ConsoleKeyInfo Read();

        }

        public ConsoleKeyInfo Read()
        {
            return Console.ReadKey(true);
        }
    }

    public interface IWriter
    {
        void Write(char character);
    }

    public class ConsoleWriter : IWriter
    {
        public void Write(char character)
        {
            Console.Write(character);
        }
    }

    //Replaced the File Class
    //Now this implements the abstraction IWriter which the high level code can use
    public class FileWriter : IWriter, IDisposable
    {
        private readonly StreamWriter _streamWriter;

        public FileWriter(string filePath)
        {
            _streamWriter = new StreamWriter(filePath);
        }

        public void Dispose()
        {
            _streamWriter.Dispose();
        }

        public void Write(char character)
        {
            _streamWriter.Write(character);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Composition Root Pattern - we still need to know what concrete classes to use and instantiate
            var reader = new ConsoleReader();

            //Use either ConsoleWriter or FileWriter specified in the Composition Root
            //var writer = new ConsoleWriter();
            var writer = new FileWriter("Text.txt");

            //inject the dependencies
            Copy(reader, writer);

            writer.Dispose();
        }

        private static void Copy(IReader reader, IWriter writer)    //This is dependency injection
        {
            //IReader reader = new ConsoleReader();     //This is tight coupling - lame
            //IWriter writer = new ConsoleWriter();     //An interface is meant to shield the high level 
            //from referencing the concrete class directly
            //If we used this high level code has to "know" about the specific class
            //Instead we will use dependency injection above

            //Copy is now programming only against the IWriter and IReader abstractions
            //There is no other dependency to concrete classes

            while (true)
            {
                var consoleKeyInfo = reader.Read();

                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                    break;
                writer.Write(consoleKeyInfo.KeyChar);
            }
        }
    }
}
