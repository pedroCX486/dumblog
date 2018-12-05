using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class ArchiveManager : Window
    {

        archiveContent archive;
        string archiveLocation = "../archive.lst";
        List<String> filenames;

        public ArchiveManager()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                archive = JsonConvert.DeserializeObject<archiveContent>(File.ReadAllText(archiveLocation));
                filenames = new List<string>(archive.filenames);
                listBox.ItemsSource = filenames;
            } catch (FileNotFoundException)
            {
                MessageBox.Show("Archive file not found. Are you running the editor on the 'editor' folder?", "Message");
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            filenames.RemoveAt(this.listBox.SelectedIndex);
            listBox.ItemsSource = null;
            listBox.ItemsSource = filenames;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            saveArchiveFile(archive, filenames);
        }

        private void RemoveAndDeletebutton_Click(object sender, RoutedEventArgs e)
        {
            if(filenames != null)
            {
                if (File.Exists("../" + filenames[this.listBox.SelectedIndex] + ".post"))
                {
                    File.Delete("../" + filenames[this.listBox.SelectedIndex] + ".post");
                    filenames.RemoveAt(this.listBox.SelectedIndex);
                    listBox.ItemsSource = null;
                    listBox.ItemsSource = filenames;
                }
                else
                {
                    MessageBox.Show("Couldn't remove or find the specified file. Is there a permission problem or is the file on the 'posts' directory?", "Message");
                }

                saveArchiveFile(archive, filenames);
            }
            else
            {
                MessageBox.Show("No entries selected.", "Message");
            }
        }

        static bool saveArchiveFile(archiveContent archive, List<String> filenames)
        {
            try
            {
                archive.filenames = filenames.ToArray();
                File.WriteAllText("../archive.lst", JsonConvert.SerializeObject(archive, Formatting.Indented));
                MessageBox.Show("Archive file updated!", "Message");
                return true;
            }
            catch (IOException)
            {
                MessageBox.Show("Couldn't update file. Is there a permission problem or is the file on the 'posts' directory?", "Message");
                return false;
            }
        }
    }
}
