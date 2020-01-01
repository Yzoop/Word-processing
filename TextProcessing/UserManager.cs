using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShortWordDriver;

namespace TextProcessing
{
    public class UserManager
    {
    }


    public class FileInfoWorker
    {
        private static readonly int bytesInKB = 1024, bytesInMB = 1024 * 1024;
        private static readonly string STR_KB = "Килобайт", STR_MB = "Мегабайт", STR_B = "Байт";

        private static string getFileStrSize(long bytes)
        {
            string subName;
            if (bytes >= bytesInMB)
            {
                bytes /= bytesInMB;
                subName = STR_MB;
            }
            else if (bytes >= bytesInKB)
            {
                bytes /= bytesInKB;
                subName = STR_KB;
            }
            else
            {
                subName = STR_B;
            }

            return bytes.ToString() + " " + subName;            
        }


        public static void setDataFilesInfO(string pathPronouns, string pathWords, Label lPronouns, Label lHigh, Label LTiere)
        {
            FileInfo pronounsInfo = new FileInfo(pathPronouns);

            string highLetters = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
            
            startAsyncCountWords(pathPronouns, lPronouns, (string s) => { return true; });
            startAsyncCountWords(pathWords, LTiere, (string s) => { return s.Contains('-'); });
            startAsyncCountWords(pathWords, lHigh, (string s) => { return highLetters.Contains(s[0]); });
        }


        private async static void startAsyncCountWords(string path, Label writeQtWords, Func<string, bool> isCorrect)
        {
            bool errorFaced = false;
            int qtWords = 0;
            await Task.Run(() =>
            {
                StreamReader reader = new StreamReader(path);
                if (reader != null)
                {
                    string[] allWords;
                    using (reader)
                    {
                        qtWords = (reader.ReadToEnd().
                                          Split(new char[] { '\n', '\r' }, 
                                                StringSplitOptions.RemoveEmptyEntries)).
                                          Count(isCorrect);
                    }
                    reader.Close();
                }
                else
                {
                    errorFaced = true;
                }
            });

            if (errorFaced)
            {
                writeQtWords.Text = "Ошибка";
                writeQtWords.ForeColor = Color.Red;
            }
            else
            {
                writeQtWords.Text = qtWords.ToString();
                writeQtWords.ForeColor = Color.Black;
            }
        }


        public static void setFileInfo(string path, Label lFileName, Label lFileSize, Label lQuantityOfSentences, Label lTimeCreation, Label lFolderName, Label lWriteTime)
        {
            FileInfo fileInfo = new FileInfo(path);
            
            if (fileInfo != null)
            {
                lFileName.Text = fileInfo.Name;
                lTimeCreation.Text = fileInfo.CreationTime.ToString();
                lFolderName.Text = fileInfo.DirectoryName;
                lWriteTime.Text = fileInfo.LastWriteTime.ToString();
                lFileSize.Text = getFileStrSize(fileInfo.Length);
                lQuantityOfSentences.Text = PreProcessData.getQuantityOfSentences().ToString();
            }
        }
    }

    public class ListBoxManageer
    {
        public static void addCLRangeToBox(ListBox box, HashSet<string> collection)
        {
            box.Items.Clear();
            foreach(string val in collection)
            {
                box.Items.Add(val);
            }
        }    

        public static void addCLRangeToBox(ListBox box, List<ShortWord> collection)
        {
            box.Items.Clear();
            foreach(ShortWord val in collection)
            {
                box.Items.Add(val.ToString());
            }
        }
    }

    public class LabelWorker
    {
        public void labelSet(Label label, string value)
        {
            label.Text = value;
        }
    }


    public class HistoryWorker
    {
        private static void appendTimeToHistory(RichTextBox history)
        {
            string timeHHDDSS = DateTime.Now.ToString("h:mm:ss tt");

            setColorToHistory(history, Color.LightGray);

            history.AppendText(timeHHDDSS + ": ");
        }

        private static void setColorToHistory(RichTextBox history, Color color)
        {
            history.SelectionStart = history.TextLength;
            history.SelectionLength = 0;

            history.SelectionColor = color;
        }

        public static void appendLnToHistory(RichTextBox history, HistoryMessage historyMessage, bool showTime = true)
        {
            appendTimeToHistory(history);
            setColorToHistory(history, historyMessage.getColor());

            history.AppendText(historyMessage.messageValue + "\n");
        }

        public static void appendToHistory(RichTextBox history, HistoryMessage historyMessage, bool showTime = true)
        {
            appendTimeToHistory(history);
            setColorToHistory(history, historyMessage.getColor());

            if (showTime)
            {
                history.AppendText(historyMessage.messageValue);
            }
        }
    }
}
