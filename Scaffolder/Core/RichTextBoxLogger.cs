namespace VSPackage.ScaffolderPackage.Core
{
    using System;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;

    /// <summary>
    /// Logger that appends messages to provided RichTextBox control.
    /// Uses BackgroundWorker to signal the change so that UI control
    /// is updated on a main thread
    /// </summary>
    public class RichTextBoxLogger : ILogger
    {
        private RichTextBox richTextBox;
        private BackgroundWorker backgroundWorker;

        public RichTextBoxLogger(
            RichTextBox richTextBox,
            BackgroundWorker backgroundWorker)
        {
            this.richTextBox = richTextBox;
            this.backgroundWorker = backgroundWorker;
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
            // Report progress by sending an action that will be invoked
            // on a main thread and append text to a rich text box
            backgroundWorker.ReportProgress(0, new Action(() => {
                TextRange tr = new TextRange(richTextBox.Document.ContentEnd, richTextBox.Document.ContentEnd);
                tr.Text = Environment.NewLine + text;
                tr.ApplyPropertyValue(TextElement.ForegroundProperty, color);
            }));
        }
    }
}
