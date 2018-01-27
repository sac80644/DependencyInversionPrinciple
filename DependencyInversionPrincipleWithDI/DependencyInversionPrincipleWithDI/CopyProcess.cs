using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.WithDI
{
    public class CopyProcess
    {

        private readonly IReader _reader;
        private readonly IWriter _writer;

        /// <summary>
        ///Constructor Injection 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        public CopyProcess(IReader reader, IWriter writer)
        {
            if (reader == null) throw new ArgumentNullException("reader");
            if (writer == null) throw new ArgumentNullException("writer");

            _reader = reader;
            _writer = writer;
        }

        //Last step is to move the main copy code to this new generic function
        public void Execute()
        {
            while (true)
            {
                var readResult = _reader.Read();
                if (readResult.ShouldQuit)
                    break;
                _writer.Write(readResult.Character);
            }
        }
    }
}
