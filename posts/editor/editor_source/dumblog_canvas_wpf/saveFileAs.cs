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
    class saveFileAs
    {

        public saveFileAs(string filename, string title, string postContent, string timestamp, string editedTimestamp)
        {
            postContent = postContent.Replace(Environment.NewLine, "<br>");

            postContent content = new postContent();
            content.title = title;
            content.content = postContent;
            content.editedTimestamp = editedTimestamp;
            content.timestamp = timestamp;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (filename == null || filename.Equals(""))
            {
                filename = "untitled";
            }
            saveFileDialog.FileName = filename;
            saveFileDialog.Filter = "Dumblog Post Files (*.post)|*.post|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == false)
            {
                return;
            }
            else
            {
                File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(content, Formatting.Indented));

                checks.setFileSaved(true);

                MessageBox.Show("File saved.", "Message");
            }

        }
    }
}
