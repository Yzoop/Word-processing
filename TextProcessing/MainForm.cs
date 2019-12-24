using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShortWordDriver;

namespace TextProcessing
{
    public partial class MainForm : Form
    {
        private readonly HistoryMessage MSG_STARTED_FILE_LOADING = new HistoryMessage("Начата загрузка файла...", MessageType_en.eStandart),
                                        MSG_STARTED_FILE_CHOOSING = new HistoryMessage("Выбор файла в проводнике...", MessageType_en.eStandart),
                                        MSG_SUCCESS_FILE_LOADED = new HistoryMessage("Файл успешно загружен.", MessageType_en.eSuccess),
                                        MSG_STARTED_FILE_ROMAN_SEARCHING = new HistoryMessage("Начат поиск и замена римских цифр", MessageType_en.eStandart),
                                        MSG_FINISHED_FILE_ROMAN_SEARCH = new HistoryMessage("Поиск и замена римских цифр окончена.", MessageType_en.eSuccess),
                                        MSG_SUCCESS_FILE_WRITING = new HistoryMessage("Изменения успешно сохранены.", MessageType_en.eSuccess),
                                        MSG_ERROR_FILE_READING_FORMAT = new HistoryMessage("Ошибка при чтении файла: неизвестный формат. Возможно, вы выбрали не 'txt' или не 'docx'", MessageType_en.eError),
                                        MSG_ERROR_FILE_REWRITING = new HistoryMessage("Произошла Ошибка при модификации файла", MessageType_en.eError),
                                        MSG_STARTED_SHORT_WORD_READING = new HistoryMessage("Начата загрузка данных о сокращениях...", MessageType_en.eStandart),
                                        MSG_SUCCESS_SHORT_WORD_READING = new HistoryMessage("Данные о сокращениях успешно сохранены!", MessageType_en.eSuccess),
                                        MSG_SUCCESS_SHORT_WORD_REPLACING = new HistoryMessage("Все сохранения в тексте успешно расширены!", MessageType_en.eSuccess),
                                        MSG_ERROR_SHORT_WORD_READING = new HistoryMessage("Произошла ошибка при чтении данных о сокращениях. Возможно файл был изменен. Все строки должны быть в формате 'сокр.слв.' : 'сокращенное слово'", MessageType_en.eError),
                                        MSG_ERROR_SHORT_WORD_DLL = new HistoryMessage("Невозможно найти библиотеку 'shortWordDriver.dll. Пожалуйста, добавьте ее в папку с этим приложением.Для обновления перезагрузите приложение", MessageType_en.eError);
        
        private List<TabPage> tabPages = new List<TabPage>();

        private List<RadioButton> L_RadioBFileFormats = new List<RadioButton>();


        private void setEnabledAllTabs(bool enabled)
        {
            foreach (TabPage tabPage in tabPages)
            {
                foreach (Control ctl in tabPage.Controls)
                {
                    ctl.Enabled = enabled;
                }
            }
        }

        void setDefaults()
        {
            openFileDialog_TxtDoc.Filter = "Doc files (*.doc)|*.doc|Docx files (*.docx)|*docx|Txt files (*.txt)|*.txt";

            tabPages.Add(tabPage_WordFormatting);

            L_RadioBFileFormats.Add(radioButton_Docx);
            L_RadioBFileFormats.Add(radioButton_TXT);

            setEnabledAllTabs(false);
        }


        private void checkDLLs()
        {
            if (File.Exists(shortWordDriver.STR_DLL_FULL_NAME))
            {
                button_DecipherShortWords.Enabled = true;
            }
            else
            {
                button_DecipherShortWords.Enabled = false;
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_ERROR_SHORT_WORD_DLL);
                HistoryWorker.appendLnToHistory(richTextBox_FileHistory, MSG_ERROR_SHORT_WORD_DLL);
            }

        }


        public MainForm()
        {
            InitializeComponent();
            setDefaults();
            checkDLLs();
        }


        private void Button_UploadFile_Click(object sender, EventArgs e)
        {
            startNewFileDialog();
        }


        private void startNewFileDialog()
        {
            newFile_DialogForm newFileDialog = new newFile_DialogForm();
            newFileDialog.ShowDialog();
        }


        public void startNewFileUploading()
        {
            HistoryWorker.appendLnToHistory(richTextBox_FileHistory, MSG_STARTED_FILE_CHOOSING);
            Button_UploadFile.Enabled = false;
            asyncStartFileReading();
        }


        /// <summary>
        ///     starts file dialog
        ///     so as to get file to process
        /// </summary>
        /// <returns> 
        ///     file Path if user chose correct file 
        ///     null if something went wrong
        /// </returns>
        private string getUserFile()
        {
            if (openFileDialog_TxtDoc.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog_TxtDoc.FileName;
            }
            else
            {
                Button_UploadFile.Enabled = true;
                return null;
            }
        }


        private async void asyncStartFileReading()
        {
            string filePath = getUserFile();
            if (filePath != null)
            {
                PreProcessData.filePath = filePath;
                try
                {
                    PreProcessData.setFileFormat(filePath.Split('.')[1]);
                }
                catch (FileFormatException fEx)
                {
                    HistoryWorker.appendLnToHistory(richTextBox_FileHistory, MSG_ERROR_FILE_READING_FORMAT);
                    Button_UploadFile.Enabled = true;
                    return;
                }
                HistoryWorker.appendLnToHistory(richTextBox_FileHistory, MSG_STARTED_FILE_LOADING);

                if (PreProcessData.fileFormat == FileFormat_en.eTXT)
                {
                    startTxtReading(filePath);
                }
                else
                {
                    //TO-DO: startDocReading(...);
                }

                HistoryWorker.appendLnToHistory(richTextBox_FileHistory, MSG_SUCCESS_FILE_LOADED);

                FileInfoWorker.setFileInfo(filePath, Label_FileName, Label_FileSize);
            }

            Button_UploadFile.Enabled = true;
            setEnabledAllTabs(true);
        }


        private void startTxtReading(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                PreProcessData.setSpaceSplitText(reader.ReadToEnd());
            }
            reader.Close();
        }

        private void radioButton_Docx_CheckedChanged(object sender, EventArgs e)
        {
            setSelectedFormatRadioButtons(radioButton_Docx, radioButton_Docx.Checked);
            setButtonSaveChangesEnabled();
        }

        private void radioButton_TXT_CheckedChanged(object sender, EventArgs e)
        {
            setSelectedFormatRadioButtons(radioButton_TXT, radioButton_TXT.Checked);
            setButtonSaveChangesEnabled();
        }

        private void button_DecipherShortWords_Click(object sender, EventArgs e)
        {
            HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_STARTED_SHORT_WORD_READING);
            try
            {
                if (shortWordDriver.readyForRead())
                {
                    shortWordDriver.asyncReadDataFromFile();
                    HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_SUCCESS_SHORT_WORD_READING);

                    shortWordDriver.asyncChangeInTextShortWords(ref PreProcessData.fullFileData);
                    HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_SUCCESS_SHORT_WORD_REPLACING);
                }
                else
                {
                    HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_ERROR_SHORT_WORD_READING);
                    return;
                }
            }
            catch (Exception ex)
            {
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_ERROR_SHORT_WORD_READING);
            }
        }

        private void setButtonSaveChangesEnabled()
        {
            foreach (RadioButton radioButton in L_RadioBFileFormats)
            {
                if (radioButton.Checked)
                {
                    button_SaveChanges.Enabled = true;
                    return;
                }
            }
            button_SaveChanges.Enabled = false;
        }


        private void button_SaveChanges_Click(object sender, EventArgs e)
        {
            switch(PreProcessData.fileFormat)
            {
                case FileFormat_en.eTXT:
                    asyncStartTxtWriting();
                    break;
                case FileFormat_en.eDOCX:
                    //TO-DO: save changes to docx
                    break;
            }
        }


        private void button_ChangeRomaniansToArab_Click(object sender, EventArgs e)
        {
            HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_STARTED_FILE_ROMAN_SEARCHING);
            button_SaveChanges.Enabled = false;
            PreProcessData.asyncRomanianNumbersToArab(button_SaveChanges, richTextBox_FileFormattingHistory, MSG_FINISHED_FILE_ROMAN_SEARCH);
        }


        private async void asyncStartTxtWriting()
        {
            await Task.Run(() =>
            {
                startTxtWriting();
            });
            HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_SUCCESS_FILE_WRITING);
        }


        private void startTxtWriting()
        {
            StreamWriter writer = new StreamWriter(PreProcessData.filePath);
            try
            {
                using (writer)
                {
                    writer.Write(PreProcessData.fullFileData);
                }
            }
            catch(Exception)
            {
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_ERROR_FILE_REWRITING);
            }
        }


        private void setSelectedFormatRadioButtons(RadioButton exceptButton, bool selected)
        {
            foreach(RadioButton radioButton in L_RadioBFileFormats)
            {
                if (radioButton != exceptButton)
                {
                    radioButton.Checked = !selected;
                }
            }
        }



    }

}
