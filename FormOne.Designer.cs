namespace SyncClientWinForms
{
   partial class FormOne
   {
      /// <summary>
      ///  Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      ///  Clean up any resources being used.
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
      ///  Required method for Designer support - do not modify
      ///  the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         ButtonClear = new System.Windows.Forms.Button();
         RichTextBoxReader = new System.Windows.Forms.RichTextBox();
         ListBoxReader = new System.Windows.Forms.ListBox();
         TextBoxReader = new System.Windows.Forms.TextBox();
         ButtonStart = new System.Windows.Forms.Button();
         SuspendLayout();
         // 
         // ButtonClear
         // 
         ButtonClear.Location = new System.Drawing.Point(668, 333);
         ButtonClear.Name = "ButtonClear";
         ButtonClear.Size = new System.Drawing.Size(90, 23);
         ButtonClear.TabIndex = 18;
         ButtonClear.Text = "Clear";
         ButtonClear.UseVisualStyleBackColor = true;
         // 
         // RichTextBoxReader
         // 
         RichTextBoxReader.Location = new System.Drawing.Point(12, 198);
         RichTextBoxReader.Name = "RichTextBoxReader";
         RichTextBoxReader.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
         RichTextBoxReader.Size = new System.Drawing.Size(370, 180);
         RichTextBoxReader.TabIndex = 17;
         RichTextBoxReader.Text = "";
         // 
         // ListBoxReader
         // 
         ListBoxReader.FormattingEnabled = true;
         ListBoxReader.ItemHeight = 15;
         ListBoxReader.Location = new System.Drawing.Point(388, 12);
         ListBoxReader.Name = "ListBoxReader";
         ListBoxReader.ScrollAlwaysVisible = true;
         ListBoxReader.Size = new System.Drawing.Size(370, 184);
         ListBoxReader.TabIndex = 16;
         // 
         // TextBoxReader
         // 
         TextBoxReader.Location = new System.Drawing.Point(12, 12);
         TextBoxReader.Multiline = true;
         TextBoxReader.Name = "TextBoxReader";
         TextBoxReader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         TextBoxReader.Size = new System.Drawing.Size(370, 180);
         TextBoxReader.TabIndex = 15;
         // 
         // ButtonStart
         // 
         ButtonStart.Location = new System.Drawing.Point(468, 238);
         ButtonStart.Name = "ButtonStart";
         ButtonStart.Size = new System.Drawing.Size(110, 23);
         ButtonStart.TabIndex = 14;
         ButtonStart.Text = "Запуск сервера";
         ButtonStart.UseVisualStyleBackColor = true;
         // 
         // FormOne
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(770, 420);
         Controls.Add(ButtonClear);
         Controls.Add(RichTextBoxReader);
         Controls.Add(ListBoxReader);
         Controls.Add(TextBoxReader);
         Controls.Add(ButtonStart);
         Name = "FormOne";
         StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         Text = "Синхронный Json клиент Windows Forms";
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private System.Windows.Forms.Button ButtonClear;
      private System.Windows.Forms.RichTextBox RichTextBoxReader;
      private System.Windows.Forms.ListBox ListBoxReader;
      private System.Windows.Forms.TextBox TextBoxReader;
      private System.Windows.Forms.Button ButtonStart;
   }
}
