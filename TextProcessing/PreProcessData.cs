using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private static readonly char[] splitters = { '\t', '\n', ' ', '\r' };
        private const string STR_FORMAT_TXT = "txt", STR_FORMAT_DOCX = "docx", STR_FORMAT_DOC = "doc";

        public static string[] fileWordsSplit { get; private set; }
        public static string fullFileData;
        public static string filePath { get; set; }
        public static FileFormat_en fileFormat { get; private set; }
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
                    fileFormat = FileFormat_en.eTXT;
                    break;
                case STR_FORMAT_DOC:
                    fileFormat = FileFormat_en.eDOCX;
                    break;
                case STR_FORMAT_DOCX:
                    fileFormat = FileFormat_en.eDOCX;
                    break;
                default:
                    throw new FileFormatException();
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
            fileWordsSplit = (fullFileData = soloText).Split(splitters);
        }

        public static async void asyncRomanianNumbersToArab(Button buttonToEnable, RichTextBox richHistory, HistoryMessage message)    
        {
            await Task.Run(()=>
            {
                List<string> romanianStrNumbers = new List<string>();

                foreach (string word in fileWordsSplit)
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
                foreach(string romWord in romanianStrNumbers)
                {
                    fullFileData = fullFileData.Replace(romWord, DecodeRomanToArab(romWord).ToString());
                }
            }
              );
            buttonToEnable.Enabled = true;
            HistoryWorker.appendLnToHistory(richHistory, message);

        }

        public static async void asyncArabNumbersToRomanian()
        {

        }
    }
}
