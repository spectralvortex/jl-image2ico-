using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace jl_image2ico
{
    public partial class Form1 : Form
    {

        string _imageFileName = String.Empty;
        

        public Form1()
        {
            InitializeComponent();
        }


        private void btnImage_inFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Loads the last visided and saved folder path if any, from the apps settings.
                openFileDialog.InitialDirectory = Properties.Settings.Default.filePath;

                // Build a string containing the text for the openFileDialog's file type filter, containing all applicable image file types.
                var codecs = ImageCodecInfo.GetImageEncoders();
                var codecFilter = "Image files|";
                foreach (var codec in codecs.Where((codec) => codec.FormatDescription != "GIF")) // skip the gif format 
                {
                    codecFilter += codec.FilenameExtension.ToLower() + ";";
                }

                // Sets the openFileDialog's file type filter.
                openFileDialog.Filter = codecFilter;
                
                openFileDialog.RestoreDirectory = true;

                // Opens the open file dialog.
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Store the filename (full path) to class parameter so that it can be used for the save icon method.
                    _imageFileName = openFileDialog.FileName;

                    // Store the filePath (without the file name) into Property.settings so that
                    // the last opened folder is remembered.
                    Properties.Settings.Default.filePath = Path.GetDirectoryName(_imageFileName);
                    Properties.Settings.Default.Save();

                    // Set the background color of the pictureboxes equal to the form's bacground color.
                    pb256.BackColor = pb48.BackColor = pb32.BackColor = pb16.BackColor = Color.FromKnownColor(KnownColor.Control);

                    // Get the image as read only so that the file will not be blocked.
                    Bitmap thePicture = ImagingHelper.GetBitmapFromFileReadOnly(_imageFileName);

                    // Display the image in picture boxes for the different sizes.
                    pb256.Image = ImagingHelper.ResizeImage(thePicture, 256, 256);
                    pb48.Image = ImagingHelper.ResizeImage(thePicture, 48, 48);
                    pb32.Image = ImagingHelper.ResizeImage(thePicture, 32, 32);
                    pb16.Image = ImagingHelper.ResizeImage(thePicture, 16, 16);

                    // Enable the save button.
                    btnICO_outFile.Enabled = true;
                    btnICO_outFile.Focus();

                }
            }
        }


        private void btnICO_outFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Properties.Settings.Default.filePath;
                saveFileDialog.Filter = "Ico files (*.ico)|*.ico";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Save the picture to an ico file";
                saveFileDialog.OverwritePrompt = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    if (saveFileDialog.FileName != "")
                    {                                    
                        // Create and save the icon.
                        ImagingHelper.ConvertToIcon(_imageFileName, saveFileDialog.FileName);
                    }
                }
            }
        }


       


    }
}
