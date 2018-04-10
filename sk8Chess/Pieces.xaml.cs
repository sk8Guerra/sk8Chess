using System;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace sk8Chess
{
    public partial class Pieces : UserControl
    {

        public Pieces ()
        {
            InitializeComponent();
        }

        Image image = new Image();
        ImageBrush imageBrush = new ImageBrush();
        private PiecesEnumeration color;
        
        public PiecesEnumeration Fill
        {
            get
            {
                return color;
            }
            set 
            {
                color = value;
                UpdateColor(value);
            }
        } 

        public void UpdateColor(PiecesEnumeration color)
        {
            switch (color)
            {
                case PiecesEnumeration.BlackRook:
                    image.Source = new BitmapImage(new Uri((Directory.GetCurrentDirectory().ToString() + "/Resources/blackrook.png")));
                    imageBrush.ImageSource = image.Source;
                    Piezas.Background = imageBrush;
                    break;
                case PiecesEnumeration.BlackKnight:
                    image.Source = new BitmapImage(new Uri((Directory.GetCurrentDirectory().ToString() + "/Resources/blackknight.png")));
                    imageBrush.ImageSource = image.Source;
                    Piezas.Background = imageBrush;
                    break;
                case PiecesEnumeration.BlackBishop:
                    image.Source = new BitmapImage(new Uri((Directory.GetCurrentDirectory().ToString() + "/Resources/blackbishop.png")));
                    imageBrush.ImageSource = image.Source;
                    Piezas.Background = imageBrush;
                    break;
                case PiecesEnumeration.BlackKing:
                    image.Source = new BitmapImage(new Uri((Directory.GetCurrentDirectory().ToString() + "/Resources/blackking.png")));
                    imageBrush.ImageSource = image.Source;
                    Piezas.Background = imageBrush;
                    break;
                case PiecesEnumeration.BlackQueen:
                    image.Source = new BitmapImage(new Uri((Directory.GetCurrentDirectory().ToString() + "/Resources/blackqueen.png")));
                    imageBrush.ImageSource = image.Source;
                    Piezas.Background = imageBrush;
                    break;
                case PiecesEnumeration.BlackPawn:
                    image.Source = new BitmapImage(new Uri((Directory.GetCurrentDirectory().ToString() + "/Resources/blackpawn.png")));
                    imageBrush.ImageSource = image.Source;
                    Piezas.Background = imageBrush;
                    break;

                ///////////

                case PiecesEnumeration.WhiteRook:
                    image.Source = new BitmapImage(new Uri((Directory.GetCurrentDirectory().ToString() + "/Resources/whiterook.png")));
                    imageBrush.ImageSource = image.Source;
                    Piezas.Background = imageBrush;
                    break;
                case PiecesEnumeration.WhiteKnight:
                    image.Source = new BitmapImage(new Uri((Directory.GetCurrentDirectory().ToString() + "/Resources/whiteknight.png")));
                    imageBrush.ImageSource = image.Source;
                    Piezas.Background = imageBrush;
                    break;
                case PiecesEnumeration.WhiteBishop:
                    image.Source = new BitmapImage(new Uri((Directory.GetCurrentDirectory().ToString() + "/Resources/whitebishop.png")));
                    imageBrush.ImageSource = image.Source;
                    Piezas.Background = imageBrush;
                    break;
                case PiecesEnumeration.WhiteKing:
                    image.Source = new BitmapImage(new Uri((Directory.GetCurrentDirectory().ToString() + "/Resources/whiteking.png")));
                    imageBrush.ImageSource = image.Source;
                    Piezas.Background = imageBrush;
                    break;
                case PiecesEnumeration.WhiteQueen:
                    image.Source = new BitmapImage(new Uri((Directory.GetCurrentDirectory().ToString() + "/Resources/whitequeen.png")));
                    imageBrush.ImageSource = image.Source;
                    Piezas.Background = imageBrush;
                    break;
                case PiecesEnumeration.WhitePawn:
                    image.Source = new BitmapImage(new Uri((Directory.GetCurrentDirectory().ToString() + "/Resources/whitepawn.png")));
                    imageBrush.ImageSource = image.Source;
                    Piezas.Background = imageBrush;
                    break;
            }
        }

    }
}
