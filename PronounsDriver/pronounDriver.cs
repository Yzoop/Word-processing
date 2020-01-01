using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xceed.Words.NET;
using ShortWordDriver;
using System.Linq;

namespace PronounsDriver
{
    public class pronounDriver
    {
        public static readonly string STR_DLL_FULL_NAME = "PronounsDriver.dll";

        public static List<string> L_pronouns = new List<string>();

        public static readonly string PRONOUN_DATA_FILE_NAME = "база_местоимений.sw";

        public static KeyValuePair<string, List<ShortWord>>[] SENTENCES;

        public static DocX docxManager;
        public static string txtData;

        public static string currentPronounChanger = null;

        public static async void asyncReadDataFromFile()
        {
            L_pronouns.Clear();
            await Task.Run(() => readDataFromFile());
        }



        public async static void addPronounToBase(string pronoun)
        {
            await Task.Run(() =>
            {
                StreamReader reader = new StreamReader(PRONOUN_DATA_FILE_NAME);
                List<string> data = new List<string>();

                using (reader)
                {
                    data = reader.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                reader.Close();

                bool found = false;
                foreach(string wordInText in data)
                {
                    if (wordInText.ToLower().Equals(pronoun.ToLower()))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    data.Add(pronoun.ToLower());
                }

                StreamWriter sw = new StreamWriter(PRONOUN_DATA_FILE_NAME);
                using (sw)
                {
                    foreach(string word in data)
                    {
                        sw.WriteLine(word);
                    }
                }

                sw.Close();
            });
        }



        public async static void asyncChangeShortWordsDocx(List<ShortWord> sWords)
        {
            await Task.Run(() =>
            {
                foreach (ShortWord w in sWords)
                {
                    docxManager.ReplaceText(w.shortKey, w.fullValue);
                }
            });


        }

        public async static void asyncChangeShortWordsTxt(List<ShortWord> sWords)
        {
            await Task.Run(() =>
            {
                foreach (ShortWord w in sWords)
                {
                    txtData = txtData.Replace(w.shortKey, w.fullValue);
                }
            });
        }


        public static async void asyncWriteDataToFile()
        {
            await Task.Run(() => writeDataToFile());
        }


        public static bool readyForRead()
        {
            asyncReadDataFromFile();
            return (L_pronouns != null && File.Exists(PRONOUN_DATA_FILE_NAME));
        }



        public async static void asyncFindPronouns(string[] sentences)
        {
            SENTENCES = new KeyValuePair<string, List<ShortWord>>[sentences.Length];
            await Task.Run(() =>
            {
                for(int i = 0; i < sentences.Length; i++)
                {
                    List<ShortWord> shortWords = new List<ShortWord>();
                    foreach (string pronoun in L_pronouns)
                    {
                        sentences[i].ToLower();
                        if (sentences[i].Contains(pronoun))
                        {
                            shortWords.Add(new ShortWord(pronoun, ""));
                        }
                    }

                    SENTENCES[i] = new KeyValuePair<string, List<ShortWord>>(sentences[i], shortWords);
                }
            });
        }


        private static void writeDataToFile()
        {
            StreamWriter writer = new StreamWriter(PRONOUN_DATA_FILE_NAME);
            if (writer != null)
            {
                using (writer)
                {
                    foreach (string word in L_pronouns)
                    {
                        writer.WriteLine(word);
                    }

                }
                writer.Close();
            }
        }


        public async static void asyncDeletePronoun(string pronounToDelete)
        {
            string savePronoun = null;
            await Task.Run(() =>
            {
                foreach (string pronoun in L_pronouns)
                {
                    if (pronounToDelete.Equals(pronoun))
                    {
                        savePronoun = pronoun;
                    }
                }

                L_pronouns.Remove(savePronoun);

                writeDataToFile();
            });
        }


        private static void readDataFromFile()
        {
            StreamReader reader = new StreamReader(PRONOUN_DATA_FILE_NAME);
            if (reader != null)
            {
                using (reader)
                {
                    while (!reader.EndOfStream)
                    {
                        try
                        {
                            L_pronouns.Add(reader.ReadLine());
                        }
                        catch (Exception)
                        {
                            //TO-DO act to the exception
                        }
                    }
                }
                reader.Close();
            }
            else
            {
                throw new Exception("Can not find '" + PRONOUN_DATA_FILE_NAME + "'");
            }
        }


        //public async static void asyncChangeShortWordsDocx()
        //{
        //    await Task.Run(() =>
        //    {
        //        foreach (string shortWord in L_pronouns)
        //        {
        //            docxManager.ReplaceText(shortWord, currentPronounChanger);
        //        }
        //    });
        //}

        //public async static void asyncChangeShortWordsTxt()
        //{
        //    await Task.Run(() =>
        //    {
        //        foreach (ShortWord shortWord in shortWords)
        //        {
        //            txtData = txtData.Replace(shortWord.shortKey, shortWord.fullValue);
        //        }
        //    });
        //}
    }

}