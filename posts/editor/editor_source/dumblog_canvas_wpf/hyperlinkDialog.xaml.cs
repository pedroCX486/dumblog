using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dumblog_canvas_wpf
{
    /// <summary>
    /// Lógica interna para hyperlinkDialog.xaml
    /// </summary>
    public partial class addHyperlinkDialog : Window
    {
        public addHyperlinkDialog(string url, string text)
        {
            InitializeComponent();
            this.KeyDown += addHyperlinkDialog_KeyDown;

            hyperlinkURL.Focus();

            if (!url.Equals(""))
            {
                this.hyperlinkURL.Text = url;
            }

            if (!text.Equals(""))
            {
                this.hyperlinkText.Text = text;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public string getHyperlinkURL()
        {
            return this.hyperlinkURL.Text;
        }

        public string getHyperlinkText()
        {
            return this.hyperlinkText.Text;
        }

        private void addHyperlinkDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
