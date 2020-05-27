namespace DessingPatterns
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento            
        }    

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal journal, string fileName, bool overwride = false)
        {
            if(overwride || !File.Exists(fileName))
                File.WriteAllText(fileName, journal.ToString());
        }
    }
}