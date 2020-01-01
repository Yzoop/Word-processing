using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace TextProcessing
{
    public enum FileFormat_en
    {
        eDOCX,
        eTXT
    }

    static class PreProcessData
    {
        //--------------------------------------------------------------------------------------------#
        private static readonly Dictionary<char, int> romanDigits =
                                                                        new Dictionary<char, int> {
                                                                            { 'I', 1 },
                                                                            { 'V', 5 },
                                                                            { 'X', 10 },
                                                                            { 'L', 50 },
                                                                            { 'C', 100 },
                                                                            { 'D', 500 },
                                                                            { 'M', 1000 }
                                                                        };

        private static readonly char[] spaceSplitters = { '\t', '\n', ' ', '\r' , '?', '!'};
        private static readonly string[] sentenceSplitters = new string[]{ ".\t", ".\n", ".\r", "?\r", "!\r", "!\n", "?\n", "! ", "? " };
        private const string STR_FORMAT_TXT = "txt", STR_FORMAT_DOCX = "docx", STR_FORMAT_DOC = "doc";

        public static string[] fileWordsSplit { get; private set; }
        public static string fullFileData;
        public static string filePath { get; set; }
        public static FileFormat_en fileFormat { get; private set; }
        public static FileFormat_en savageFileFormat { get; private set; }

        public static DocX docxManager; 
        //--------------------------------------------------------------------------------------------#

        /// <summary>
        /// Sets public variable 'fileFormat' enumerated 
        /// current file format
        /// </summary>
        /// <param name="strFormat">file format after '.' as a string</param>
        public static void setFileFormat(string strFormat)
        {
            switch(strFormat.ToLower())
            {
                case STR_FORMAT_TXT:
                    fileFormat = savageFileFormat = FileFormat_en.eTXT;
                    break;
                case STR_FORMAT_DOC:
                    fileFormat = savageFileFormat = FileFormat_en.eDOCX;
                    break;
                case STR_FORMAT_DOCX:
                    fileFormat = savageFileFormat = FileFormat_en.eDOCX;
                    break;
                default:
                    throw new FileFormatException();
            }
        }


        public static string[] getSentences()
        {
            if (docxManager != null)
            {
                fullFileData = docxManager.Text;
            }
            return fullFileData.Split(sentenceSplitters, StringSplitOptions.RemoveEmptyEntries);
        }


        public static void setSaveAs(FileFormat_en saveAs)
        {
            savageFileFormat = saveAs;
        }


        public static void setNewFullFileData(string data)
        {
            fullFileData = data;
        }
        
        public static void changeTextAccordingToFormat(string oldText, string newText)
        {
            switch(fileFormat)
            {
                case FileFormat_en.eDOCX:
                    docxManager.ReplaceText(oldText, newText);
                    break;
                case FileFormat_en.eTXT:
                    fullFileData = fullFileData.Replace(oldText, newText);
                    break;
            }
        }


        private static bool isRomanian(string strRom)
        {
            foreach(char supposedRomanChar in strRom)
            {
                bool isRomanChar = false;
                foreach(char romanChar in romanDigits.Keys)
                {
                    if (supposedRomanChar.Equals(romanChar))
                    {
                        isRomanChar = true;
                        break;
                    }
                }
                if (!isRomanChar)
                {
                    return false;
                }
            }
            return true;
        }
        
        private static int DecodeRomanToArab(string s)
        {
            int total = 0;
            int prev = 0;
            foreach (char c in s)
            {
                int curr = romanDigits[c];
                total += curr < prev ? -curr : curr;
                prev = curr;
            }
            return total;
        }

        public static void setSpaceSplitText(string soloText)
        {
            fileWordsSplit = (fullFileData = soloText).Split(spaceSplitters, StringSplitOptions.RemoveEmptyEntries);
            
        }


        public static string[] getSpaceSplitWords()
        {
            return (docxManager == null ? fullFileData : docxManager.Text).Split(spaceSplitters, StringSplitOptions.RemoveEmptyEntries);
        }


        public static string[] getSpaceSplitWords(string text)
        {
            return text.Split(spaceSplitters, StringSplitOptions.RemoveEmptyEntries);
        }


        public static int getQuantityOfSentences()
        {
            int pointCounter = 0;
            string textData = docxManager != null ? docxManager.Text : fullFileData;
            foreach (char c in textData)
            {
                if (c.Equals('.') || c.Equals('!') ||c.Equals('?'))
                {
                    ++pointCounter;
                }
            }

            return pointCounter;
        }


        public static async void asyncRomanianNumbersToArab(Button buttonToEnable, RichTextBox richHistory, HistoryMessage message)    
        {
            await Task.Run(()=>
            {
                List<string> romanianStrNumbers = new List<string>();

                string[] splitWords = fileWordsSplit == null ? docxManager.Text.Split(spaceSplitters) : fileWordsSplit;

                foreach (string word in splitWords)
                {
                    if (word.Length > 0)
                    {
                        if (isRomanian(word))
                        {
                            romanianStrNumbers.Add(word);
                        }
                    }
                }
                romanianStrNumbers.Sort();
                romanianStrNumbers.Reverse();
                foreach (string romWord in romanianStrNumbers)
                {
                    changeTextAccordingToFormat(romWord, DecodeRomanToArab(romWord).ToString());
                    //fullFileData = fullFileData.Replace(romWord, DecodeRomanToArab(romWord).ToString());
                }
            });
            buttonToEnable.Enabled = true;
            HistoryWorker.appendLnToHistory(richHistory, message);

        }

        public static async void asyncArabNumbersToRomanian()
        {

        }
    }
}
