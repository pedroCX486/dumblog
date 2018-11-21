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
    /// Lógica interna para imageDialog.xaml
    /// </summary>
    public partial class addImageDialog : Window
    {
        public addImageDialog(string imgLink)
        {
            InitializeComponent();
            imageURL.Focus();

            this.KeyDown += addImageDialog_KeyDown;

            if (imgLink != null && !imgLink.Equals(""))
            {
                this.imageURL.Text = imgLink;
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

        public string getImageURL()
        {
            return this.imageURL.Text;
        }

        private void addImageDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
