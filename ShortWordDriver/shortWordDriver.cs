using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ShortWordDriver
{
    public static class shortWordDriver
    {
        public static readonly string STR_DLL_FULL_NAME = "ShortWordDriver.dll";
        private static readonly string SHORT_WORD_DATA_FILE_NAME = "база_коротких_слов.sw";
        public static List<ShortWord> shortWords = new List<ShortWord>();

        public static async void asyncReadDataFromFile()
        {
            await Task.Run(()=>readDataFromFile());
        }

        public static bool readyForRead()
        {
            return (shortWords != null && File.Exists(SHORT_WORD_DATA_FILE_NAME));
        }

        private static void readDataFromFile()
        {
            StreamReader reader = new StreamReader(SHORT_WORD_DATA_FILE_NAME);
            if (reader != null)
            {
                using (reader)
                {
                    try
                    {
                        shortWords.Add(ShortWord.Parse(reader.ReadLine()));
                    }
                    catch(Exception ex)
                    {
                        //TO-DO act to the exception
                    }
                }
                reader.Close();
            }
            else
            {
                throw new Exception("Can not find '" + SHORT_WORD_DATA_FILE_NAME + "'");
            }
        }


        public static void asyncChangeInTextShortWords(ref string text)
        {
            foreach (ShortWord shortWord in shortWords)
            {
                text = text.Replace(shortWord.shortKey, shortWord.fullValue);
            }
        }
    }

    public class ShortWord
    {
        private static readonly char CHR_SHORT_WORD_SPLITTER = ':';
        
        public string shortKey { get; private set; }
        public string fullValue { get; private set; }

        ShortWord(string key, string value)
        {
            shortKey = key;
            fullValue = value;
        }

        public static ShortWord Parse(string strShortWord)
        {
            //delete all '
            strShortWord = strShortWord.Replace("'", "");

            string[] splitStrWords = strShortWord.Split(CHR_SHORT_WORD_SPLITTER);

            if (splitStrWords.Length == 2) //always two parts
            {
                if (splitStrWords[0].Contains(".") && !splitStrWords[1].Contains("."))
                {
                    return new ShortWord(splitStrWords[0], splitStrWords[1]);
                }
            }

            throw new Exception("Can not parse '" + strShortWord + "'");
        }
    }
}
