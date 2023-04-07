using System.Windows.Forms;

namespace Notepad_
{
    /// <summary>
    /// Класс для реализации завершения приложения только при закрытии всех окон.
    /// </summary>
    public class NotepadApplicationContext : ApplicationContext
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="startupForm"> Начальная форма.</param>
        public NotepadApplicationContext(Form startupForm)
        {
            startupForm.FormClosed += OnFormClosed;
            startupForm.Show();
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count > 0)
            {
                foreach (Form form in Application.OpenForms)
                {
                    form.FormClosed -= OnFormClosed;
                    form.FormClosed += OnFormClosed;
                }
            }
            else ExitThread();
        }
    }
}
