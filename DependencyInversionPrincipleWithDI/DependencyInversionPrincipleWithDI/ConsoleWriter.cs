using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.WithDI
{
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
}
