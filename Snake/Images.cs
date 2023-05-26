using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snake
{
    public static class Images
    {
                                                                                                        // Static fields to hold the image sources
        public readonly static ImageSource Empty = LoadImage("Empty.png");                              // Image for empty grid cells
        public readonly static ImageSource Body = LoadImage("Body.png");                                // Image for snake body
        public readonly static ImageSource Head = LoadImage("Head.png");                                // Image for snake head
        public readonly static ImageSource Food = LoadImage("Food.png");                                // Image for food
        public readonly static ImageSource DeadBody = LoadImage("DeadBody.png");                        // Image for dead snake body
        public readonly static ImageSource DeadHead = LoadImage("DeadHead.png");                        // Image for dead snake head

                                                                                                
        private static ImageSource LoadImage(string fileName)                                       // Method to load an image from the assets folder
        {
            return new BitmapImage(new Uri($"assets/{fileName}", UriKind.Relative));
        }
    }
}
