namespace DependencyInversionPrinciple.WithDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            //var writer = new FileWriter("Text.txt");
            var copyProcess = new CopyProcess(reader, writer);

            //Run the actual program
            copyProcess.Execute();

            
            //writer.Dispose();  //not neccessary for console writer
        }
    }
}
