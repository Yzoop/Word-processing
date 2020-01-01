using ShortWordDriver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextProcessing
{
    public partial class FormShowWhatChanges : Form
    {
        KeyValuePair<string, List<ShortWord>>[] sentencesWithChangeWords;

        private int currentSentenceId = 0, copyCurrentSentenceShown = 0;
        private int currentShortWordId = 0;
        private bool[] isSentenceAdded;

        public FormShowWhatChanges(KeyValuePair<string, List<ShortWord>>[] sentences)
        {
            InitializeComponent();
            sentencesWithChangeWords = sentences;
            isSentenceAdded = new bool[sentences.Length];

            fillArray();
        }
        

        private void fillArray()
        {
            for (int i = 0; i < isSentenceAdded.Length; i++)
            {
                isSentenceAdded[i] = false;
            }
        }


        private void FormShowWhatChanges_Load(object sender, EventArgs e)
        {
            asyncFindNextSentenceWithShortWord();
            if (currentSentenceId < sentencesWithChangeWords.Length && !anyShortWordInSentence(currentSentenceId))
            {
                showShortWord();
            }
        }

        private void showShortWord()
        {
            if (currentSentenceId < sentencesWithChangeWords.Length)
            {
                if (currentShortWordId < sentencesWithChangeWords[currentSentenceId].Value.Count)
                {
                    richTextBox_SentencesWithWord.Clear();
                    richTextBox_SentencesWithWord.AppendText(sentencesWithChangeWords[currentSentenceId].Key);
                    label_CurrentIndexWord.Text = (currentShortWordId + 1).ToString() + "/" + sentencesWithChangeWords[currentSentenceId].Value.Count.ToString();
                    label_CurrentChangableWord.Text = sentencesWithChangeWords[currentSentenceId].Value.ElementAt(currentShortWordId).shortKey;
                    textBox_NewWord.Text = sentencesWithChangeWords[currentSentenceId].Value.ElementAt(currentShortWordId).fullValue;
                }
            }
            else
            {
                Close();
            }
        }

        private async void asyncFindNextSentenceWithShortWord()
        {
            await Task.Run(() =>
            {
                while(currentSentenceId < sentencesWithChangeWords.Length && !anyShortWordInSentence(currentSentenceId))
                {
                    ++currentSentenceId;
                }
                copyCurrentSentenceShown = currentSentenceId;
            });
        }

        private bool anyShortWordInSentence(int id)
        {
            return sentencesWithChangeWords[id].Value.Count > 0;
        }

        private void button_SaveAll_Click(object sender, EventArgs e)
        {
            Program.mainFormInstance.startShortWordSaving(sentencesWithChangeWords[currentSentenceId].Value);
           //Program.mainFormInstance.startPronounSaver(sentencesWithChangeWords[currentSentenceId].Value);
            this.Close();
        }

        private void button_NextChangeWord_Click(object sender, EventArgs e)
        {
            ++currentShortWordId;
            if (currentSentenceId < sentencesWithChangeWords.Length)
            {
                if (currentShortWordId >= sentencesWithChangeWords[currentSentenceId].Value.Count)
                {
                    currentShortWordId = 0;
                }

                showShortWord();
            }
            else
            {
                Close();
            }
        }

        private void button3_Click(object sender, EventArgs e) //previous word
        {
            --currentShortWordId;
            if (currentShortWordId < 0)
            {
                currentShortWordId = 0;
            }

            showShortWord();
        }

        private void button_NextSentence_Click(object sender, EventArgs e)
        {
            isSentenceAdded[currentSentenceId] = true;
            ++currentSentenceId;
            if (!isSentenceAdded[currentShortWordId] && currentSentenceId < sentencesWithChangeWords.Length)
            {
                isSentenceAdded[currentSentenceId] = true;
                richTextBox_SentencesWithWord.Text = sentencesWithChangeWords[currentSentenceId].Key + richTextBox_SentencesWithWord.Text;
            }
            else
            {
                currentSentenceId = sentencesWithChangeWords.Length - 1;
            }
        }

        private void button_AcceptNewWord_Click(object sender, EventArgs e)
        {
            string key = sentencesWithChangeWords[currentSentenceId].Value.ElementAt(currentShortWordId).shortKey;
            ShortWord foundWord = null;

            foreach(ShortWord word in sentencesWithChangeWords[currentSentenceId].Value)
            {
                if (word.shortKey == label_CurrentChangableWord.Text)
                {
                    foundWord = word;
                }
            }
            if (foundWord != null)
            {
                sentencesWithChangeWords[currentSentenceId].Value.Remove(foundWord);
                sentencesWithChangeWords[currentSentenceId].Value.Add(new ShortWord(key, textBox_NewWord.Text));
            }
        }

        private void button_PreviousSentence_Click(object sender, EventArgs e)
        {
            isSentenceAdded[currentSentenceId] = true;
            --currentSentenceId;
            if (!isSentenceAdded[currentShortWordId] && currentSentenceId > 0)
            {
                isSentenceAdded[currentSentenceId] = true;
                richTextBox_SentencesWithWord.Text = sentencesWithChangeWords[currentSentenceId].Key + richTextBox_SentencesWithWord.Text;
            }
            else
            {
                currentSentenceId = 0;
            }
        }
    }
}
