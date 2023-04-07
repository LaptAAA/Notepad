using System.Drawing;
using System.Windows.Forms;
namespace Notepad_
{
    /// <summary>
    /// Класс, реализующий светлую тему.
    /// </summary>
    class Light : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(140, 209, 255); }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return Color.White; }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(140, 209, 255); }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return Color.White; }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return Color.White; }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(140, 209, 255); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(140, 209, 255); }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(140, 209, 255); }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get { return Color.FromArgb(140, 209, 255); }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(140, 209, 255); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(140, 209, 255); }
        }
        /// <summary>
        ///  Смена цвета букв меню в черный цвет.
        /// </summary>
        /// <param name="item"> Элемент меню.</param>
        public static void SetBlackColor(ToolStripMenuItem item)
        {
            item.ForeColor = Color.Black;
            foreach (ToolStripMenuItem it in item.DropDownItems)
            {
                SetBlackColor(it);
            }
        }
        /// <summary>
        /// Перекраска вкладки в светлую тему.
        /// </summary>
        /// <param name="richTextBox">Поле ввода вкладки.</param>
        /// <param name="contextMenuStrip1">Контекстное меню вкладки.</param>
        public static void LightTab(ref RichTextBox richTextBox, ref ContextMenuStrip contextMenuStrip1)
        {
            // Покраска фона
            richTextBox.BackColor = Color.White;
            // Покраска цвета букв в richTextBox
            richTextBox.SelectAll();
            richTextBox.SelectionColor = Color.Black;
            // Перекраска цвета букв контестного меню 
            foreach (ToolStripMenuItem m in contextMenuStrip1.Items)
            {
                Light.SetBlackColor(m);
            }
            // Перекрашивание контестного меню
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new Light());
        }
    }
}
