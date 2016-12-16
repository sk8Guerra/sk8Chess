using System;
using System.Windows;
using System.Media;
using System.IO;

namespace sk8Chess
{
    public partial class sk8ChessPlayer : Window
    {
        SoundPlayer player = new SoundPlayer();

        public sk8ChessPlayer()
        {
            InitializeComponent();
        }

        private void PlayMusic(object sender, RoutedEventArgs e)
        {
            //C:/Users/Monitor41P1/Downloads/13_Let_Me_Love_You_feat.wav
            //C:/Users/Monitor41P1/Downloads/01_All_Day.wav

            string routeSong;
            routeSong = RouteMusic.Text;

            if (!routeSong.Equals(""))
            {
                try
                {
                    player.SoundLocation = routeSong;

                    try
                    {
                        player.Play();
                        WindowState = WindowState.Minimized;
                    }
                    catch (FileNotFoundException )
                    {
                        MessageBox.Show("Your file have not been found, make sure that your route is correct");
                    }
                }
                catch (ArgumentException )
                {
                    MessageBox.Show("You have not entered a valid route");
                }
            }
        }

        private void ClosePlayer(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
