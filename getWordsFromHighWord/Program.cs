using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace getWordsFromHighWord
{
    class Program
    {
        const string rusHighLetters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        static bool wordStartsWithHigh(string word)
        {
            foreach(char highC in rusHighLetters)
            {
                if (word.StartsWith(highC))
                {
                    return true;
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            string[] splitWords = new string[0];
            try
            {
                splitWords = File.ReadAllText("words.txt", Encoding.UTF8).Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch(Exception)
            {
                Console.WriteLine("Can not find 'words.txt'");
            }
            
            List<string> wordsWhichHigh = new List<string>();
            
            foreach(string word in splitWords)
            {
                if (wordStartsWithHigh(word))
                {
                    wordsWhichHigh.Add(word);
                }
            }

            using (StreamWriter writer = new StreamWriter("savedWords.txt"))
            {
                foreach(string highWord in wordsWhichHigh)
                {
                    writer.WriteLine(highWord);
                }
            }
        }
    }
}
