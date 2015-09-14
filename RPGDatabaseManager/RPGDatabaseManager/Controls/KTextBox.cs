using System.Windows.Controls;
using System.Windows.Input;

namespace RPGDatabaseManager.Controls
{
    public partial class KTextBox : TextBox
    {
        public KTextBox()
        {
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Return)
                Keyboard.ClearFocus();
        }
    }
}