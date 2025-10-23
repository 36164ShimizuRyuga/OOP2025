using SQLite;
using System.IO;
using System.Windows.Media.Imaging;

namespace CustomerApp.Data {
    public class Customer {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public byte[] Picture { get; set; }

        public BitmapImage PictureSource {
            get {
                if (Picture == null || Picture.Length == 0) return null;
                using (var stream = new MemoryStream(Picture)) {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = stream;
                    image.EndInit();
                    return image;
                }
            }
        }
    }
}