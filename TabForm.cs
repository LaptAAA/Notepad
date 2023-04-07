using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Notepad_
{
    /// <summary>
    /// Класс, реализующий Побочную вкладку.
    /// </summary>
    public partial class TabForm  : Form
    {
        // Горячие клавиши
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                Save();
            if (e.Control && e.Shift && e.KeyCode == Keys.S)
                SaveAs();
            if (e.Control && e.KeyCode == Keys.Z)
                UndoToolStripMenuItem_Click(sender, e);
            if (e.Control && e.Shift && e.KeyCode == Keys.Z)
                RedoToolStripMenuItem_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.F)
                SetFormatToolStripMenuItem_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.H)
                Help();
        }
        /// <summary>
        /// Путь файла, открытого в Побочной вкладке.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Состояние файла, true - изменения не сохранены, false - изменения сохранены
        /// </summary>
        public bool TbChange { get; set; }
        /// <summary>
        /// Цвет шрифта
        /// </summary>
        public Color FontColor { get; set; }
        private void richTextBoxTF_TextChanged(object sender, EventArgs e)
        {
            richTextBoxTF.ForeColor = FontColor;
            richTextBoxTF.SelectionColor = FontColor;
            TbChange = true;
        }
        /// <summary>
        /// Конструктор формы Побочной вкладки
        /// </summary>
        public TabForm()
        {
            InitializeComponent();
            TbChange = false;
            Text = $"{FileName} Побочная вкладка";
        }
        private void TabForm_Load(object sender, EventArgs e)
        {
            if (FontColor == Color.Black)
            {
                // черный шрифт --> светлая тема --> создаем светлую вкладку
                BackColor = Color.White;
                Light.LightTab(ref richTextBoxTF, ref contextMenuStripTF);
            }
            else
            {
                BackColor = Color.FromArgb(45, 45, 48);
                Dark.DarkTab(ref richTextBoxTF, ref contextMenuStripTF);
            }
        }
        private void TabForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TbChange == true)
            {
                DialogResult message;
                if (FileName != null && FileName != "")
                    message = MessageBox.Show("Сохранить документ перед закрытием вкладки?", $"{FileName}-Закрытие вкладки", MessageBoxButtons.YesNo);
                else
                    message = MessageBox.Show("Сохранить документ перед закрытием вкладки?", "Несохраненный документ-Закрытие вкладки", MessageBoxButtons.YesNo);
                if (message == DialogResult.Yes)
                {
                    if (FileName != null && FileName != "")
                    {
                        Save();
                    }
                    else if (FileName == null || FileName == "")
                    {
                        SaveAs();
                    }
                }  
            }
        }
        // Контекстное меню
        private void richTextBoxTF_MouseDown(object sender, MouseEventArgs e)
        {
            // Вызов вконтестного меню по нажатию правой кнопки мыши
            if (e.Button == MouseButtons.Right)
                richTextBoxTF.ContextMenuStrip = contextMenuStripTF;
        }
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxTF.TextLength > 0)
                richTextBoxTF?.SelectAll();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
                richTextBoxTF?.Paste();
        }

        private void SetFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxTF.SelectionFont != null)
            {
                FontDialog fontDialog = new();
                fontDialog.ShowDialog();
                richTextBoxTF.SelectionFont = fontDialog.Font;
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBoxTF?.SelectedText);
            richTextBoxTF.SelectedText = "";
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
                richTextBoxTF?.Copy();
        }
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxTF.Undo();
        }
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxTF.Redo();
        }
        /// <summary>
        /// Смена темы Побочной вкладки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChangeThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FontColor == Color.Black)   
            {
                // черный шрифт --> светлая тема --> перекрашиваем в темный
                BackColor = Color.FromArgb(45, 45, 48);
                Dark.DarkTab(ref richTextBoxTF, ref contextMenuStripTF);
                FontColor = Color.White;
                richTextBoxTF.ForeColor = Color.White;
            }
            else
            {                                  
                // белый шрифт --> сейчас темная тема --> перекрашиваем в светлое 
                BackColor = Color.White;
                Light.LightTab(ref richTextBoxTF, ref contextMenuStripTF);
                FontColor = Color.Black;
                richTextBoxTF.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// Список горячих клавиш
        /// </summary>
        private static void Help()
        {
            MessageBox.Show(
            "Ctrl+S - Сохранить документ.\n" +
            "Ctrl+Shift+S - Сохранить документ как.\n" +
            "Ctrl+Z - Отмена действия.\n" +
            "Ctrl+Shift+Z - Повтор отмененного действия.\n" +
            "Ctrl+W - Сменить место работы (перейти к побочным вкладкам от главной или наоборот).\n" +
            "Ctrl+F - Задать фоомат выделенного текста\n"+
            "Ctrl+H - Вывод списка горячих клавиш.\n",
            "Список горячих клавиш в Побочной вкладке.");
        }
        /// <summary>
        /// Открыть файл
        /// </summary>
        /// <param name="path"> Файл, который открывается в Побочной вкладке.</param>
        public void OpenFile(string path)
        {
            try
            {
                if (path != null)
                {

                    FileName = path;
                    using StreamReader sr = new StreamReader(path);
                    while (sr.EndOfStream is false)
                    {
                        if (FileName?.Substring(FileName.LastIndexOf('.')) == ".rtf")
                            richTextBoxTF.Rtf = sr.ReadToEnd();
                        else
                            richTextBoxTF.Text = sr.ReadToEnd();
                    }
                    TbChange = false;
                    Text = $"{FileName} - Побочная вкладка";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Произошла ошибка {ex.Message}", "Ошибка");
            }
        }
        /// <summary>
        /// Открыть Побочной вкладки
        /// </summary>
        public void Open()
        {
            try
            {
                OpenFileDialog openFileDialog = new();
                openFileDialog.Title = "Открыть документ";
                openFileDialog.FileName = "Текстовый документ";
                openFileDialog.Filter = "Текстовые файлы (*.txt) |*.txt| RTF файлы (*.rtf)|*.rtf| Все файлы (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                FileName = openFileDialog.FileName;

                using StreamReader sr = new(FileName);
                while (sr.EndOfStream is false)
                {
                    if (FileName.Substring(FileName.LastIndexOf('.')) == ".rtf")
                        richTextBoxTF.Rtf = sr.ReadToEnd();
                    else
                        richTextBoxTF.Text = sr.ReadToEnd();
                }
                Text = $"{FileName} - Побочная вкладка";
                TbChange = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка {ex.Message}", "Ошибка");
            }
        }
        /// <summary>
        ///  Сохранить как... Побочной вкладки
        /// </summary>
        public void SaveAs()
        {
            try
            {
                SaveFileDialog saveAsDocument = new();
                saveAsDocument.Title = "Сохранить документ как...";
                saveAsDocument.FileName = "Текстовый документ";
                saveAsDocument.Filter = "Текстовые файл (*.txt) |*.txt|RTF файл (*.rtf)|*.rtf";

                if (saveAsDocument.ShowDialog() == DialogResult.Cancel)
                    return;

                FileName = saveAsDocument.FileName;

                using StreamWriter sw = new(FileName);
                if (FileName.Substring(FileName.LastIndexOf('.')) == ".rtf")
                    sw.Write(richTextBoxTF.Rtf);
                else
                    sw.Write(richTextBoxTF.Text);

                TbChange = false;
                Text = $"{FileName} - Побочная вкладка";

                MessageBox.Show("Файл успешно сохранен.", $"{FileName}-Сохранение");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка {ex.Message}", "Ошибка");
            } 
        }
        /// <summary>
        /// Сохранение Побочной вкладки
        /// </summary>
        public void Save()
        {
            try
            {
                using StreamWriter sw = new(FileName);
                if (FileName.Substring(FileName.LastIndexOf('.')) == ".rtf")
                    sw.Write(richTextBoxTF.Rtf);
                else
                    sw.Write(richTextBoxTF.Text);
                TbChange = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка {ex.Message}", "Ошибка");
            }
        }
        /// <summary>
        /// Автосохранение Побочной вкладки
        /// </summary>
        public void AutoSave()
        {
            using StreamWriter sw = new(FileName);
            if (FileName.Substring(FileName.LastIndexOf('.')) == ".rtf")
                sw.Write(richTextBoxTF.Rtf);
            else
                sw.Write(richTextBoxTF.Text);
        }
    }
}
