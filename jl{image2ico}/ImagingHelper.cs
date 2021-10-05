using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;


namespace jl_image2ico
{

    /// <summary>
    /// Adapted from this gist: https://gist.github.com/darkfall/1656050
    /// Provides helper methods for imaging
    /// </summary>
    public static class ImagingHelper
    {
        /// <summary>
        /// Converts a PNG image to a icon (ico) with all the sizes windows likes
        /// </summary>
        /// <param name="inputBitmap">The input bitmap</param>
        /// <param name="output">The output stream</param>
        /// <returns>Wether or not the icon was succesfully generated</returns>
        public static bool ConvertToIcon(Bitmap inputBitmap, Stream output)
        {
            if (inputBitmap == null)
                return false;

            int[] sizes = new int[] { 256, 48, 32, 16 };

            // Generate bitmaps for all the sizes and toss them in streams
            List<MemoryStream> imageStreams = new List<MemoryStream>();
            foreach (int size in sizes)
            {
                Bitmap newBitmap = ResizeImage(inputBitmap, size, size);
                if (newBitmap == null)
                    return false;
                MemoryStream memoryStream = new MemoryStream();
                
                // The rezised bitmap is saved in to a memorystream as png-format (!).
                newBitmap.Save(memoryStream, ImageFormat.Png);
                
                imageStreams.Add(memoryStream);
            }

            if (output == null)
                return false;
            //TODO: --> Should probably throw some exeptions here.

            // Clears all data from existing output file => overwrite existing data, if any, in the file.
            output.SetLength(0);

            BinaryWriter iconWriter = new BinaryWriter(output);

            if (iconWriter == null)
                return false;
            //TODO: --> Should probably throw some exeptions here.

            int offset = 0;

            // 0-1 reserved, 0
            iconWriter.Write((byte)0);
            iconWriter.Write((byte)0);

            // 2-3 image type, 1 = icon, 2 = cursor
            iconWriter.Write((short)1);

            // 4-5 number of images
            iconWriter.Write((short)sizes.Length);

            offset += 6 + (16 * sizes.Length);

            for (int i = 0; i < sizes.Length; i++)
            {
                // image entry i

                // 0 image width
                iconWriter.Write((byte)sizes[i]);
                // 1 image height
                iconWriter.Write((byte)sizes[i]);

                // 2 number of colors
                iconWriter.Write((byte)0);

                // 3 reserved
                iconWriter.Write((byte)0);

                // 4-5 color planes
                iconWriter.Write((short)0);

                // 6-7 bits per pixel
                iconWriter.Write((short)32);

                // 8-11 size of image data
                iconWriter.Write((int)imageStreams[i].Length);

                // 12-15 offset of image data
                iconWriter.Write((int)offset);

                offset += (int)imageStreams[i].Length;
            }

            for (int i = 0; i < sizes.Length; i++)
            {
                // Write image data.
                // Png data must contain the whole png data file.
                iconWriter.Write(imageStreams[i].ToArray());
                imageStreams[i].Close();
            }

            iconWriter.Flush();

            return true;
        }


        /// <summary>
        /// Converts a PNG image to a icon (ico)
        /// </summary>
        /// <param name="input">The input stream</param>
        /// <param name="output">The output stream</param
        /// <returns>Wether or not the icon was succesfully generated</returns>
        public static bool ConvertToIcon(Stream input, Stream output)
        {
            Bitmap inputBitmap = (Bitmap)Bitmap.FromStream(input);
            return ConvertToIcon(inputBitmap, output);
        }


        /// <summary>
        /// Converts a PNG image to a icon (ico)
        /// </summary>
        /// <param name="inputPath">The input path</param>
        /// <param name="outputPath">The output path</param>
        /// <returns>Wether or not the icon was succesfully generated</returns>
        public static bool ConvertToIcon(string inputPath, string outputPath)
        {
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open))
            using (FileStream outputStream = File.Create(outputPath)) // File.Create will create or overwrite a file and return the filestream for it.
            {
                return ConvertToIcon(inputStream, outputStream);
            }
        }


        /// <summary>
        /// Converts an image to a icon (ico)
        /// </summary>
        /// <param name="inputImage">The input image</param>
        /// <param name="outputPath">The output path</param>
        /// <returns>Wether or not the icon was succesfully generated</returns>
        public static bool ConvertToIcon(Image inputImage, string outputPath)
        {
            using (FileStream outputStream = File.Create(outputPath)) // File.Create will create or overwrite a file and return the filestream for it.
            {
                return ConvertToIcon(new Bitmap(inputImage), outputStream);
            }
        }


        /// <summary>
        /// Resize the image to the specified width and height.
        /// Found on stackoverflow: https://stackoverflow.com/questions/1922040/resize-an-image-c-sharp
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        /// <summary>
        /// Open a image file as read only and load it into a Bitmap object
        /// </summary>
        /// <param name="fileName">The full path and name to the image file.</param>
        /// <returns>A new Bitmap object with the copy of the image data from an image file.</returns>
        public static Bitmap GetBitmapFromFileReadOnly(string fileName)
        {
            // Open file in read only mode.
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))

            // Get a binary reader for the file stream.
            using (BinaryReader reader = new BinaryReader(stream))
            {
                // Copy the content of the file into a memory stream.
                var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));

                // Make a new Bitmap object the owner of the MemoryStream.
                return new Bitmap(memoryStream);
            }
        }


        /// <summary>
        /// Finds the image codec info for an image.
        /// </summary>
        /// <param name="img">The image to find the image codec info for.</param>
        /// <returns>The image codec info for the image.</returns>
        public static ImageCodecInfo GetCodecInfo(Image img)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
                if (img.RawFormat.Guid == codec.FormatID)
                    return codec;
            return null;
        }
    }
}
