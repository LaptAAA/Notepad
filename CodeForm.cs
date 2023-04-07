using System;
using System.IO;
using System.Windows.Forms;

namespace Notepad_
{
    /// <summary>
    /// Класс, реализующий окно "Редактор кода"
    /// </summary>
    public partial class CodeForm : Form
    {
        /// <summary>
        /// Имя файла, который открыт в окне или вкладке.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Состояние файла, true - изменения не сохранены, false - изменения сохранены
        /// </summary>
        public bool TbChange { get; set; }
        /// <summary>
        /// Конструктор формы Редактор кода.
        /// </summary>
        public CodeForm()
        {
            InitializeComponent();
            Text = "Редактор кода";
        }
        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            TbChange = true;
        }

        // Меню
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create();
        }
        
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Создать для окна Редактор кода
        /// </summary>
        public void Create()
        {
            fastColoredTextBoxCE.Text = "";
            FileName = "";
            TbChange = false;
        }

        private void CodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (TbChange == true)
                {
                    DialogResult message;
                    if (FileName != null && FileName != "")
                        message = MessageBox.Show("Сохранить документ перед закрытием редактора?", $"{FileName}-Закрытие редактора", MessageBoxButtons.YesNoCancel);
                    else
                        message = MessageBox.Show("Сохранить документ перед закрытием редактора?", "Несохраненный документ-Закрытие редактора", MessageBoxButtons.YesNoCancel);
                    if (message == DialogResult.Yes)
                    {
                        if (FileName != null && FileName != "")
                            Save();
                        else if (FileName == null || FileName == "")
                            SaveAs();
                    }
                    else if (message == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка {ex.Message}", "Ошибка");
            }
        }
        /// <summary>
        /// Сохранить для окна Редактор кода.
        /// </summary>
        public void Open()
        {
            try
            {
                OpenFileDialog openFileDialog = new();
                openFileDialog.Title = "Открыть документ";
                openFileDialog.FileName = "C# документ";
                openFileDialog.Filter = "C# файлы (*.cs) |*.cs";

                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                FileName = openFileDialog.FileName;

                using StreamReader sr = new(FileName);
                while (sr.EndOfStream is false)
                {
                    fastColoredTextBoxCE.Text = sr.ReadToEnd();
                }
                Text = $"{FileName} - Редактор кода";
                TbChange = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка {ex.Message}", "Ошибка");
            }
            
        }
        /// <summary>
        /// Сохранить как для Редактора кода.
        /// </summary>
        public void SaveAs()
        {
            try
            {
                SaveFileDialog saveAsDocument = new();
                saveAsDocument.Title = "Сохранить документ как...";
                saveAsDocument.FileName = "C# документ";
                saveAsDocument.Filter = "C# файлы (*.cs) |*.cs";

                if (saveAsDocument.ShowDialog() == DialogResult.Cancel)
                    return;

                FileName = saveAsDocument.FileName;

                using StreamWriter sw = new(FileName);
                sw.Write(fastColoredTextBoxCE.Text);

                TbChange = false;
                Text = $"{FileName} - Редактор кода";

                MessageBox.Show("Файл успешно сохранен.", $"{FileName}-Сохранение");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка {ex.Message}", "Ошибка");
            }
            
        }
        /// <summary>
        /// Сохранить для Редактора кода.
        /// </summary>
        public void Save()
        {
            try
            {
                using StreamWriter sw = new(FileName);
                sw.Write(fastColoredTextBoxCE.Text);
                TbChange = false;
            } catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка {ex.Message}", "Ошибка");
            }
            
        }

    }
}
