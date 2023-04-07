
namespace Notepad_
{
    partial class TabForm
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
            this.components = new System.ComponentModel.Container();
            this.richTextBoxTF = new System.Windows.Forms.RichTextBox();
            this.openFileDialogTF = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStripTF = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.выбратьВесьТекстToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.задатьФорматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вырезатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменитьТемуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTF.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxTF
            // 
            this.richTextBoxTF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxTF.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxTF.Name = "richTextBoxTF";
            this.richTextBoxTF.Size = new System.Drawing.Size(800, 450);
            this.richTextBoxTF.TabIndex = 0;
            this.richTextBoxTF.Text = "";
            this.richTextBoxTF.TextChanged += new System.EventHandler(this.richTextBoxTF_TextChanged);
            this.richTextBoxTF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBoxTF_MouseDown);
            this.richTextBoxTF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBoxTF_MouseDown);
            // 
            // openFileDialogTF
            // 
            this.openFileDialogTF.FileName = "openFileDialog1";
            // 
            // contextMenuStripTF
            // 
            this.contextMenuStripTF.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripTF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьВесьТекстToolStripMenuItem,
            this.вставитьToolStripMenuItem,
            this.задатьФорматToolStripMenuItem,
            this.вырезатьToolStripMenuItem,
            this.копироватьToolStripMenuItem,
            this.отменитьToolStripMenuItem,
            this.повторToolStripMenuItem,
            this.сменитьТемуToolStripMenuItem});
            this.contextMenuStripTF.Name = "contextMenuStrip1";
            this.contextMenuStripTF.Size = new System.Drawing.Size(231, 196);
            // 
            // выбратьВесьТекстToolStripMenuItem
            // 
            this.выбратьВесьТекстToolStripMenuItem.Name = "выбратьВесьТекстToolStripMenuItem";
            this.выбратьВесьТекстToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.выбратьВесьТекстToolStripMenuItem.Text = "Выбрать весь текст";
            this.выбратьВесьТекстToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.вставитьToolStripMenuItem.Text = "Вставить";
            this.вставитьToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // задатьФорматToolStripMenuItem
            // 
            this.задатьФорматToolStripMenuItem.Name = "задатьФорматToolStripMenuItem";
            this.задатьФорматToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.задатьФорматToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.задатьФорматToolStripMenuItem.Text = "Задать формат";
            this.задатьФорматToolStripMenuItem.Click += new System.EventHandler(this.SetFormatToolStripMenuItem_Click);
            // 
            // вырезатьToolStripMenuItem
            // 
            this.вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            this.вырезатьToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.вырезатьToolStripMenuItem.Text = "Вырезать";
            this.вырезатьToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            this.копироватьToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // отменитьToolStripMenuItem
            // 
            this.отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            this.отменитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.отменитьToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.отменитьToolStripMenuItem.Text = "Отменить";
            this.отменитьToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // повторToolStripMenuItem
            // 
            this.повторToolStripMenuItem.Name = "повторToolStripMenuItem";
            this.повторToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.повторToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.повторToolStripMenuItem.Text = "Повтор";
            this.повторToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // сменитьТемуToolStripMenuItem
            // 
            this.сменитьТемуToolStripMenuItem.Name = "сменитьТемуToolStripMenuItem";
            this.сменитьТемуToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.сменитьТемуToolStripMenuItem.Text = "Сменить тему";
            this.сменитьТемуToolStripMenuItem.Click += new System.EventHandler(this.ChangeThemeToolStripMenuItem_Click);
            // 
            // TabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBoxTF);
            this.Name = "TabForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TabForm_FormClosing);
            this.Load += new System.EventHandler(this.TabForm_Load);
            this.contextMenuStripTF.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxTF;
        private System.Windows.Forms.OpenFileDialog openFileDialogTF;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTF;
        private System.Windows.Forms.ToolStripMenuItem выбратьВесьТекстToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem задатьФорматToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вырезатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem повторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменитьТемуToolStripMenuItem;
    }
}