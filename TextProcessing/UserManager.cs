using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static void setFileInfo(string path, Label lFileName, Label lFileSize)
        {
            FileInfo fileInfo = new FileInfo(path);
            
            if (fileInfo != null)
            {
                lFileName.Text = fileInfo.Name;
                lFileSize.Text = getFileStrSize(fileInfo.Length);
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
