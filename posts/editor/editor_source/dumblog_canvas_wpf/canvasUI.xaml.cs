using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dumblog_canvas_wpf
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        string currentFile;
        Stack<string> undoList = new Stack<string>();

        public MainWindow()
        {
            InitializeComponent();
            checks.startUpCheck();
            postTitle.Focus();
        }

        public void requestFocus()
        {
            postContent.Focus();
            
            if(postContent.SelectedText.Length == 0)
            {
                postContent.Select(postContent.Text.Length,0);

            }
        }

        public string generateFilename()
        {
            currentFile = Regex.Replace(postTitle.Text, "[^a-zA-Z0-9_]+", "-");

            currentFile = currentFile.ToLower();

            if (currentFile.EndsWith("-"))
            {
                currentFile = currentFile.Remove(currentFile.Length - 1);
            }

            return currentFile;
        }

        public string addImage(string imgLink)
        {
            addImageDialog imageInput = new addImageDialog(imgLink);
            imageInput.ShowDialog();

            if (imageInput.DialogResult == true)
            {
                imageInput.Close();

                if (imageInput.getImageURL().Equals(""))
                {
                    dialog("No image URL added.");
                }

                if (imageInput.getClickable())
                {
                    return "<a href=\""+ imageInput.getImageURL() + "\" target=\"_blank\"><img style=\"max-width: 70%; height: auto;\" src=\"" + imageInput.getImageURL() + "\"></img></a>";
                }
                else
                {
                    return "<img style=\"max-width: 70%; height: auto;\" src=\"" + imageInput.getImageURL() + "\"></img>";
                }
            }
            else
            {
                imageInput.Close();
                return null;
            }

        }

        public string addHyperlink(string addURL, string addText)
        {
            addHyperlinkDialog hyperlinkInput = new addHyperlinkDialog(addURL, addText);
            hyperlinkInput.ShowDialog();

            if (hyperlinkInput.DialogResult == true)
            {
                hyperlinkInput.Close();

                if (hyperlinkInput.getHyperlinkURL().Equals(""))
                {
                    dialog("No URL added.");
                }

                if (hyperlinkInput.getHyperlinkText().Equals(""))
                {
                    dialog("No text added.");
                }
                return "<a href=\"" + hyperlinkInput.getHyperlinkURL() + "\" target=\"_blank\">" + hyperlinkInput.getHyperlinkText() + "</a>";
            }
            else
            {
                hyperlinkInput.Close();
                return null;
            }

        }

        private void BoldButton_Click(object sender, EventArgs e)
        {

            if (postContent.SelectedText.Equals(""))
            {
                postContent.Text = postContent.Text.Insert(postContent.SelectionStart, "<b></b>");
            }
            else
            {
                postContent.SelectedText = "<b>" + postContent.SelectedText + "</b>";
            }
            requestFocus();
        }

        private void ItalicButton_Click(object sender, EventArgs e)
        {
            if (postContent.SelectedText.Equals(""))
            {
                postContent.Text = postContent.Text.Insert(postContent.SelectionStart, "<i></i>");
            }
            else
            {
                postContent.SelectedText = "<i>" + postContent.SelectedText + "</i>";
            }
            requestFocus();
        }

        private void StrikeButton_Click(object sender, EventArgs e)
        {
            if (postContent.SelectedText.Equals(""))
            {
                postContent.Text = postContent.Text.Insert(postContent.SelectionStart, "<del></del>");
            }
            else
            {
                postContent.SelectedText = "<del>" + postContent.SelectedText + "</del>";
            }
            requestFocus();
        }

        private void UnderlineButton_Click(object sender, EventArgs e)
        {
            if (postContent.SelectedText.Equals(""))
            {
                postContent.Text = postContent.Text.Insert(postContent.SelectionStart, "<ins></ins>");
            }
            else
            {
                postContent.SelectedText = "<ins>" + postContent.SelectedText + "</ins>";
            }
            requestFocus();
        }

        private void SuperscriptButton_Click(object sender, EventArgs e)
        {
            if (postContent.SelectedText.Equals(""))
            {
                postContent.Text = postContent.Text.Insert(postContent.SelectionStart, "<sup></sup>");
            }
            else
            {
                postContent.SelectedText = "<sup>" + postContent.SelectedText + "</sup>";
            }
            requestFocus();
        }

        private void HyperlinkButton_Click(object sender, EventArgs e)
        {
            string hyperlinkHTML;

            if (postContent.SelectedText.Contains("http") || postContent.SelectedText.Contains("www"))
            {
                hyperlinkHTML = addHyperlink(postContent.SelectedText, "");
            }
            else
            {
                hyperlinkHTML = addHyperlink("", postContent.SelectedText);
            }

            if (hyperlinkHTML != null && postContent.SelectedText.Equals(""))
            {
                postContent.Text = postContent.Text.Insert(postContent.SelectionStart, hyperlinkHTML);
            }
            else if (hyperlinkHTML != null && !postContent.SelectedText.Equals(""))
            {
                postContent.SelectedText = hyperlinkHTML;
            }

            requestFocus();
        }

        private void ImgButton_Click(object sender, EventArgs e)
        {
            string imgHTML = addImage(postContent.SelectedText);


            if (imgHTML != null && postContent.SelectedText.Equals(""))
            {
                postContent.Text = postContent.Text.Insert(postContent.SelectionStart, imgHTML);
            }
            else if (imgHTML != null && !postContent.SelectedText.Equals(""))
            {
                postContent.SelectedText = imgHTML;
            }

            requestFocus();
        }

        private void CenterButton_Click(object sender, EventArgs e)
        {
            if (postContent.SelectedText.Equals(""))
            {
                postContent.Text = postContent.Text.Insert(postContent.SelectionStart, "<center></center>");
            }
            else
            {
                postContent.SelectedText = "<center>" + postContent.SelectedText + "</center>";
            }
            requestFocus();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you clicked here you're probably confused... As you should." +
                    "\n\nAbout the editing buttons:\nThey add HTML tags to the text field. But you don't need to add <br> to break lines, because I already parse line breaks back in the code." +
                    "\n\nYes, confusing I know, but it's somewhat less overbearing to at least not type the <br> tags." +
                    "\n\nAlso CTRL+Z (Undo) and CTRL+Y (Redo) work, but be careful if you undo something, because since this app uses Microsoft's default implmementation, it means it can wipe an ENTIRE LINE at once. But you can redo to fix it at least." +
                    "\n\n\nDon't judge me. I just wanted an easy and dumb blogging platform for GitHub Pages.", "Need help?");
            requestFocus();
        }

        private void dialog(string content)
        {
            MessageBox.Show(content, "Message");

            requestFocus();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            loadFile lf = new loadFile();
            Tuple<string, string, string> result = lf.getDataFromFile();

            if (result != null)
            {
                postTitle.Text = result.Item1;
                postContent.Text = result.Item2;
                timestamp.Content = "Saved Timestamp: " + result.Item3;
            }

            requestFocus();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            currentFile = generateFilename();

            new saveFile(currentFile, postTitle.Text, postContent.Text, unixTimestamp.ToString());

            requestFocus();
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            int unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            currentFile = generateFilename();

            new saveFileAs(currentFile, postTitle.Text, postContent.Text, unixTimestamp.ToString());

            requestFocus();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            checks.exitCheck();
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            postContent.Undo();
            requestFocus();
        }

        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            postContent.Redo();
            requestFocus();
        }

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            string previewHTML = postContent.Text.Replace(Environment.NewLine, "<br>");

            if (!previewHTML.Equals(""))
            {
                previewWindow preview = new previewWindow(previewHTML);
                preview.ShowDialog();
            }
            else
            {
                dialog("Nothing to preview.");
            }

            requestFocus();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear everything?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                postTitle.Clear();
                postContent.Clear();
                timestamp.Content = "";
            }

            requestFocus();
        }
    }
}
