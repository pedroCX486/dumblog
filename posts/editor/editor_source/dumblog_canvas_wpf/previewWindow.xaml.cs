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
    /// Lógica interna para previewWindow.xaml
    /// </summary>
    public partial class previewWindow : Window
    {
        public previewWindow(string preview)
        {
            InitializeComponent();
            previewRenderer.NavigateToString("<!DOCTYPE html><html><head></head><body style=\"font-size: small; font-family: Arial, Helvetica, sans-serif;\">" + preview);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Close();
        }
    }
}
