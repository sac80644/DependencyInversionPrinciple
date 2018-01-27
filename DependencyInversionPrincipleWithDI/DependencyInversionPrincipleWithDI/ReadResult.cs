namespace DependencyInversionPrinciple.WithDI
{
    public class ReadResult
    {
        public readonly char Character;
        public readonly bool ShouldQuit;

        public ReadResult(char character, bool shouldQuit)
        {
            Character = character;
            ShouldQuit = shouldQuit;
        }
    }
}