namespace VSPackage.ScaffolderPackage.Core
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;

    /// <summary>
    /// Logger that appends messages to provided RichTextBox control
    /// </summary>
    public class RichTextBoxLogger : ILogger
    {
        private RichTextBox richTextBox;

        public RichTextBoxLogger(RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
        }

        /// <summary>
        /// Logs error message
        /// </summary>
        public void Error(string text, object obj = null)
        {
            AppendLineToRichTextBox(text, Brushes.Red);
        }

        /// <summary>
        /// Logs info message
        /// </summary>
        public void Info(string text, object obj = null)
        {
            AppendLineToRichTextBox(text, Brushes.Black);
        }

        /// <summary>
        /// Logs warning message
        /// </summary>
        public void Warn(string text, object obj = null)
        {
            AppendLineToRichTextBox(text, Brushes.DarkOrange);
        }

        private void AppendLineToRichTextBox(string text, SolidColorBrush color)
        {
            TextRange tr = new TextRange(richTextBox.Document.ContentEnd, richTextBox.Document.ContentEnd);
            tr.Text = Environment.NewLine + text;
            tr.ApplyPropertyValue(TextElement.ForegroundProperty, color);
        }
    }
}
