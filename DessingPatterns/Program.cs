namespace DessingPatterns
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            SingleResponsibilityMethod();
        }

        public static void SingleResponsibilityMethod()
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

            var persistence = new Persistence();
            var fileName = @"C:\Users\ivang\Downloads\journal.txt";
            persistence.SaveToFile(j, fileName, true);
            Process.Start(fileName);
        }
    }
}
