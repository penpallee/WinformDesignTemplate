using System.Windows.Forms;

namespace MIL_MODULE.Utilities
{
    public sealed class MessageBoxManager
    {
        public static void Error(string title, string message, bool isOkCancle = false)
        {
            if(isOkCancle)
                MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Info(string title, string message, bool isOkCancle = false)
        {
            if (isOkCancle)
                MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            else
                MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string title, string message, bool isOkCancle = false)
        {
            if(isOkCancle)
                MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            else
                MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Stop(string title, string message, bool isOkCancle = false)
        {
            if(isOkCancle)
                MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            else
                MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public static DialogResult Question(string title, string message)
        {
            return System.Windows.Forms.MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
    }
}
