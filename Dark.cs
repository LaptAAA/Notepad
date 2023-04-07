using System.Drawing;
using System.Windows.Forms;

namespace Notepad_
{
    /// <summary>
    /// Класс, реализующий темную тему.
    /// </summary>
    public class Dark : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(0, 122, 204); }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(30, 30, 30); }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(0, 122, 204); }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return Color.FromArgb(30, 30, 30); }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return Color.FromArgb(30, 30, 30); }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(0, 122, 204); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(0, 122, 204); }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(0, 122, 204); }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get { return Color.FromArgb(0, 122, 204); }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(0, 122, 204); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(0, 122, 204); }
        }
        /// <summary>
        /// Смена цвета букв меню в белый цвет.
        /// </summary>
        /// <param name="item">Элемент меню</param>
        public static void SetWhiteColor(ToolStripMenuItem item)
        {
            item.ForeColor = Color.White;
            foreach (ToolStripMenuItem it in item.DropDownItems)
            {
                SetWhiteColor(it);
            }
        }
        /// <summary>
        /// Перекраска вкладки в темную тему.
        /// </summary>
        /// <param name="richTextBox"> Поле ввода вкладки.</param>
        /// <param name="contextMenuStrip1"> Контекстное меню вкладки.</param>
        public static void DarkTab(ref RichTextBox richTextBox, ref ContextMenuStrip contextMenuStrip1)
        {
            // Меняем цвет фона.
            richTextBox.BackColor = Color.FromArgb(30, 30, 30);

            // Покраска цвета букв в richTextBox
            richTextBox.SelectAll();
            richTextBox.SelectionColor = Color.White;
            // Перекраска цвета букв контестного меню
            foreach (ToolStripMenuItem m in contextMenuStrip1.Items)
            {
                SetWhiteColor(m);
            }
            // Перекрашивание контестного меню
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new Dark());
        }

        
    }
}
