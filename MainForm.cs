using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Notepad_
{
    /// <summary>
    /// Класс, реализующий окно Главной вкладки.
    /// </summary>
    public partial class MainForm : Form
    {
        // Горячие клавиши для Главной вкладки
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
                CreateInMainWinToolStripMenuItem_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.O)
                OpenInMainWinToolStripMenuItem_Click(sender, null);
            if (e.Control && e.KeyCode == Keys.S)
                Save();
            if (e.Control && e.Shift && e.KeyCode == Keys.S)
                SaveAs();
            if (e.Control && e.KeyCode == Keys.A)
                SaveAllOpenFilesToolStripMenuItem_Click(sender, null);
            if (e.Control && e.KeyCode == Keys.Z)
                UndoToolStripMenuItem_Click(sender, null);
            if (e.Control && e.Shift && e.KeyCode == Keys.Z)
                RedoToolStripMenuItem_Click(sender, null);
            if (e.Control && e.KeyCode == Keys.H)
                HotkeyListToolStripMenuItem_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.W)
                ChangeWorkPlaceToolStripMenuItem_Click(sender, null);
            if (e.Control && e.Shift && e.KeyCode == Keys.B)
                CreateInNewTabToolStripMenuItem_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.N)
                CreateInNewWinToolStripMenuItem_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.End)
                CloseToolStripMenuItem_Click(sender, e);
        }
        public string FileName { get; set; }
        /// <summary>
        /// Состояние файла, true - изменения не сохранены, false - изменения сохранены
        /// </summary>
        public bool TbChange { get; set; }
        /// <summary>
        /// Цвет шрифта
        /// </summary>
        public Color FontColor { get; set; }

        /// <summary>
        /// Список всех открытых вкладок всех открытых окон.
        /// </summary>
        private readonly static List<TabForm> generalTabForms = new();
        /// <summary>
        /// Список всех откртых вкладок данного окна.
        /// </summary>
        private readonly List<TabForm> privateTabForms = new();

        private static bool start = false;

        private void richTextBoxMF_TextChanged(object sender, EventArgs e)
        {
            TbChange = true;
            richTextBoxMF.SelectionColor = FontColor;
        }
        /// <summary>
        /// Конструктор формы Главного окна.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            TbChange = false;
            Text = $"Notepad+";
        }

        // Работа  текстом

        private void SelectAllTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAllToolStripMenuItem_Click(sender, e);
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMF?.Copy();
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMF?.Paste();
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMF?.Cut();
        }
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMF?.SelectAll();
        }
        private void ChoiceMainFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialogMF.ShowDialog();
            richTextBoxMF.Font = fontDialogMF.Font;
        }
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMF.Undo();
        }
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMF.Redo();
        }

        // РАабота с контекстным меню

        private void richTextBoxMF_MouseDown(object sender, MouseEventArgs e)
        {
            // При нажатии правой кнопой мыши в области richTextBoxMF вызывается контекстное меню.
            if (e.Button == MouseButtons.Right)
                richTextBoxMF.ContextMenuStrip = contextMenuStripMF;
        }

        private void SetFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxMF.SelectionFont != null)
            {
                FontDialog fontDialog = new();
                fontDialog.ShowDialog();
                richTextBoxMF.SelectionFont = fontDialog.Font;
            }
        }

        // Темы

        private void LightThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.White;
            menuStripMF.BackColor = Color.White;
            foreach (TabForm form in panelMF.Controls)
            {
                // белый шрифт --> сейчас темная тема --> меняем тему на свтлую 
                if (form.FontColor == Color.White)
                    form.ChangeThemeToolStripMenuItem_Click(sender, e);
            }
            foreach (ToolStripMenuItem m in menuStripMF.Items)
            {
                Light.SetBlackColor(m);
            }
            menuStripMF.Renderer = new ToolStripProfessionalRenderer(new Light());
            Light.LightTab(ref richTextBoxMF, ref contextMenuStripMF);
            // Меняем цвет шрифта
            FontColor = Color.Black;
            richTextBoxMF.ForeColor = Color.Black;
            richTextBoxMF.SelectionColor = Color.Black;
            // Меняем и сохраняем настройки приложения.
            Properties.Settings.Default.color = Color.Black;
            Properties.Settings.Default.Save();
        }

        private void DarkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStripMF.BackColor = Color.FromArgb(30, 30, 30);
            BackColor = Color.FromArgb(45, 45, 48);

            foreach (TabForm form in panelMF.Controls)
            {
                // черный шрифт --> сейчас светлая тема --> меняем тему на темную 
                if (form.FontColor == Color.Black)
                    form.ChangeThemeToolStripMenuItem_Click(sender, e);
            }
            foreach (ToolStripMenuItem m in menuStripMF.Items)
            {
                Dark.SetWhiteColor(m);
            }
            Dark.DarkTab(ref richTextBoxMF, ref contextMenuStripMF);
            menuStripMF.Renderer = new ToolStripProfessionalRenderer(new Dark());
            // Меняем цвет шрифта
            FontColor = Color.White;
            richTextBoxMF.ForeColor = Color.White;
            richTextBoxMF.SelectionColor = Color.White;
            // Меняем и сохраняем настройки приложения.
            Properties.Settings.Default.color = Color.White;
            Properties.Settings.Default.Save();
        }

        // Таймеры
        private void timerAutoSave_Tick(object sender, EventArgs e)
        {
            AutoSaveAllFiles();
        }
        private void ThreeMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerAutoSave.Interval = 180000;
        }
        private void ThirtySecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerAutoSave.Interval = 30000;
        }
        private void OneMinuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerAutoSave.Interval = 60000;
        }

        // Закрытие окна
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult message1 = MessageBox.Show("Вы уверны, что хотите закрыть приложение?", "Закрытие приложения", MessageBoxButtons.YesNo);
                if (message1 == DialogResult.No)
                    e.Cancel = true;
                // Закрываем все Побочные вкладки.
                if (privateTabForms.Count != 0 && e.Cancel == false)
                {
                    foreach (TabForm form in privateTabForms)
                    {
                        form.Close();
                    }
                }
                if (TbChange == true && e.Cancel == false)
                {
                    DialogResult message;
                    if (FileName != null && FileName != "")
                        message = MessageBox.Show("Сохранить документ перед закрытием приложения?", $"{FileName}-Закрытие приложения", MessageBoxButtons.YesNo);
                    else
                        message = MessageBox.Show("Сохранить документ перед закрытием приложения?", "Несохраненный документ-Закрытие приложения", MessageBoxButtons.YesNo);
                    if (message == DialogResult.Yes)
                    {
                        if (FileName != null && FileName != "")
                            Save();
                        else if (FileName == null || FileName == "")
                            SaveAs();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Проверяем, есть ли еще открытые окна, если нет - работа должна быть закончена.
            if (Application.OpenForms.Count == 0)
            {
                // Список путей к файлам, изменения которых не были сохранены после закрытия приложения.
                List<string> path = new();
                // Если файл в Главной вкладке имеет путь и не был сохранен, запоминаем путь к нему.
                if (FileName != null && TbChange == true)
                {
                    path.Add(FileName);
                }
                // Аналогично проходимся по побочным вкладкам.
                foreach (TabForm form in generalTabForms)
                {
                    if (form.FileName != null && form.TbChange == true)
                    {
                        path.Add(form.FileName);
                    }
                }
                // Записываем список в файл, сериализировав его.
                using StreamWriter sw = new("tabs.txt", true);
                sw.WriteLine(JsonSerializer.Serialize(path));
            }
        }

        

        // Вкладка меню "Помощь"
        private void HotkeyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ctrl+B- Создать документ в Главной вкладке.\n" +
                "Ctrl+Shift+B - Создать документ в Побочной вкладке.\n" +
                "Ctrl+N - Создать документ в новом окне.\n" +
                "Ctrl+O - Открыть документ в Главной вкладке.\n" +
                "Ctrl+S - Сохранить документ.\n" +
                "Ctrl+Shift+S - Сохранить документ как.\n" +
                "Ctrl+A - Сохранить все окткрытые в окне приложения.\n" +
                "Ctrl+W - Сменить место работы (перейти к побочным вкладкам от главной или наоборот).\n" +
                "Ctrl+Z - Отмена действия.\n" +
                "Ctrl+Shift+Z - Повтор отмененного действия.\n" +
                "Ctrl+H - Вывод списка горячих клавиш.\n" +
                "Ctrl+End - Закрыть приложение.\n", "Список горячих клавиш в Главной вкладке.");
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using StreamReader readme = new("../../../README.txt");
                while (readme.EndOfStream is false)
                {
                    MessageBox.Show(readme.ReadToEnd(), "Помощь", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        // MAIN MENU

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        // Сохранение всех открытых файлов.
        private void SaveAllOpenFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AutoSaveAllFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        // Открытие в Новом окне.
        private void OpenInNewWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm form = new();
            form.Open();
            form.Show();
        }

        // Выход по нажатию кнопки в меню.
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Открыть в Главной вкладке
        private void OpenInMainWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Делаем панель вкладок невидомй, так как переходим к работе в Главной вкладке
            panelMF.Visible = false;
            // Проверяем, сохранены ли изменения текущего открытого документа.
            if (TbChange == true)
            {
                DialogResult message = MessageBox.Show("Сохранить текущий документ перед открытием нового?", "Открытие документа", MessageBoxButtons.YesNoCancel);
                if (message == DialogResult.Yes)
                {
                    // Имя файла не пустое --> файл уже хранится на диске --> сохраняем по тому же пути
                    if (FileName != null && FileName != "")
                    {
                        Save();
                        Open();
                    }
                    // Имя файла пустое --> файл еще ни разу не сохранен --> используем "сохранить как"
                    else if (FileName == null || FileName == "")
                    {
                        SaveAs();
                        Open();
                    }
                }
                else if (message == DialogResult.No)
                    Open();
            }
            else
                Open();
        }

        // Открыть в Побочной вкладке.
        private void OpenInNewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabForm form = new();
            ShowChildForm(form);
            form.Open();
        }

        private void ShowChildForm(TabForm form)
        {
            // Устанавливаем, что Главная форма это родитель Побочной.
            form.MdiParent = this;
            // Выводим на передний план панель с побочными вкладками.
            panelMF.Visible = true;
            // Добавляем Побочную вкладку в список личный и общих вкладок.
            generalTabForms.Add(form);
            privateTabForms.Add(form);
            // Добавляем вкладку в панель, что бы она отображалась в ней.
            panelMF.Controls.Add(form);
            form.FontColor = FontColor;
            form.Show();
        }
        // Смена места работы.
        private void ChangeWorkPlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Делаем панель вкладок видимой и невидимой, в зависимости от начального состояния.
            if (panelMF.Visible == true)
                panelMF.Visible = false;
            else
                panelMF.Visible = true;
        }
        // Создание файла в Побочной вкладке.
        private void CreateInNewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabForm form = new();
            ShowChildForm(form);
        }
        // Создание файла в Новом окне.
        private void CreateInNewWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm form = new();
            form.Show();
        }

        // Создание файла в Главной вкладке.
        private void CreateInMainWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TbChange == true)
            {
                DialogResult message = MessageBox.Show("Сохранить текущий документ перед созданием нового?", "Создание документа", MessageBoxButtons.YesNoCancel);
                if (message == DialogResult.Yes)
                {
                    if (FileName != null && FileName != "")
                    {
                        Save();
                        Create();
                    }
                    else if (FileName == null || FileName == "")
                    {
                        SaveAs();
                        Create();
                    }
                }
                else if (message == DialogResult.No)
                    Create();
            }
            else
                Create();
        }
        /// <summary>
        /// Создание нового документа в приложении.
        /// </summary>
        public void Create()
        {
            richTextBoxMF.Text = "";
            FileName = "";
            TbChange = false;
            Text = "Новый документ - Notepad+";
        }

        private void CodeEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeForm form = new();
            form.Show();
        }
        private void MainForm_Load_1(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.color == Color.Black)
                LightThemeToolStripMenuItem_Click(sender, e);
            else
                DarkThemeToolStripMenuItem_Click(sender, e);
            if (start == false)
            {
                start = true;
                using (StreamReader sr = new("tabs.txt"))
                {
                    string tabsSt = null;
                    while (sr.EndOfStream is false)
                    {
                        tabsSt = sr.ReadToEnd();
                    }
                    if (tabsSt != null)
                    {
                        char[] charsToTrim = { ' ', '\r', '\n' };
                        string pathSt = tabsSt.Trim(charsToTrim);
                        if (pathSt != null && pathSt != "")
                        {
                            List<string> paths = JsonSerializer.Deserialize<List<string>>(pathSt);
                            foreach (string filename in paths)
                            {
                                TabForm form = new();
                                form.OpenFile(filename);
                                ShowChildForm(form);
                            }
                        }
                    }
                }
                using (StreamWriter sr = new("tabs.txt")) { }
            }
        }

        /// <summary>
        /// Открытие в Главной вкладке
        /// </summary>
        public void Open()
        {
            try
            {
                OpenFileDialog openFileDialog = new();
                openFileDialog.Title = "Открыть документ";
                openFileDialog.FileName = "Текстовый документ";
                openFileDialog.Filter = "Текстовые файлы (*.txt) |*.txt| RTF файл (*.rtf)|*.rtf| Все файлы (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                FileName = openFileDialog.FileName;
                using StreamReader sr = new(FileName);
                while (sr.EndOfStream is false)
                {
                    if (FileName.Substring(FileName.LastIndexOf('.')) == ".rtf")
                        richTextBoxMF.Rtf = sr.ReadToEnd();
                    else
                        richTextBoxMF.Text = sr.ReadToEnd();
                }
                TbChange = false;
                Text = $"{FileName} - Notepad+";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка {ex.Message}", "Ошибка");
            }

        }
        /// <summary>
        /// Автосохранение всех файлов в приложении.
        /// </summary>
        public void AutoSaveAllFiles()
        {
            try
            {
                if (TbChange == true && (FileName != null && FileName != ""))
                {
                    using StreamWriter sw2 = new(FileName);
                    if (FileName.Substring(FileName.LastIndexOf('.')) == ".rtf")
                        sw2.Write(richTextBoxMF.Rtf);
                    else
                        sw2.Write(richTextBoxMF.Text);
                }

                if (panelMF.Controls.Count != 0)
                {
                    foreach (TabForm form in panelMF.Controls)
                    {
                        if (form.TbChange == true && form.FileName != null && form.FileName != "")
                            form.AutoSave();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка при автосохранении"); }
        }
        /// <summary>
        /// СОхранить как... для Главной вкладки.
        /// </summary>
        public void SaveAs()
        {
            try
            {
                SaveFileDialog saveAsDocument = new();
                saveAsDocument.Title = "Сохранить документ как...";
                saveAsDocument.FileName = "Текстовый документ";
                saveAsDocument.Filter = "Текстовые файлы (*.txt) |*.txt| Все файлы (*.*)|*.*";

                if (saveAsDocument.ShowDialog() == DialogResult.Cancel)
                    return;
                FileName = saveAsDocument.FileName;

                using (StreamWriter sw = new(FileName))
                {
                    if (FileName.Substring(FileName.LastIndexOf('.')) == ".rtf")
                        sw.Write(richTextBoxMF.Rtf);
                    else
                        sw.Write(richTextBoxMF.Text);
                }
                TbChange = false;
                MessageBox.Show("Файл успешно сохранен.", $"{FileName}-Сохранение");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка {ex.Message}", "Ошибка");
            }
        }
        /// <summary>
        /// Сохранить для Главной вкладки.
        /// </summary>
        public void Save()
        {
            try
            {
                using StreamWriter sw = new(FileName);
                if (FileName.Substring(FileName.LastIndexOf('.')) == ".rtf")
                    sw.Write(richTextBoxMF.Rtf);
                else
                    sw.Write(richTextBoxMF.Text);
                TbChange = false;
                MessageBox.Show("Файл успешно сохранен.", $"{FileName}-Сохранение");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка {ex.Message}", "Ошибка");
            }
        }

    }
}
