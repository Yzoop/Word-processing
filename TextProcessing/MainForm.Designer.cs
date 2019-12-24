namespace TextProcessing
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TAB_MainTab = new System.Windows.Forms.TabControl();
            this.tabPage_FileJob = new System.Windows.Forms.TabPage();
            this.Button_UploadFile = new System.Windows.Forms.Button();
            this.groupBox_CurrentFileInfo = new System.Windows.Forms.GroupBox();
            this.groupBox_QuantitySentences = new System.Windows.Forms.GroupBox();
            this.label_QuantitySentences = new System.Windows.Forms.Label();
            this.groupBox_FileSize = new System.Windows.Forms.GroupBox();
            this.Label_FileSize = new System.Windows.Forms.Label();
            this.groupBox_FileName = new System.Windows.Forms.GroupBox();
            this.Label_FileName = new System.Windows.Forms.Label();
            this.groupBox_FileHistory = new System.Windows.Forms.GroupBox();
            this.richTextBox_FileHistory = new System.Windows.Forms.RichTextBox();
            this.tabPage_WordFormatting = new System.Windows.Forms.TabPage();
            this.groupBox_Saving = new System.Windows.Forms.GroupBox();
            this.groupBox_SaveFormat = new System.Windows.Forms.GroupBox();
            this.radioButton_TXT = new System.Windows.Forms.RadioButton();
            this.radioButton_Docx = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.button_SaveChanges = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_ExampleSimilarWords = new System.Windows.Forms.Label();
            this.button_ChangeSimilarWords = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_DecipherShortWords = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Label_NumberExample = new System.Windows.Forms.Label();
            this.button_ChangeRomaniansToArab = new System.Windows.Forms.Button();
            this.groupBox_FileChangingHistory = new System.Windows.Forms.GroupBox();
            this.richTextBox_FileFormattingHistory = new System.Windows.Forms.RichTextBox();
            this.openFileDialog_TxtDoc = new System.Windows.Forms.OpenFileDialog();
            this.TAB_MainTab.SuspendLayout();
            this.tabPage_FileJob.SuspendLayout();
            this.groupBox_CurrentFileInfo.SuspendLayout();
            this.groupBox_QuantitySentences.SuspendLayout();
            this.groupBox_FileSize.SuspendLayout();
            this.groupBox_FileName.SuspendLayout();
            this.groupBox_FileHistory.SuspendLayout();
            this.tabPage_WordFormatting.SuspendLayout();
            this.groupBox_Saving.SuspendLayout();
            this.groupBox_SaveFormat.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_FileChangingHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // TAB_MainTab
            // 
            this.TAB_MainTab.Controls.Add(this.tabPage_FileJob);
            this.TAB_MainTab.Controls.Add(this.tabPage_WordFormatting);
            this.TAB_MainTab.Location = new System.Drawing.Point(12, 12);
            this.TAB_MainTab.Name = "TAB_MainTab";
            this.TAB_MainTab.SelectedIndex = 0;
            this.TAB_MainTab.Size = new System.Drawing.Size(874, 609);
            this.TAB_MainTab.TabIndex = 0;
            // 
            // tabPage_FileJob
            // 
            this.tabPage_FileJob.Controls.Add(this.Button_UploadFile);
            this.tabPage_FileJob.Controls.Add(this.groupBox_CurrentFileInfo);
            this.tabPage_FileJob.Controls.Add(this.groupBox_FileHistory);
            this.tabPage_FileJob.Location = new System.Drawing.Point(4, 34);
            this.tabPage_FileJob.Name = "tabPage_FileJob";
            this.tabPage_FileJob.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_FileJob.Size = new System.Drawing.Size(866, 571);
            this.tabPage_FileJob.TabIndex = 0;
            this.tabPage_FileJob.Text = "Загрузка файла";
            this.tabPage_FileJob.UseVisualStyleBackColor = true;
            // 
            // Button_UploadFile
            // 
            this.Button_UploadFile.BackColor = System.Drawing.Color.Gainsboro;
            this.Button_UploadFile.Location = new System.Drawing.Point(320, 6);
            this.Button_UploadFile.Name = "Button_UploadFile";
            this.Button_UploadFile.Size = new System.Drawing.Size(203, 46);
            this.Button_UploadFile.TabIndex = 2;
            this.Button_UploadFile.Text = "Загрузить файл";
            this.Button_UploadFile.UseVisualStyleBackColor = false;
            this.Button_UploadFile.Click += new System.EventHandler(this.Button_UploadFile_Click);
            // 
            // groupBox_CurrentFileInfo
            // 
            this.groupBox_CurrentFileInfo.Controls.Add(this.groupBox_QuantitySentences);
            this.groupBox_CurrentFileInfo.Controls.Add(this.groupBox_FileSize);
            this.groupBox_CurrentFileInfo.Controls.Add(this.groupBox_FileName);
            this.groupBox_CurrentFileInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.groupBox_CurrentFileInfo.Location = new System.Drawing.Point(7, 58);
            this.groupBox_CurrentFileInfo.Name = "groupBox_CurrentFileInfo";
            this.groupBox_CurrentFileInfo.Size = new System.Drawing.Size(853, 266);
            this.groupBox_CurrentFileInfo.TabIndex = 1;
            this.groupBox_CurrentFileInfo.TabStop = false;
            this.groupBox_CurrentFileInfo.Text = "Информация о текущем файле";
            // 
            // groupBox_QuantitySentences
            // 
            this.groupBox_QuantitySentences.Controls.Add(this.label_QuantitySentences);
            this.groupBox_QuantitySentences.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.groupBox_QuantitySentences.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox_QuantitySentences.Location = new System.Drawing.Point(319, 33);
            this.groupBox_QuantitySentences.Name = "groupBox_QuantitySentences";
            this.groupBox_QuantitySentences.Size = new System.Drawing.Size(307, 59);
            this.groupBox_QuantitySentences.TabIndex = 1;
            this.groupBox_QuantitySentences.TabStop = false;
            this.groupBox_QuantitySentences.Text = "Количество предложений";
            // 
            // label_QuantitySentences
            // 
            this.label_QuantitySentences.AutoSize = true;
            this.label_QuantitySentences.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_QuantitySentences.Location = new System.Drawing.Point(6, 34);
            this.label_QuantitySentences.Name = "label_QuantitySentences";
            this.label_QuantitySentences.Size = new System.Drawing.Size(122, 25);
            this.label_QuantitySentences.TabIndex = 0;
            this.label_QuantitySentences.Text = "Отсутсвует";
            // 
            // groupBox_FileSize
            // 
            this.groupBox_FileSize.Controls.Add(this.Label_FileSize);
            this.groupBox_FileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.groupBox_FileSize.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox_FileSize.Location = new System.Drawing.Point(6, 98);
            this.groupBox_FileSize.Name = "groupBox_FileSize";
            this.groupBox_FileSize.Size = new System.Drawing.Size(307, 59);
            this.groupBox_FileSize.TabIndex = 1;
            this.groupBox_FileSize.TabStop = false;
            this.groupBox_FileSize.Text = "Размер файла";
            // 
            // Label_FileSize
            // 
            this.Label_FileSize.AutoSize = true;
            this.Label_FileSize.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label_FileSize.Location = new System.Drawing.Point(6, 34);
            this.Label_FileSize.Name = "Label_FileSize";
            this.Label_FileSize.Size = new System.Drawing.Size(122, 25);
            this.Label_FileSize.TabIndex = 0;
            this.Label_FileSize.Text = "Отсутсвует";
            // 
            // groupBox_FileName
            // 
            this.groupBox_FileName.Controls.Add(this.Label_FileName);
            this.groupBox_FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic);
            this.groupBox_FileName.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox_FileName.Location = new System.Drawing.Point(6, 33);
            this.groupBox_FileName.Name = "groupBox_FileName";
            this.groupBox_FileName.Size = new System.Drawing.Size(307, 59);
            this.groupBox_FileName.TabIndex = 0;
            this.groupBox_FileName.TabStop = false;
            this.groupBox_FileName.Text = "Название файла";
            // 
            // Label_FileName
            // 
            this.Label_FileName.AutoSize = true;
            this.Label_FileName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label_FileName.Location = new System.Drawing.Point(6, 34);
            this.Label_FileName.Name = "Label_FileName";
            this.Label_FileName.Size = new System.Drawing.Size(122, 25);
            this.Label_FileName.TabIndex = 0;
            this.Label_FileName.Text = "Отсутсвует";
            // 
            // groupBox_FileHistory
            // 
            this.groupBox_FileHistory.Controls.Add(this.richTextBox_FileHistory);
            this.groupBox_FileHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.groupBox_FileHistory.Location = new System.Drawing.Point(7, 330);
            this.groupBox_FileHistory.Name = "groupBox_FileHistory";
            this.groupBox_FileHistory.Size = new System.Drawing.Size(853, 235);
            this.groupBox_FileHistory.TabIndex = 0;
            this.groupBox_FileHistory.TabStop = false;
            this.groupBox_FileHistory.Text = "История загрузки файлов";
            // 
            // richTextBox_FileHistory
            // 
            this.richTextBox_FileHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.richTextBox_FileHistory.Location = new System.Drawing.Point(3, 26);
            this.richTextBox_FileHistory.Name = "richTextBox_FileHistory";
            this.richTextBox_FileHistory.ReadOnly = true;
            this.richTextBox_FileHistory.Size = new System.Drawing.Size(844, 203);
            this.richTextBox_FileHistory.TabIndex = 0;
            this.richTextBox_FileHistory.Text = "";
            // 
            // tabPage_WordFormatting
            // 
            this.tabPage_WordFormatting.Controls.Add(this.groupBox_Saving);
            this.tabPage_WordFormatting.Controls.Add(this.groupBox3);
            this.tabPage_WordFormatting.Controls.Add(this.groupBox2);
            this.tabPage_WordFormatting.Controls.Add(this.groupBox1);
            this.tabPage_WordFormatting.Controls.Add(this.groupBox_FileChangingHistory);
            this.tabPage_WordFormatting.Location = new System.Drawing.Point(4, 34);
            this.tabPage_WordFormatting.Name = "tabPage_WordFormatting";
            this.tabPage_WordFormatting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_WordFormatting.Size = new System.Drawing.Size(866, 571);
            this.tabPage_WordFormatting.TabIndex = 1;
            this.tabPage_WordFormatting.Text = "Форматирование слов";
            this.tabPage_WordFormatting.UseVisualStyleBackColor = true;
            // 
            // groupBox_Saving
            // 
            this.groupBox_Saving.Controls.Add(this.groupBox_SaveFormat);
            this.groupBox_Saving.Controls.Add(this.button_SaveChanges);
            this.groupBox_Saving.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox_Saving.Location = new System.Drawing.Point(9, 186);
            this.groupBox_Saving.Name = "groupBox_Saving";
            this.groupBox_Saving.Size = new System.Drawing.Size(844, 138);
            this.groupBox_Saving.TabIndex = 3;
            this.groupBox_Saving.TabStop = false;
            this.groupBox_Saving.Text = "Сохранение всех изменений в текущем файле";
            // 
            // groupBox_SaveFormat
            // 
            this.groupBox_SaveFormat.Controls.Add(this.radioButton_TXT);
            this.groupBox_SaveFormat.Controls.Add(this.radioButton_Docx);
            this.groupBox_SaveFormat.Controls.Add(this.label3);
            this.groupBox_SaveFormat.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox_SaveFormat.Location = new System.Drawing.Point(6, 26);
            this.groupBox_SaveFormat.Name = "groupBox_SaveFormat";
            this.groupBox_SaveFormat.Size = new System.Drawing.Size(238, 106);
            this.groupBox_SaveFormat.TabIndex = 3;
            this.groupBox_SaveFormat.TabStop = false;
            this.groupBox_SaveFormat.Text = "Параметры сохранения";
            // 
            // radioButton_TXT
            // 
            this.radioButton_TXT.AutoSize = true;
            this.radioButton_TXT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButton_TXT.Location = new System.Drawing.Point(130, 57);
            this.radioButton_TXT.Name = "radioButton_TXT";
            this.radioButton_TXT.Size = new System.Drawing.Size(73, 29);
            this.radioButton_TXT.TabIndex = 3;
            this.radioButton_TXT.TabStop = true;
            this.radioButton_TXT.Text = "TXT";
            this.radioButton_TXT.UseVisualStyleBackColor = true;
            this.radioButton_TXT.CheckedChanged += new System.EventHandler(this.radioButton_TXT_CheckedChanged);
            // 
            // radioButton_Docx
            // 
            this.radioButton_Docx.AutoSize = true;
            this.radioButton_Docx.ForeColor = System.Drawing.Color.RoyalBlue;
            this.radioButton_Docx.Location = new System.Drawing.Point(12, 57);
            this.radioButton_Docx.Name = "radioButton_Docx";
            this.radioButton_Docx.Size = new System.Drawing.Size(92, 29);
            this.radioButton_Docx.TabIndex = 2;
            this.radioButton_Docx.TabStop = true;
            this.radioButton_Docx.Text = "DOCX";
            this.radioButton_Docx.UseVisualStyleBackColor = true;
            this.radioButton_Docx.CheckedChanged += new System.EventHandler(this.radioButton_Docx_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(13, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "IV становится 4 и т.д.";
            // 
            // button_SaveChanges
            // 
            this.button_SaveChanges.Enabled = false;
            this.button_SaveChanges.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_SaveChanges.Location = new System.Drawing.Point(251, 39);
            this.button_SaveChanges.Name = "button_SaveChanges";
            this.button_SaveChanges.Size = new System.Drawing.Size(587, 93);
            this.button_SaveChanges.TabIndex = 2;
            this.button_SaveChanges.Text = "Сохранить изменения";
            this.button_SaveChanges.UseVisualStyleBackColor = true;
            this.button_SaveChanges.Click += new System.EventHandler(this.button_SaveChanges_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_ExampleSimilarWords);
            this.groupBox3.Controls.Add(this.button_ChangeSimilarWords);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox3.Location = new System.Drawing.Point(571, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 180);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Однокоренные и родственные слова";
            // 
            // label_ExampleSimilarWords
            // 
            this.label_ExampleSimilarWords.AutoSize = true;
            this.label_ExampleSimilarWords.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_ExampleSimilarWords.Location = new System.Drawing.Point(18, 127);
            this.label_ExampleSimilarWords.Name = "label_ExampleSimilarWords";
            this.label_ExampleSimilarWords.Size = new System.Drawing.Size(185, 50);
            this.label_ExampleSimilarWords.TabIndex = 1;
            this.label_ExampleSimilarWords.Text = "\"машина\" схоже c \r\n\"машинист\"";
            // 
            // button_ChangeSimilarWords
            // 
            this.button_ChangeSimilarWords.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_ChangeSimilarWords.Location = new System.Drawing.Point(23, 59);
            this.button_ChangeSimilarWords.Name = "button_ChangeSimilarWords";
            this.button_ChangeSimilarWords.Size = new System.Drawing.Size(252, 61);
            this.button_ChangeSimilarWords.TabIndex = 0;
            this.button_ChangeSimilarWords.Text = "Замена однокоренных и родственных слов";
            this.button_ChangeSimilarWords.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button_DecipherShortWords);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox2.Location = new System.Drawing.Point(280, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 177);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сокращения слов в предложениях";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(18, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "т.д. становится так далее";
            // 
            // button_DecipherShortWords
            // 
            this.button_DecipherShortWords.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_DecipherShortWords.Location = new System.Drawing.Point(18, 59);
            this.button_DecipherShortWords.Name = "button_DecipherShortWords";
            this.button_DecipherShortWords.Size = new System.Drawing.Size(257, 61);
            this.button_DecipherShortWords.TabIndex = 0;
            this.button_DecipherShortWords.Text = "Расшифровка сокращений";
            this.button_DecipherShortWords.UseVisualStyleBackColor = true;
            this.button_DecipherShortWords.Click += new System.EventHandler(this.button_DecipherShortWords_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label_NumberExample);
            this.groupBox1.Controls.Add(this.button_ChangeRomaniansToArab);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 177);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Римские цифры в арабские";
            // 
            // Label_NumberExample
            // 
            this.Label_NumberExample.AutoSize = true;
            this.Label_NumberExample.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label_NumberExample.Location = new System.Drawing.Point(13, 127);
            this.Label_NumberExample.Name = "Label_NumberExample";
            this.Label_NumberExample.Size = new System.Drawing.Size(215, 25);
            this.Label_NumberExample.TabIndex = 1;
            this.Label_NumberExample.Text = "IV становится 4 и т.д.";
            // 
            // button_ChangeRomaniansToArab
            // 
            this.button_ChangeRomaniansToArab.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_ChangeRomaniansToArab.Location = new System.Drawing.Point(18, 59);
            this.button_ChangeRomaniansToArab.Name = "button_ChangeRomaniansToArab";
            this.button_ChangeRomaniansToArab.Size = new System.Drawing.Size(226, 61);
            this.button_ChangeRomaniansToArab.TabIndex = 0;
            this.button_ChangeRomaniansToArab.Text = "Заменить римские на арабские";
            this.button_ChangeRomaniansToArab.UseVisualStyleBackColor = true;
            this.button_ChangeRomaniansToArab.Click += new System.EventHandler(this.button_ChangeRomaniansToArab_Click);
            // 
            // groupBox_FileChangingHistory
            // 
            this.groupBox_FileChangingHistory.Controls.Add(this.richTextBox_FileFormattingHistory);
            this.groupBox_FileChangingHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.groupBox_FileChangingHistory.Location = new System.Drawing.Point(6, 330);
            this.groupBox_FileChangingHistory.Name = "groupBox_FileChangingHistory";
            this.groupBox_FileChangingHistory.Size = new System.Drawing.Size(854, 235);
            this.groupBox_FileChangingHistory.TabIndex = 1;
            this.groupBox_FileChangingHistory.TabStop = false;
            this.groupBox_FileChangingHistory.Text = "История примитивного изменения текста";
            // 
            // richTextBox_FileFormattingHistory
            // 
            this.richTextBox_FileFormattingHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.richTextBox_FileFormattingHistory.Location = new System.Drawing.Point(3, 26);
            this.richTextBox_FileFormattingHistory.Name = "richTextBox_FileFormattingHistory";
            this.richTextBox_FileFormattingHistory.ReadOnly = true;
            this.richTextBox_FileFormattingHistory.Size = new System.Drawing.Size(845, 203);
            this.richTextBox_FileFormattingHistory.TabIndex = 0;
            this.richTextBox_FileFormattingHistory.Text = "";
            // 
            // openFileDialog_TxtDoc
            // 
            this.openFileDialog_TxtDoc.FileName = "openFileDialog_Name";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 627);
            this.Controls.Add(this.TAB_MainTab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Предварительная обрабокта текста";
            this.TAB_MainTab.ResumeLayout(false);
            this.tabPage_FileJob.ResumeLayout(false);
            this.groupBox_CurrentFileInfo.ResumeLayout(false);
            this.groupBox_QuantitySentences.ResumeLayout(false);
            this.groupBox_QuantitySentences.PerformLayout();
            this.groupBox_FileSize.ResumeLayout(false);
            this.groupBox_FileSize.PerformLayout();
            this.groupBox_FileName.ResumeLayout(false);
            this.groupBox_FileName.PerformLayout();
            this.groupBox_FileHistory.ResumeLayout(false);
            this.tabPage_WordFormatting.ResumeLayout(false);
            this.groupBox_Saving.ResumeLayout(false);
            this.groupBox_SaveFormat.ResumeLayout(false);
            this.groupBox_SaveFormat.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_FileChangingHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TAB_MainTab;
        private System.Windows.Forms.TabPage tabPage_FileJob;
        private System.Windows.Forms.TabPage tabPage_WordFormatting;
        private System.Windows.Forms.GroupBox groupBox_FileHistory;
        private System.Windows.Forms.RichTextBox richTextBox_FileHistory;
        private System.Windows.Forms.GroupBox groupBox_CurrentFileInfo;
        private System.Windows.Forms.GroupBox groupBox_FileName;
        private System.Windows.Forms.Label Label_FileName;
        private System.Windows.Forms.GroupBox groupBox_FileSize;
        private System.Windows.Forms.Label Label_FileSize;
        private System.Windows.Forms.Button Button_UploadFile;
        private System.Windows.Forms.GroupBox groupBox_FileChangingHistory;
        private System.Windows.Forms.RichTextBox richTextBox_FileFormattingHistory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_ChangeRomaniansToArab;
        private System.Windows.Forms.Label Label_NumberExample;
        private System.Windows.Forms.OpenFileDialog openFileDialog_TxtDoc;
        private System.Windows.Forms.Button button_SaveChanges;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_DecipherShortWords;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_ExampleSimilarWords;
        private System.Windows.Forms.Button button_ChangeSimilarWords;
        private System.Windows.Forms.GroupBox groupBox_QuantitySentences;
        private System.Windows.Forms.Label label_QuantitySentences;
        private System.Windows.Forms.GroupBox groupBox_Saving;
        private System.Windows.Forms.GroupBox groupBox_SaveFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton_Docx;
        private System.Windows.Forms.RadioButton radioButton_TXT;
    }
}

