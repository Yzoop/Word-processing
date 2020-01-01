using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShortWordDriver;
using Xceed.Words.NET;
using PronounsDriver;
using System.Diagnostics;
using Xceed.Document.NET;
using System.Collections.ObjectModel;

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
        private readonly string SIMILAR_WORDS_FILE = "однокоренные_слова.txt",
                                STR_STOP_WORDS_FILE = "стоп_слова.txt",
                                STR_TIERE_UPPER_WORD_FILE_NAME = "words.txt";

        private readonly string STR_FILE_FILTER = "Doc files (*.doc)|*.doc|Docx files (*.docx)|*docx|Txt files (*.txt)|*.txt";

        private List<RadioButton> L_RadioBFileFormats = new List<RadioButton>();

        private string docxImg;
        private string docxTbl;


        List<List<string>> LL_SimilarWordsFromText = new List<List<string>>();
        List<string> L_FoundSameWordsFromText = new List<string>();

        Dictionary<string, string> Dic_help = new Dictionary<string, string>();

        private bool isBold, isItalic, isUnderline, isNormatl, isSavePicturesGraphics;


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
            openFileDialog_TxtDoc.Filter = STR_FILE_FILTER;

            tabPages.Add(tabPage_WordFormatting);
            tabPages.Add(tabPage_AddNewWords);

            L_RadioBFileFormats.Add(radioButton_Docx);
            L_RadioBFileFormats.Add(radioButton_TXT);


            setEnabledAllTabs(false);
        }


        void startAsyncReadingHelp()
        {
            {
                string helpname = "помощь.txt";
                StreamReader reader = new StreamReader(helpname);
                if (reader != null)
                {
                    using (reader)
                    {
                        string nextLine;
                        string bufData = "", currentKey = "";
                        while (!(nextLine = reader.ReadLine()).Contains("--конец--"))
                        {
                            if (nextLine.StartsWith("#"))
                            {
                                currentKey = nextLine.Substring(1);
                                bufData = "";
                                while (!(nextLine = reader.ReadLine()).Contains("?"))
                                {
                                    bufData = bufData + nextLine + "\n";
                                }
                                Dic_help.Add(currentKey, bufData);
                            }
                        }
                    }

                    reader.Close();
                }
            }
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

        }


        private void Button_UploadFile_Click(object sender, EventArgs e)
        {
            startNewFileDialog();
            startAsyncClearingStopWords();
        }


        private async void startAsyncClearingStopWords()
        {
            HistoryWorker.appendLnToHistory(richTextBox_FileHistory, new HistoryMessage("Начата автоматическая обработка стоп-слов.", MessageType_en.eStandart));
            await Task.Run(() =>
            {
                StreamReader reader = new StreamReader(STR_STOP_WORDS_FILE);
                string[] stopWords;
                using (reader)
                {
                    stopWords = reader.ReadToEnd().Split(new char[] { '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries); 
                }

                reader.Close();

                string[] wordsFromText = PreProcessData.getSpaceSplitWords();
                
                foreach(string word in wordsFromText)
                {
                    if (stopWords.Contains(word.ToLower()))
                    {
                        PreProcessData.changeTextAccordingToFormat(word, "");
                    }
                }
            });
            HistoryWorker.appendLnToHistory(richTextBox_FileHistory, new HistoryMessage("Стоп-Слова успешно удалены.", MessageType_en.eSuccess));
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
                catch (FileFormatException)
                {
                    HistoryWorker.appendLnToHistory(richTextBox_FileHistory, MSG_ERROR_FILE_READING_FORMAT);
                    Button_UploadFile.Enabled = true;
                    return;
                }
                HistoryWorker.appendLnToHistory(richTextBox_FileHistory, MSG_STARTED_FILE_LOADING);

                switch (PreProcessData.fileFormat)
                {
                    case FileFormat_en.eTXT:
                        await Task.Run(()=>startTxtReading(filePath));
                        break;
                    case FileFormat_en.eDOCX:
                        await Task.Run(()=>startDocxReading(filePath));
                        break;
                }

                HistoryWorker.appendLnToHistory(richTextBox_FileHistory, MSG_SUCCESS_FILE_LOADED);

                FileInfoWorker.setFileInfo(filePath, Label_FileName, Label_FileSize, label_QuantitySentences, label_creationTime, label_FolderName, label_LatestWriteTime);
            }

            Button_UploadFile.Enabled = true;
            setEnabledAllTabs(true);
        }


        private void startDocxReading(string filePath)
        {
            PreProcessData.docxManager = File.Exists(filePath) ? DocX.Load(filePath) : DocX.Create(filePath);
           
            PreProcessData.setNewFullFileData(String.Empty);
        }


        private void button_ChangeSimilarWords_Click(object sender, EventArgs e)
        {
            button_ChangeSimilarWords.Enabled = false;

            if (pronounDriver.readyForRead())
            {
                try
                {
                    HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, new HistoryMessage("Начат поиск местоимений в тексте...", MessageType_en.eStandart));

                    pronounDriver.asyncFindPronouns(PreProcessData.getSentences());

                    StartShortWordForm(pronounDriver.SENTENCES);

                    HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, new HistoryMessage("Новые значения местоимений успешно приняты!", MessageType_en.eSuccess));
                }
                catch (Exception)
                {
                    HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_ERROR_SHORT_WORD_READING);
                }


            }

            button_ChangeSimilarWords.Enabled = true;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            setDefaults();
            checkDLLs();
        }


        //EVENT
        private void tabPage_AddNewWords_Enter(object sender, EventArgs e)
        {
            //if (shortWordDriver.shortWords != null)
            //{
            //    if (shortWordDriver.shortWords.Count == 0)
            //    {
            //        if (shortWordDriver.readyForRead())
            //        {
            //            shortWordDriver.asyncReadDataFromFile();
            //        }
            //        else
            //        {
            //            return;
            //        }
            //    }

            //    listBox_CurrentShortWordsBase.Items.Clear();
            //    foreach (ShortWord shortWord in shortWordDriver.shortWords)
            //    {
            //        listBox_CurrentShortWordsBase.Items.Add(shortWord.ToString());
            //    }
            //}
        }


        private void button_WacthChanges_Click(object sender, EventArgs e)
        {
            Process.Start(PreProcessData.filePath);
        }

        private void startTxtReading(string filePath)
        {
            PreProcessData.docxManager = null;

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
            PreProcessData.setSaveAs(FileFormat_en.eDOCX);
            groupBox_FormatDocx.Enabled = true;
        }


        private void radioButton_TXT_CheckedChanged(object sender, EventArgs e)
        {
            setSelectedFormatRadioButtons(radioButton_TXT, radioButton_TXT.Checked);
            setButtonSaveChangesEnabled();
            PreProcessData.setSaveAs(FileFormat_en.eTXT);
            groupBox_FormatDocx.Enabled = false;
        }

        private void Button_AddAndSave_Click(object sender, EventArgs e)
        {
            if (textBox_PronounAdd.Text.Length > 0)
                pronounDriver.addPronounToBase(textBox_PronounAdd.Text);

            updateListBox(listBox_CurrenPronounBase, pronounDriver.L_pronouns);
        }

        
        private void updateListBox(ListBox list, List<string> L_string)
        {
            list.Items.Clear();
            pronounDriver.asyncReadDataFromFile();

            foreach(string pronoun in L_string)
            {
                list.Items.Add(pronoun);
            }
        }

        private void button_DeleteShortWord_Click(object sender, EventArgs e)
        {
            if (textBox_PronounDelete.Text.Length > 0)
                pronounDriver.asyncDeletePronoun(textBox_PronounDelete.Text);

            updateListBox(listBox_CurrenPronounBase, pronounDriver.L_pronouns);
        }

        private void button_RemoveHighChrs_Click(object sender, EventArgs e)
        {
            HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, new HistoryMessage("Начат поиск слов с заглавной буквы в предложениях...", MessageType_en.eStandart));

            try
            {
                startAsyncHighChrRemoving();
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, new HistoryMessage("Слова успешно исправлены в предложениях.", MessageType_en.eSuccess));
            }
            catch (Exception)
            {
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, new HistoryMessage("Произошла ошибка при исправлении слов не с большой буквы", MessageType_en.eError));

            }
        }


        private string wordWithFirstBig(string word)
        {
            return word.Substring(0, 1).ToUpper() + word.Remove(0, 1);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //different folderss
        {
            isSavePicturesGraphics = radioButton_differentFolders.Checked;
        }

        private void button_WatchSimilar_Click(object sender, EventArgs e)
        {
            if (textBox_similarWord.Text.Length > 0)
            {
                L_FoundSameWordsFromText.Clear();
                asyncStartReadingSimilarWords(textBox_similarWord.Text);

                updateListBox(listBox_SimilarWords, L_FoundSameWordsFromText);
            }
        }
        

        private async void asyncStartReadingSimilarWords(string wordPart)
        {
            //await Task.Run(() =>
            {
                string[] allWordsFromText = PreProcessData.getSpaceSplitWords();
                

                foreach (string wordFromText in allWordsFromText)
                {
                    if (wordFromText.ToLower().Contains(wordPart.ToLower()))
                    {
                        L_FoundSameWordsFromText.Add(wordFromText);
                    }
                }
            }//);
        }



        //private async void startAsyncSimilarWordDeleting()
        //{
        //    await Task.Run(() =>
        //    {
        //    string similar = textBox_SimilarDelete.Text;
        //    List<string> list_withDeleteWord = null;
        //    foreach (List<string> similarWords in LL_SimilarWordsFromText)
        //    {
        //        if (similarWords.Contains(similar))
        //        {
        //            list_withDeleteWord = similarWords;
        //            break;
        //        }
        //    }
        //    if (list_withDeleteWord != null)
        //    {
        //        LL_SimilarWordsFromText.Remove(list_withDeleteWord);
        //        list_withDeleteWord.Remove(similar);
        //        LL_SimilarWordsFromText.Add(list_withDeleteWord);
        //    }
        //    StreamWriter writer = new StreamWriter(SIMILAR_WORDS_FILE);
        //    if (writer != null)
        //    {
        //        using (writer)
        //        {
        //            foreach (List<string> similarWords in LL_SimilarWordsFromText)
        //            {
        //                foreach (string word in similarWords)
        //                {
        //                    writer.Write(word + ", ");
        //                }
        //                writer.WriteLine();
        //            }

        //        }

        //        writer.Close();
        //    }
        //    });
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
            startAsyncReadingHelp();
            listBox_HelpParts.Items.Clear();
            foreach(string key in Dic_help.Keys)
            {
                listBox_HelpParts.Items.Add(key);
            }

            FileInfoWorker.setDataFilesInfO(pronounDriver.PRONOUN_DATA_FILE_NAME, STR_TIERE_UPPER_WORD_FILE_NAME, label_PronounBasse, label_UpperCaseWords, label_TiereWords);

        }

        private void listBox_HelpParts_SelectedValueChanged(object sender, EventArgs e)
        {
            richTextBox_HelpPage.Clear();
            string newData;
            Dic_help.TryGetValue(listBox_HelpParts.SelectedItem.ToString(), out newData);
            richTextBox_HelpPage.Text = newData;
        }


        private bool isWordStartsWithHigh(string word)
        {
            return word.Equals(wordWithFirstBig(word));
        }


        private bool containsSomeWordFrom(List<List<string>> wordBase, List<string> supposedSubBase)
        {
            foreach(List<string> subBase in wordBase)
            {
                foreach(string subWord in subBase)
                {
                    foreach(string supposedSubWord in supposedSubBase)
                    {
                        if (supposedSubWord.ToLower().Equals(subWord.ToLower()))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }


        private void button_SaveSimilarWords_Click(object sender, EventArgs e)
        {
            button_SaveSimilarWords.Enabled = false;
            List<List<string>> similarWords = new List<List<string>>();
            //Прочитать все однокоренные в файле
            {
                StreamReader reader = new StreamReader(SIMILAR_WORDS_FILE);
                if (reader != null)
                {
                    string[] allSimilarWordsFromFile;
                    using (reader)
                    {
                        allSimilarWordsFromFile = reader.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    reader.Close();

                    foreach (string notParsedWords in allSimilarWordsFromFile)
                    {
                        string[] parsedWords = notParsedWords.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        similarWords.Add(parsedWords.ToList());
                    }
                }
            }
            //Если отствтует данный формат однокоренных, добавить его в файл
            if (!containsSomeWordFrom(similarWords, L_FoundSameWordsFromText))
            {
                similarWords.Add(L_FoundSameWordsFromText);
                StreamWriter writer = new StreamWriter(SIMILAR_WORDS_FILE);
                using(writer)
                {
                    foreach(List<string> swords in similarWords)
                    {
                        foreach(string word in swords)
                        {
                            writer.Write("{0}, ", word);
                        }
                        writer.WriteLine();
                    }
                }

                writer.Close();
            }
            button_SaveSimilarWords.Enabled = true;
        }

        private async void startAsyncHighChrRemoving()
        {
            await Task.Run(() =>
            {
                string fileHighWords = STR_TIERE_UPPER_WORD_FILE_NAME;
                List<string> wordWhichNeedsHighs = new List<string>();
                StreamReader reader = new StreamReader(fileHighWords);
                if (reader != null)
                {
                    string allData;
                    using (reader)
                    {
                        allData = reader.ReadToEnd();
                    }
                    reader.Close();
                    string[] splitAllData = allData.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string split in splitAllData)
                    {
                        if (isWordStartsWithHigh(split))
                        {
                            wordWhichNeedsHighs.Add(split);
                        }
                    }

                    PreProcessData.setSpaceSplitText(PreProcessData.docxManager != null ? PreProcessData.docxManager.Text : PreProcessData.fullFileData);
                    string[] sentences = PreProcessData.getSentences();
                    foreach(string sentence in sentences)
                    {
                        PreProcessData.setSpaceSplitText(sentence);
                        string[] words = PreProcessData.fileWordsSplit;

                        if (words.Length > 1)
                        {
                            words[0] = wordWithFirstBig(words[0]);
                            for(int i = 1; i < words.Length; i++) //first word always ok
                            {
                                if (!wordWhichNeedsHighs.Contains(wordWithFirstBig(words[i])))
                                {
                                    if (PreProcessData.fileFormat == FileFormat_en.eTXT)
                                    {
                                        PreProcessData.fullFileData = PreProcessData.fullFileData.Replace(words[i], words[i].ToLower());
                                    }
                                    else
                                    {
                                        PreProcessData.docxManager.ReplaceText(words[i], words[i].ToLower());
                                    }
                                }
                                else
                                {
                                    if (PreProcessData.fileFormat == FileFormat_en.eTXT)
                                    {
                                        PreProcessData.fullFileData = PreProcessData.fullFileData.Replace(words[i], wordWithFirstBig(words[i]));
                                    }
                                    else
                                    {
                                        PreProcessData.docxManager.ReplaceText(words[i], wordWithFirstBig(words[i]));
                                    }
                                }
                            }
                        }
                    }
                } 
            }); 
        }

        private void button_deleteAllTiere_Click(object sender, EventArgs e)
        {
            try
            {
                startDeletingAllTiere();
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, new HistoryMessage("Все переносы успешно удалены.", MessageType_en.eSuccess));
            }
            catch (Exception)
            {
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, new HistoryMessage("Произошла ошибка при удалении переноса", MessageType_en.eError));
            }
        }


        private List<string> getWordsWithTiereFromFile()
        {
            List<string> wordsWithTiereFromFile = new List<string>();
            string[] splitAllWords;
            using (StreamReader reader = new StreamReader("words.txt"))
            {
                splitAllWords = reader.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (string splitword in splitAllWords)
            {
                if (splitword.Contains('-'))
                {
                    wordsWithTiereFromFile.Add(splitword);
                }
            }

            return wordsWithTiereFromFile;
        }


        private async void startDeletingAllTiere()
        {
            await Task.Run(() =>
            {
                string[] splitWords = PreProcessData.docxManager != null ?
                                        PreProcessData.getSpaceSplitWords(PreProcessData.docxManager.Text) :
                                        PreProcessData.getSpaceSplitWords(PreProcessData.fullFileData);
                List<string> wordsToDelete = new List<string>();
                List<string> correctWordsWithTiere = getWordsWithTiereFromFile();
                foreach(string splitword in splitWords)
                {
                    if (splitword.Contains('-') && !correctWordsWithTiere.Contains(splitword))
                    {
                        wordsToDelete.Add(splitword);
                    }
                }
                if (PreProcessData.fileFormat == FileFormat_en.eTXT)
                {
                    foreach (string wordtodelete in wordsToDelete)
                    {
                        string correctWord = wordtodelete.Replace("-", "");
                        PreProcessData.fullFileData = PreProcessData.fullFileData.Replace(wordtodelete, correctWord);
                    }
                }
                else
                {
                    foreach (string wordtodelete in wordsToDelete)
                    {
                        string correctWord = wordtodelete.Replace("-", "");
                        PreProcessData.docxManager.ReplaceText(wordtodelete, correctWord);
                    }
                }
            });
        }

        private void button_DecipherShortWords_Click(object sender, EventArgs e)
        {
            button_DecipherShortWords.Enabled = false;

            HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_STARTED_SHORT_WORD_READING);
            try
            {
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_SUCCESS_SHORT_WORD_READING);

                shortWordDriver.asyncFindShortWordsInText(PreProcessData.getSentences());

                if (shortWordDriver.isReadyForShortWord())
                {
                    StartShortWordForm(shortWordDriver.sentencesWithShortWords);
                }
                else
                {
                    HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, new HistoryMessage("Короткие слова не найдены", MessageType_en.eStandart));
                }
            }
            catch (Exception)
            {
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_ERROR_SHORT_WORD_READING);
            }

            button_DecipherShortWords.Enabled = true;
        }


        public void startShortWordSaving(List<ShortWord> shortWords)
        {
            try
            {
                switch (PreProcessData.fileFormat)
                {
                    case FileFormat_en.eDOCX:
                        shortWordDriver.docxManager = PreProcessData.docxManager;
                        shortWordDriver.asyncChangeShortWordsDocx(shortWords);
                        PreProcessData.docxManager  = shortWordDriver.docxManager;
                        asyncStartDocxWriting(PreProcessData.filePath);
                        HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_SUCCESS_SHORT_WORD_REPLACING);
                        break;
                    case FileFormat_en.eTXT:
                        shortWordDriver.txtData = PreProcessData.fullFileData;
                        shortWordDriver.asyncChangeShortWordsTxt(shortWords);
                        PreProcessData.fullFileData = shortWordDriver.txtData;
                        //asyncStartDocxWriting(PreProcessData.filePath);
                        HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_SUCCESS_SHORT_WORD_REPLACING);
                        break;
                }
            }
            catch (Exception)
            {
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_ERROR_SHORT_WORD_READING);
            }

        }


        public void startPronounSaver(List<ShortWord> shortWords)
        {
            try
            {
                switch (PreProcessData.fileFormat)
                {
                    case FileFormat_en.eDOCX:
                        pronounDriver.docxManager = PreProcessData.docxManager;
                        pronounDriver.asyncChangeShortWordsDocx(shortWords);
                        PreProcessData.docxManager = shortWordDriver.docxManager;
                        HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_SUCCESS_SHORT_WORD_REPLACING);
                        break;
                    case FileFormat_en.eTXT:
                        pronounDriver.txtData = PreProcessData.fullFileData;
                        pronounDriver.asyncChangeShortWordsTxt(shortWords);
                        PreProcessData.fullFileData = shortWordDriver.txtData;
                        HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_SUCCESS_SHORT_WORD_REPLACING);
                        break;
                }
            }
            catch (Exception)
            {
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_ERROR_SHORT_WORD_READING);
            }

        }


        private async void StartShortWordForm(KeyValuePair<string, List<ShortWord>>[] sentences)
        {
            FormShowWhatChanges showWhatChanges = new FormShowWhatChanges(sentences);
            showWhatChanges.StartPosition = FormStartPosition.CenterScreen;
            showWhatChanges.ShowDialog();
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
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            saveFileDialog_SaveAS.Filter = STR_FILE_FILTER;
            saveFileDialog_SaveAS.Title = "Сохранить документ";
            saveFileDialog_SaveAS.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog_SaveAS.FileName != "")
            {
                PreProcessData.filePath = saveFileDialog_SaveAS.FileName;
                // Saves the Image via a FileStream created by the OpenFile method.
                string newFilePath = saveFileDialog_SaveAS.FileName;
                switch (PreProcessData.savageFileFormat)
                {
                    case FileFormat_en.eTXT:
                        try
                        {
                            asyncStartTxtWriting(newFilePath.Split('.')[0] + ".txt");
                            HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_SUCCESS_FILE_WRITING);
                        }
                        catch (Exception ex)
                        {
                            HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, new HistoryMessage(ex.ToString(), MessageType_en.eError));
                        }
                        break;
                    case FileFormat_en.eDOCX:
                        asyncStartDocxWriting(newFilePath.Split('.')[0] + ".docx");
                        HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_SUCCESS_FILE_WRITING);
                        break;
                }
            }
        }


        private void button_ChangeRomaniansToArab_Click(object sender, EventArgs e)
        {
            HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, MSG_STARTED_FILE_ROMAN_SEARCHING);
            button_SaveChanges.Enabled = false;
            PreProcessData.asyncRomanianNumbersToArab(button_SaveChanges, richTextBox_FileFormattingHistory, MSG_FINISHED_FILE_ROMAN_SEARCH);
        
            
        }


        private async void asyncStartTxtWriting(string savePath)
        {
            await Task.Run(() =>
            {
                startTxtWriting(savePath);
            });
        }


        private void startTxtWriting(string savePath)
        {
            if (PreProcessData.docxManager != null)
            {
                PreProcessData.fullFileData = PreProcessData.docxManager.Text;
            }
            StreamWriter writer = new StreamWriter(savePath);
            using (writer)
            {
                writer.Write(PreProcessData.fullFileData);
            }
            writer.Close();
        }




        private async void asyncStartDocxWriting(string filePath)
        {
            await Task.Run(() =>
            {
                startDocxWriting(filePath);
            });

            if (isSavePicturesGraphics)
            {
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, new HistoryMessage(String.Format("Изображения из документа '{0}' сохранены в '{1}'", PreProcessData.filePath, docxImg), MessageType_en.eSuccess));
                HistoryWorker.appendLnToHistory(richTextBox_FileFormattingHistory, new HistoryMessage(String.Format("Таблицы из документа '{0}' сохранены в '{1}'", PreProcessData.filePath, docxTbl), MessageType_en.eSuccess));
            }
        }

        
        private void saveInDifferentFolders()
        {
            FileInfo info = new FileInfo(PreProcessData.filePath);
            string fullFilePath = info.DirectoryName;
            string fileName = info.Name.Split('.')[0];

            string folderTable = fullFilePath + @"\" + fileName;
            string folderGraphic = fullFilePath + @"\" +  fileName;

            docxImg = fullFilePath + @"\Изображения из " + info.Name;
            docxTbl = fullFilePath + @"\Таблицы из " + info.Name;
            string docxGrp = folderGraphic + @"\Графики из " + info.Name;

            if (PreProcessData.docxManager.Images.Count > 0)
            {   
                // создаём документ
                DocX document = DocX.Load(PreProcessData.filePath);


                foreach (Paragraph managerParagraph in document.Paragraphs)
                {
                    Paragraph copy = managerParagraph;
                    if (copy.Text.Length > 0)
                    {
                        copy.RemoveText(0);
                        //может оказаться неправдой
                        if (copy.Pictures.Count > 0)
                        {
                            document.InsertParagraph(managerParagraph);
                        }
                    }
                }

                // сохраняем документ
                document.SaveAs(docxImg);
            }

            //Сохранить слова из таблиц для последующего удаления
            List<string> wordsFromTable = new List<string>();

            foreach (Table table in PreProcessData.docxManager.Tables)
            {
                DocX document = DocX.Create(docxTbl);

                // сохраняем документ
                document.SaveAs(docxTbl);

                // располагаем таблицу по центру
                table.Alignment = Alignment.center;
                // меняем стандартный дизайн таблицы
                table.Design = TableDesign.TableGrid;

                foreach(Row row in table.Rows)
                {
                    foreach(Cell cell in row.Cells)
                    {
                        foreach (Paragraph paragraph in cell.Paragraphs)
                        {
                            if (paragraph.Text.Length > 0)
                            {
                                wordsFromTable.Add(paragraph.Text);
                            }
                        }
                    }
                }

                // создаём параграф и вставляем таблицу
                document.InsertParagraph().InsertTableAfterSelf(table);

                // сохраняем документ
                document.SaveAs(docxTbl);
            }

            ReadOnlyCollection<Paragraph> paragraphsToRemove = PreProcessData.docxManager.Paragraphs;


            foreach (string word in wordsFromTable)
            {
                PreProcessData.docxManager.ReplaceText(word, ""); //Заменить слово из таблицы на пустой символ
            }

            //Оставить в исходном документе только текст
            string savedText = PreProcessData.docxManager.Text;

            PreProcessData.docxManager = DocX.Create(PreProcessData.filePath);


            string[] splitSentences = savedText.Split(new char[] { '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string sentence in splitSentences)
            {
                PreProcessData.docxManager.InsertParagraph(sentence).Font("Calibri").FontSize(12).Color(System.Drawing.Color.Black);
            }

            PreProcessData.docxManager.Save();
        }


        private void startDocxWriting(string filePath)
        {
            if (PreProcessData.docxManager == null)
            {
                PreProcessData.docxManager = DocX.Create(filePath);
                PreProcessData.docxManager.InsertParagraph(PreProcessData.fullFileData);
            }

            PreProcessData.docxManager.SetDefaultFont(new Xceed.Document.NET.Font("Calibri"));
            PreProcessData.docxManager.SaveAs(filePath);

            if (isSavePicturesGraphics)
            {
                saveInDifferentFolders();
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
