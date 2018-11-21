using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dumblog_canvas_wpf
{
    class loadFile
    {

        public Tuple<string, string, string> getDataFromFile()
        {
            string filename;
            postContent post;
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Dumblog Post Files (*.post)|*.post|All Files (*.*)|*.*";

            if (openDialog.ShowDialog() == false)
            {
                return null;
            }
            else
            {
                filename = openDialog.FileName;
                post = JsonConvert.DeserializeObject<postContent>(File.ReadAllText(filename));

                post.content = post.content.Replace("<br>", Environment.NewLine);

            }

            return new Tuple<string, string, string>(post.title, post.content, post.timestamp);
        }
    }
}
