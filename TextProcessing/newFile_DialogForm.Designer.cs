namespace TextProcessing
{
    partial class newFile_DialogForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_AgreeNewFile = new System.Windows.Forms.Button();
            this.Button_CancelNewFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(93, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(581, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Внимание! Вы пытаетесь загрузить новый файл.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(79, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(608, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Предыдущие изменения могут быть не сохранены!";
            // 
            // Button_AgreeNewFile
            // 
            this.Button_AgreeNewFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_AgreeNewFile.ForeColor = System.Drawing.Color.Green;
            this.Button_AgreeNewFile.Location = new System.Drawing.Point(98, 89);
            this.Button_AgreeNewFile.Name = "Button_AgreeNewFile";
            this.Button_AgreeNewFile.Size = new System.Drawing.Size(166, 41);
            this.Button_AgreeNewFile.TabIndex = 2;
            this.Button_AgreeNewFile.Text = "Принять";
            this.Button_AgreeNewFile.UseVisualStyleBackColor = true;
            this.Button_AgreeNewFile.Click += new System.EventHandler(this.Button_AgreeNewFile_Click);
            // 
            // Button_CancelNewFile
            // 
            this.Button_CancelNewFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_CancelNewFile.ForeColor = System.Drawing.Color.Red;
            this.Button_CancelNewFile.Location = new System.Drawing.Point(496, 89);
            this.Button_CancelNewFile.Name = "Button_CancelNewFile";
            this.Button_CancelNewFile.Size = new System.Drawing.Size(166, 41);
            this.Button_CancelNewFile.TabIndex = 3;
            this.Button_CancelNewFile.Text = "Отменить";
            this.Button_CancelNewFile.UseVisualStyleBackColor = true;
            this.Button_CancelNewFile.Click += new System.EventHandler(this.Button_CancelNewFile_Click);
            // 
            // newFile_DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 142);
            this.Controls.Add(this.Button_CancelNewFile);
            this.Controls.Add(this.Button_AgreeNewFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "newFile_DialogForm";
            this.Text = "newFile_DialogForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_AgreeNewFile;
        private System.Windows.Forms.Button Button_CancelNewFile;
    }
}