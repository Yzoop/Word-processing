using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace ShortWordDriver
{
    public static class shortWordDriver
    {
        private static readonly Regex shortWordRegex = new Regex(@"[а-я]{1}\.[а-я]{1}\.");
       
        public static readonly string STR_DLL_FULL_NAME = "ShortWordDriver.dll";


        public static KeyValuePair<string, List<ShortWord>>[] sentencesWithShortWords;

        public static DocX docxManager;
        public static string txtData;

        public static bool isReadyForShortWord()
        {
            if (sentencesWithShortWords.Length > 0)
            {
                foreach (KeyValuePair<string, List<ShortWord>> pair in sentencesWithShortWords)
                {
                    if (pair.Value == null)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false ;
        }


        public static void changeShortWordInSentence(int sentenceId, ShortWord newShortWord)
        {
            if (sentenceId > 0 && sentenceId < sentencesWithShortWords.Length)
            {
                ShortWord savedWord = null;
                foreach(ShortWord shortWord in sentencesWithShortWords[sentenceId].Value)
                {
                    if (shortWord.shortKey == newShortWord.shortKey)
                    {
                        savedWord = shortWord;
                        break;
                    }
                }

                if (savedWord != null)
                {
                    sentencesWithShortWords[sentenceId].Value.Remove(savedWord);
                    sentencesWithShortWords[sentenceId].Value.Add(newShortWord);
                }
            }
            else
            {
                throw new ArgumentException();
            }
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

        private static KeyValuePair<string, List<ShortWord>> createPair(string key, List<ShortWord> value)
        {
            return new KeyValuePair<string, List<ShortWord>>(key, value);
        }

        public async static void asyncFindShortWordsInText(string[] sentences)
        {
            sentencesWithShortWords = new KeyValuePair<string, List<ShortWord>>[sentences.Length];

            await Task.Run(() =>
            {
                for (int i = 0; i < sentences.Length; i++)
                {
                    sentencesWithShortWords[i] = createPair(sentences[i], new List<ShortWord>());
                
                }

                foreach(KeyValuePair<string,List <ShortWord >> pair in sentencesWithShortWords)
                {
                    MatchCollection matchCollection = shortWordRegex.Matches(pair.Key);
                    foreach(Match match in matchCollection)
                    {
                        pair.Value.Add(new ShortWord(match.Value, ""));
                    }
                }
            });
        }
    }

    public class ShortWord
    {
        private static readonly char CHR_SHORT_WORD_SPLITTER = ':';
        
        public string shortKey { get; private set; }
        public string fullValue { get; private set; }

        public ShortWord(string key, string value)
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

        public override string ToString()
        {
            return "'" + shortKey + "'" + ":" + "'" + fullValue + "'";
        }
    }
}
