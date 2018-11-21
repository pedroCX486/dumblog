using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace dumblog_canvas_wpf
{
    class saveFile
    {

        public saveFile(string filename, string title, string postContent, string timestamp)
        {
            postContent = postContent.Replace(Environment.NewLine, "<br>");

            postContent content = new postContent();
            content.title = title;
            content.content = postContent;
            content.timestamp = timestamp;

            bool archiveUpdated = updateArchive(filename);
            string saveLocation;

            if (archiveUpdated)
            {
                saveLocation = "../";
            }
            else
            {
                saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            File.WriteAllText(saveLocation + filename + ".post", JsonConvert.SerializeObject(content, Formatting.Indented));

            checks.setFileSaved(true);

            MessageBox.Show("File saved and archive updated.", "Message");
        }

        static bool updateArchive(string filename)
        {
            string archiveLocation = "../archive.lst";
            OpenFileDialog openDialog;
            archiveContent archive;
            List<String> filenames;

            if (!checks.getRunningWhereItShould())
            {
                if (MessageBox.Show("I couldn't find the archive file! Could you point me to it?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    openDialog = new OpenFileDialog();
                    openDialog.Filter = "Dumblog Archive Files (*.lst)|*.lst|All Files (*.*)|*.*";

                    archive = JsonConvert.DeserializeObject<archiveContent>(File.ReadAllText(archiveLocation));

                    filenames = new List<string>(archive.filenames);
                    filenames.Reverse();
                    filenames.Add(filename);
                    filenames.Reverse();

                    archive.filenames = filenames.ToArray();

                    File.WriteAllText("../archive.lst", JsonConvert.SerializeObject(archive, Formatting.Indented));

                    return true;
                }
                else
                {
                    MessageBox.Show("I'm sorry, but without the archive location I'll have to save your file on your desktop.", "Warning");

                    return false;
                }
                
            }

            openDialog = new OpenFileDialog();
            openDialog.Filter = "Dumblog Archive Files (*.lst)|*.lst|All Files (*.*)|*.*";

            archive = JsonConvert.DeserializeObject<archiveContent>(File.ReadAllText(archiveLocation));

            filenames = new List<string>(archive.filenames);
            filenames.Reverse();
            filenames.Add(filename);
            filenames.Reverse();

            archive.filenames = filenames.ToArray();

            File.WriteAllText("../archive.lst", JsonConvert.SerializeObject(archive, Formatting.Indented));

            return true;
        }
    }
}
