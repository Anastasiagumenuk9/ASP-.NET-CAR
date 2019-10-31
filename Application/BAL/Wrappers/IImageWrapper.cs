using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace BAL.Wrappers
{
    public interface IImageWrapper
    {
        bool Exists(string path);

        bool FileExists(string path);

        void FileDelete(string path);

        void CreateDirectory(string path);

        void SaveBitmap(Bitmap bitmap, string path, ImageFormat imageFormat);
    }
}
