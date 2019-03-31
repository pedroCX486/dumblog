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

        public saveFile(string filename, string title, string postContent, string timestamp, string editedTimestamp)
        {
            postContent = postContent.Replace(Environment.NewLine, "<br>");

            postContent content = new postContent();
            content.title = title;
            content.content = postContent;
            content.editedTimestamp = editedTimestamp;
            content.timestamp = timestamp;

            bool archiveUpdated = updateArchiveFile(filename, title);
            string saveLocation;

            if (archiveUpdated && checks.getRunningWhereItShould())
            {
                saveLocation = "../";
            }
            else
            {
                MessageBox.Show("Saving on your desktop. Editor is not running in your Dumblog Install folder.", "Message");
                saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            if(filename == null || filename.Equals(""))
            {
                filename = "untitled";
            }

            File.WriteAllText(saveLocation + "\\"  + filename + ".post", JsonConvert.SerializeObject(content, Formatting.Indented));

            checks.setFileSaved(true);

            MessageBox.Show("File saved and archive updated.", "Message");
        }

        static bool updateArchiveFile(string filename, string postTitle)
        {
            string archiveLocation = "../archive.lst";
            OpenFileDialog openDialog;

            if (!checks.getRunningWhereItShould())
            {
                if (MessageBox.Show("Can't find the archive file! Can you point me to it?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    openDialog = new OpenFileDialog();
                    openDialog.Filter = "Dumblog Archive Files (*.lst)|*.lst|All Files (*.*)|*.*";
                    openDialog.ShowDialog();

                    updateArchiveObject(new archiveContent(), filename, postTitle, openDialog.FileName);                 

                    return true;
                }
                else
                {
                    return false;
                }
                
            }

            updateArchiveObject(new archiveContent(), filename, postTitle, archiveLocation);

            return true;
        }

        static void updateArchiveObject (archiveContent archive, string filename, string postTitle, string archiveLocation)
        {

            archive = JsonConvert.DeserializeObject<archiveContent>(File.ReadAllText(archiveLocation));

            List<string> filenames;
            List<string> postTitles;

            filenames = new List<string>(archive.filenames);
            filenames.Reverse();
            filenames.Add(filename);
            filenames.Reverse();
            archive.filenames = filenames.ToArray();

            postTitles = new List<string>(archive.postTitles);
            postTitles.Reverse();
            postTitles.Add(postTitle);
            postTitles.Reverse();
            archive.postTitles = postTitles.ToArray();

            File.WriteAllText(archiveLocation, JsonConvert.SerializeObject(archive, Formatting.Indented));

            return;
        }

    }
}
