namespace TextProcessing
{
    partial class FormShowWhatChanges
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_Sentences = new System.Windows.Forms.GroupBox();
            this.label_CurrentIndexWord = new System.Windows.Forms.Label();
            this.button_PreviousWord = new System.Windows.Forms.Button();
            this.button_NextChangeWord = new System.Windows.Forms.Button();
            this.richTextBox_SentencesWithWord = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_SaveAll = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_AcceptNewWord = new System.Windows.Forms.Button();
            this.textBox_NewWord = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_CurrentChangableWord = new System.Windows.Forms.Label();
            this.button_NextSentence = new System.Windows.Forms.Button();
            this.button_PreviousSentence = new System.Windows.Forms.Button();
            this.groupBox_Sentences.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Sentences
            // 
            this.groupBox_Sentences.Controls.Add(this.label_CurrentIndexWord);
            this.groupBox_Sentences.Controls.Add(this.button_PreviousWord);
            this.groupBox_Sentences.Controls.Add(this.button_NextChangeWord);
            this.groupBox_Sentences.Controls.Add(this.richTextBox_SentencesWithWord);
            this.groupBox_Sentences.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_Sentences.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox_Sentences.Location = new System.Drawing.Point(13, 13);
            this.groupBox_Sentences.Name = "groupBox_Sentences";
            this.groupBox_Sentences.Size = new System.Drawing.Size(537, 506);
            this.groupBox_Sentences.TabIndex = 0;
            this.groupBox_Sentences.TabStop = false;
            this.groupBox_Sentences.Text = "Отображение предложений с изменяемым словом";
            // 
            // label_CurrentIndexWord
            // 
            this.label_CurrentIndexWord.AutoSize = true;
            this.label_CurrentIndexWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CurrentIndexWord.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_CurrentIndexWord.Location = new System.Drawing.Point(243, 465);
            this.label_CurrentIndexWord.Name = "label_CurrentIndexWord";
            this.label_CurrentIndexWord.Size = new System.Drawing.Size(51, 29);
            this.label_CurrentIndexWord.TabIndex = 3;
            this.label_CurrentIndexWord.Text = "0/0";
            // 
            // button_PreviousWord
            // 
            this.button_PreviousWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_PreviousWord.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_PreviousWord.Location = new System.Drawing.Point(7, 462);
            this.button_PreviousWord.Name = "button_PreviousWord";
            this.button_PreviousWord.Size = new System.Drawing.Size(202, 38);
            this.button_PreviousWord.TabIndex = 2;
            this.button_PreviousWord.Text = "Предыдущее слово";
            this.button_PreviousWord.UseVisualStyleBackColor = true;
            this.button_PreviousWord.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_NextChangeWord
            // 
            this.button_NextChangeWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_NextChangeWord.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_NextChangeWord.Location = new System.Drawing.Point(336, 462);
            this.button_NextChangeWord.Name = "button_NextChangeWord";
            this.button_NextChangeWord.Size = new System.Drawing.Size(195, 38);
            this.button_NextChangeWord.TabIndex = 1;
            this.button_NextChangeWord.Text = "Следующее слово";
            this.button_NextChangeWord.UseVisualStyleBackColor = true;
            this.button_NextChangeWord.Click += new System.EventHandler(this.button_NextChangeWord_Click);
            // 
            // richTextBox_SentencesWithWord
            // 
            this.richTextBox_SentencesWithWord.Location = new System.Drawing.Point(7, 29);
            this.richTextBox_SentencesWithWord.Name = "richTextBox_SentencesWithWord";
            this.richTextBox_SentencesWithWord.ReadOnly = true;
            this.richTextBox_SentencesWithWord.Size = new System.Drawing.Size(524, 427);
            this.richTextBox_SentencesWithWord.TabIndex = 0;
            this.richTextBox_SentencesWithWord.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_SaveAll);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button_NextSentence);
            this.groupBox1.Controls.Add(this.button_PreviousSentence);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Location = new System.Drawing.Point(556, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 514);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель управления";
            // 
            // button_SaveAll
            // 
            this.button_SaveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_SaveAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_SaveAll.Location = new System.Drawing.Point(7, 425);
            this.button_SaveAll.Name = "button_SaveAll";
            this.button_SaveAll.Size = new System.Drawing.Size(278, 81);
            this.button_SaveAll.TabIndex = 2;
            this.button_SaveAll.Text = "Сохранить все и начать изменение";
            this.button_SaveAll.UseVisualStyleBackColor = true;
            this.button_SaveAll.Click += new System.EventHandler(this.button_SaveAll_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_AcceptNewWord);
            this.groupBox3.Controls.Add(this.textBox_NewWord);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox3.Location = new System.Drawing.Point(7, 328);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 91);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Новое слово";
            // 
            // button_AcceptNewWord
            // 
            this.button_AcceptNewWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_AcceptNewWord.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_AcceptNewWord.Location = new System.Drawing.Point(196, 38);
            this.button_AcceptNewWord.Name = "button_AcceptNewWord";
            this.button_AcceptNewWord.Size = new System.Drawing.Size(75, 30);
            this.button_AcceptNewWord.TabIndex = 1;
            this.button_AcceptNewWord.Text = "ОК";
            this.button_AcceptNewWord.UseVisualStyleBackColor = true;
            this.button_AcceptNewWord.Click += new System.EventHandler(this.button_AcceptNewWord_Click);
            // 
            // textBox_NewWord
            // 
            this.textBox_NewWord.ForeColor = System.Drawing.Color.DarkViolet;
            this.textBox_NewWord.Location = new System.Drawing.Point(6, 38);
            this.textBox_NewWord.Name = "textBox_NewWord";
            this.textBox_NewWord.Size = new System.Drawing.Size(184, 30);
            this.textBox_NewWord.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_CurrentChangableWord);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox2.Location = new System.Drawing.Point(7, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 92);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Изменяемое слово";
            // 
            // label_CurrentChangableWord
            // 
            this.label_CurrentChangableWord.AutoSize = true;
            this.label_CurrentChangableWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CurrentChangableWord.ForeColor = System.Drawing.Color.Blue;
            this.label_CurrentChangableWord.Location = new System.Drawing.Point(6, 39);
            this.label_CurrentChangableWord.Name = "label_CurrentChangableWord";
            this.label_CurrentChangableWord.Size = new System.Drawing.Size(22, 29);
            this.label_CurrentChangableWord.TabIndex = 4;
            this.label_CurrentChangableWord.Text = "-";
            // 
            // button_NextSentence
            // 
            this.button_NextSentence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_NextSentence.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_NextSentence.Location = new System.Drawing.Point(7, 147);
            this.button_NextSentence.Name = "button_NextSentence";
            this.button_NextSentence.Size = new System.Drawing.Size(278, 77);
            this.button_NextSentence.TabIndex = 1;
            this.button_NextSentence.Text = "Добавить следующее предложение";
            this.button_NextSentence.UseVisualStyleBackColor = true;
            this.button_NextSentence.Click += new System.EventHandler(this.button_NextSentence_Click);
            // 
            // button_PreviousSentence
            // 
            this.button_PreviousSentence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_PreviousSentence.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_PreviousSentence.Location = new System.Drawing.Point(6, 29);
            this.button_PreviousSentence.Name = "button_PreviousSentence";
            this.button_PreviousSentence.Size = new System.Drawing.Size(278, 77);
            this.button_PreviousSentence.TabIndex = 0;
            this.button_PreviousSentence.Text = "Добавить предыдущее предложение";
            this.button_PreviousSentence.UseVisualStyleBackColor = true;
            this.button_PreviousSentence.Click += new System.EventHandler(this.button_PreviousSentence_Click);
            // 
            // FormShowWhatChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 531);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_Sentences);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormShowWhatChanges";
            this.Text = "FormShowWhatChanges";
            this.Load += new System.EventHandler(this.FormShowWhatChanges_Load);
            this.groupBox_Sentences.ResumeLayout(false);
            this.groupBox_Sentences.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Sentences;
        private System.Windows.Forms.RichTextBox richTextBox_SentencesWithWord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_PreviousSentence;
        private System.Windows.Forms.Button button_NextSentence;
        private System.Windows.Forms.Button button_NextChangeWord;
        private System.Windows.Forms.Button button_PreviousWord;
        private System.Windows.Forms.Label label_CurrentIndexWord;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_CurrentChangableWord;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_NewWord;
        private System.Windows.Forms.Button button_AcceptNewWord;
        private System.Windows.Forms.Button button_SaveAll;
    }
}