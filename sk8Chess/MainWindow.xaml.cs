using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Media;
using MaterialDesignThemes.Wpf;
using System.IO;

namespace sk8Chess
{
    public partial class MainWindow : Window
    {
        //Have to divide this mega class into lil clases
        DispatcherTimer timer = new DispatcherTimer();
        int seconds, minutes, hours;
        
        object[,] matriz;
      
        private bool turn = true;
        private bool turnColor = true;

        SoundPlayer player = new SoundPlayer();

        SolidColorBrush greenTurn = new SolidColorBrush(Color.FromArgb(200, 23, 171, 227)); //blue
        SolidColorBrush redTurn = new SolidColorBrush(Color.FromArgb(200, 255, 89, 84)); //red

        private object objeto;
        private int newX;
        private int newY;
        private bool alternador = true;
        
        private int mouseX;
        private int mouseY;
        
        public MainWindow()
        {
            /*
            var myMessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(5));
            Notification.MessageQueue = myMessageQueue;
            */

            matriz = new object[8, 8];
            InitializeComponent();
            paintingBoardRedAndBlue();
            placingPieces();

            StopTime.Visibility = Visibility.Hidden;
            StartTime.IsEnabled = false;
            RestartTime.IsEnabled = false;

            Time.Text = "time:";

            Position.Text = "position:";
            Positions.Text = "-,-";

            WhiteTurnn.Text = "white turn:";
            BlackTurnn.Text = "black turn:";

            WhiteTurn.Fill = greenTurn;
            BlackTurn.Fill = redTurn;

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(Intervalos);
        }

        public void Intervalos(object sender, EventArgs e)
        {
            #region Time controller
            seconds += 1;

            if (seconds == 60)
            {
                minutes += 1;
                seconds = 0;
            }
            if (minutes == 60)
            {
                minutes = 0;
                hours += 1;
            }
            if (hours == 12)
            {
                hours = 0;
                minutes = 0;
                seconds = 0;
            }

            Timer.Text = (String.Format(hours.ToString("00")) + ":" + String.Format(minutes.ToString("00")) +
                ":" + String.Format(seconds.ToString("00")));
            #endregion
        }

        private void Tablero_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = (int)(e.GetPosition(Tablero).X / 73.75);
            mouseY = (int)(e.GetPosition(Tablero).Y / 68.875);
            
            if ((turn == true) && (turnColor == true))
            {
                #region True
                BlackTurn.Fill = redTurn;
                WhiteTurn.Fill = greenTurn;

                switch (mouseX)
                {
                    case 0:
                        Positions.Text = "-" + "A" + "," + mouseY + "-";
                        break;
                    case 1:
                        Positions.Text = "-" + "B" + "," + mouseY + "-";
                        break;
                    case 2:
                        Positions.Text = "-" + "C" + "," + mouseY + "-";
                        break;
                    case 3:
                        Positions.Text = "-" + "D" + "," + mouseY + "-";
                        break;
                    case 4:
                        Positions.Text = "-" + "E" + "," + mouseY + "-";
                        break;
                    case 5:
                        Positions.Text = "-" + "F" + "," + mouseY + "-";
                        break;
                    case 6:
                        Positions.Text = "-" + "G" + "," + mouseY + "-";
                        break;
                    case 7:
                        Positions.Text = "-" + "H" + "," + mouseY + "-";
                        break;
                }
                #endregion
            }
            else if ((turn == false) && (turnColor == false))
            {
                #region False
                WhiteTurn.Fill = redTurn;
                BlackTurn.Fill = greenTurn;

                switch (mouseX)
                {
                    case 0:
                        Positions.Text = "-" + "A" + "," + mouseY + "-";
                        break;
                    case 1:
                        Positions.Text = "-" + "B" + "," + mouseY + "-";
                        break;
                    case 2:
                        Positions.Text = "-" + "C" + "," + mouseY + "-";
                        break;
                    case 3:
                        Positions.Text = "-" + "D" + "," + mouseY + "-";
                        break;
                    case 4:
                        Positions.Text = "-" + "E" + "," + mouseY + "-";
                        break;
                    case 5:
                        Positions.Text = "-" + "F" + "," + mouseY + "-";
                        break;
                    case 6:
                        Positions.Text = "-" + "G" + "," + mouseY + "-";
                        break;
                    case 7:
                        Positions.Text = "-" + "H" + "," + mouseY + "-";
                        break;
                }
                #endregion
            }
        }

        private void Tablero_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (alternador == true)
            {
                #region White turn
                if (objeto == null)
                {
                    objeto = matriz[mouseX, mouseY];
                    newX = mouseX;
                    newY = mouseY;
                }
                else if(objeto != null)
                {
                    timer.Start();

                    StartTime.Visibility = Visibility.Hidden;
                    StopTime.Visibility = Visibility.Visible;
                    RestartTime.IsEnabled = true;
                    
                    if (((sk8Chess.Pieces)objeto).Fill == PiecesEnumeration.WhiteRook)
                    {
                        whiteRook();
                    }
                    else if (((sk8Chess.Pieces)objeto).Fill == PiecesEnumeration.WhiteKnight)
                    {
                        whiteKnight();
                    }
                    else if (((sk8Chess.Pieces)objeto).Fill == PiecesEnumeration.WhiteBishop)
                    {
                        whiteBishop();
                    }
                    else if (((sk8Chess.Pieces)objeto).Fill == PiecesEnumeration.WhiteKing)
                    {
                        whiteKing();
                    }
                    else if (((sk8Chess.Pieces)objeto).Fill == PiecesEnumeration.WhiteQueen)
                    {
                        whiteQueen();
                    }
                    else if (((sk8Chess.Pieces)objeto).Fill == PiecesEnumeration.WhitePawn)
                    {
                        whitePawn();
                    }
                    else
                    {
                        Notification.MessageQueue.Enqueue("It is not your turn", "ACCEPT", () => AcceptNotification());
                        objeto = null;
                    }
                }
                #endregion
            }
            else if (alternador == false)
            {
                #region Black turn
                if (objeto == null)
                {
                    objeto = matriz[mouseX, mouseY];
                    newX = mouseX;
                    newY = mouseY;
                }
                else if (objeto != null)
                {
                    if (((sk8Chess.Pieces)objeto).Fill == PiecesEnumeration.BlackRook)
                    {
                        blackRook();
                    }
                    else if (((sk8Chess.Pieces)objeto).Fill == PiecesEnumeration.BlackKnight)
                    {
                        blackKnight();
                    }
                    else if (((sk8Chess.Pieces)objeto).Fill == PiecesEnumeration.BlackBishop)
                    {
                        blackBishop();
                    }
                    else if (((sk8Chess.Pieces)objeto).Fill == PiecesEnumeration.BlackKing)
                    {
                        blackKing();
                    }
                    else if (((sk8Chess.Pieces)objeto).Fill == PiecesEnumeration.BlackQueen)
                    {
                        blackQueen();
                    }
                    else if (((sk8Chess.Pieces)objeto).Fill == PiecesEnumeration.BlackPawn)
                    {
                        blackPawn();
                    }
                    else
                    {
                        Notification.MessageQueue.Enqueue("It is not your turn", "ACCEPT", () => AcceptNotification());
                        objeto = null;
                    }
                }
                #endregion
            }
        }

        public void whiteRook()
        {
            if (mouseX == newX)
            {
                #region Movement in X
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = false;
                    turnColor = false;
                    alternador = false;
                }
                else
                {
                    whiteEating();
                }
                #endregion
            }
            else if (mouseY == newY)
            {
                #region Movement in Y
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = false;
                    turnColor = false;
                    alternador = false;
                }
                else
                {
                    whiteEating();
                }
                #endregion
            }
            else
            {
                #region Wrong movement
                Notification.MessageQueue.Enqueue("You can only move doing a +", "ACCEPT", () => AcceptNotification());
                objeto = null;
                #endregion
            }
        }

        public void blackRook()
        {
            if (mouseX == newX)
            {
                #region Movement in X
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = true;
                    turnColor = true;
                    alternador = true;
                }
                else
                {
                    blackEating();
                }
                #endregion
            }
            else if (mouseY == newY)
            {
                #region Movement in Y
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = true;
                    turnColor = true;
                    alternador = true;
                }
                else
                {
                    blackEating();
                }
                #endregion
            }
            else
            {
                #region Wrong movement
                Notification.MessageQueue.Enqueue("You can only move doing a +", "ACCEPT", () => AcceptNotification());
                objeto = null;
                #endregion
            }
        }

        public void whiteKnight()
        {
            if (((mouseY == newY - 1) && ((mouseX == newX - 2) || (mouseX == newX + 2))) ||
                ((mouseY == newY + 1) && ((mouseX == newX - 2) || (mouseX == newX + 2))) ||
                ((mouseY == newY - 2) && ((mouseX == newX - 1) || (mouseX == newX + 1))) ||
                ((mouseY == newY + 2) && ((mouseX == newX - 1) || (mouseX == newX + 1))))
            {
                #region Starting && eating
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = false;
                    turnColor = false;
                    alternador = false;
                }
                else
                {
                    whiteEating();
                }
                #endregion
            }
            else
            {
                #region Wrong movement
                Notification.MessageQueue.Enqueue("You can only make movements doing an L", "ACCEPT", () => AcceptNotification());
                objeto = null;
                #endregion
            }
        }

        public void blackKnight()
        {
            if (((mouseY == newY - 1) && ((mouseX == newX - 2) || (mouseX == newX + 2))) ||
                ((mouseY == newY + 1) && ((mouseX == newX - 2) || (mouseX == newX + 2))) ||
                ((mouseY == newY - 2) && ((mouseX == newX - 1) || (mouseX == newX + 1))) ||
                ((mouseY == newY + 2) && ((mouseX == newX - 1) || (mouseX == newX + 1))))
            {
                #region Starting && eating
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = true;
                    turnColor = true;
                    alternador = true;
                }
                else
                {
                    blackEating();
                }
                #endregion
            }
            else
            {
                #region Wrong movement
                Notification.MessageQueue.Enqueue("You can only make movements doing an L", "ACCEPT", () => AcceptNotification());
                objeto = null;
                #endregion
            }
        }

        public void whiteBishop()
        {
            if ((((mouseY == newY - 1) || (mouseY == newY - 2) || (mouseY == newY - 3) || (mouseY == newY - 4) || (mouseY == newY - 5) || (mouseY == newY - 6) ||
                (mouseY == newY - 7)) || ((mouseY == newY + 1) || (mouseY == newY + 2) || (mouseY == newY + 3) || (mouseY == newY + 4) || (mouseY == newY + 5) ||
                (mouseY == newY + 6) || (mouseY == newY + 7))) &&
                (((mouseX == newX - 1) || (mouseX == newX - 2) || (mouseX == newX - 3) || (mouseX == newX - 4) || (mouseX == newX - 5) || (mouseX == newX - 6) ||
                (mouseX == newX - 7)) || ((mouseX == newX + 1) || (mouseX == newX + 2) || (mouseX == newX + 3) || (mouseX == newX + 4) || (mouseX == newX + 5) ||
                (mouseX == newX + 6) || (mouseX == newX + 7))))
            {
                #region Starting and eating
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = false;
                    turnColor = false;
                    alternador = false;
                }
                else
                {
                    whiteEating();
                }
                #endregion
            }
            else
            {
                #region Wrong movement
                Notification.MessageQueue.Enqueue("You can only move doing an X", "ACCEPT", () => AcceptNotification());
                objeto = null;
                #endregion
            }
        }

        public void blackBishop()
        {
            if ((((mouseY == newY - 1) || (mouseY == newY - 2) || (mouseY == newY - 3) || (mouseY == newY - 4) || (mouseY == newY - 5) || (mouseY == newY - 6) ||
                (mouseY == newY - 7)) || ((mouseY == newY + 1) || (mouseY == newY + 2) || (mouseY == newY + 3) || (mouseY == newY + 4) || (mouseY == newY + 5) ||
                (mouseY == newY + 6) || (mouseY == newY + 7))) &&
                (((mouseX == newX - 1) || (mouseX == newX - 2) || (mouseX == newX - 3) || (mouseX == newX - 4) || (mouseX == newX - 5) || (mouseX == newX - 6) ||
                (mouseX == newX - 7)) || ((mouseX == newX + 1) || (mouseX == newX + 2) || (mouseX == newX + 3) || (mouseX == newX + 4) || (mouseX == newX + 5) ||
                (mouseX == newX + 6) || (mouseX == newX + 7))))
            {
                #region Starting and eating
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = true;
                    turnColor = true;
                    alternador = true;
                }
                else
                {
                    blackEating();
                }
                #endregion
            }
            else
            {
                #region Wrong movement
                Notification.MessageQueue.Enqueue("You can only move doing an X", "ACCEPT", () => AcceptNotification());
                objeto = null;
                #endregion
            }
        }

        public void whiteKing()
        {
            if (((mouseY == newY - 1) && ((mouseX == newX - 1) || (mouseX == newX + 1))) ||
                ((mouseY == newY) && ((mouseX == newX - 1) || (mouseX == newX + 1))) ||
                ((mouseY == newY - 1) && (mouseX == newX)) ||
                ((mouseY == newY + 1) && ((mouseX == newX - 1) || (mouseX == newX + 1))) ||
                ((mouseY == newY + 1) && (mouseX == newX)))
            {
                #region Starting and eating
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = false;
                    turnColor = false;
                    alternador = false;
                }
                else
                {
                    whiteEating();
                }
                #endregion
            }
            else
            {
                #region Wrong movement
                Notification.MessageQueue.Enqueue("You can only make movements around you", "ACCEPT", () => AcceptNotification());
                objeto = null;
                #endregion
            }
        }

        public void blackKing()
        {
            if (((mouseY == newY - 1) && ((mouseX == newX - 1) || (mouseX == newX + 1))) ||
                ((mouseY == newY) && ((mouseX == newX - 1) || (mouseX == newX + 1))) ||
                ((mouseY == newY - 1) && (mouseX == newX)) ||
                ((mouseY == newY + 1) && ((mouseX == newX - 1) || (mouseX == newX + 1))) ||
                ((mouseY == newY + 1) && (mouseX == newX)))
            {
                #region Starting and eating
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = true;
                    turnColor = true;
                    alternador = true;
                }
                else
                {
                    blackEating();
                }
                #endregion
            }
            else
            {
                #region Wrong movement
                Notification.MessageQueue.Enqueue("You can only make movements around you", "ACCEPT", () => AcceptNotification());
                objeto = null;
                #endregion
            }
        }

        public void whiteQueen()
        {
            if ((newY == 7) && (newX == 3))
            {
                #region Starting and eating
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = false;
                    turnColor = false;
                    alternador = false;
                }
                else
                {
                    whiteEating();
                }
                #endregion
            }
            else if (((newY != 7) || (newY == 7)) && ((newX != 3) || (newX == 3)))

            {
                #region After starting and eating
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = false;
                    turnColor = false;
                    alternador = false;
                }
                else
                {
                    whiteEating();
                }
                #endregion
            }
        }

        public void blackQueen()
        {
            if ((newY == 0) && (newX == 3))
            {
                #region Starting and eating
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = true;
                    turnColor = true;
                    alternador = true;
                }
                else
                {
                    whiteEating();
                }
                #endregion
            }
            else if (((newY != 0) || (newY == 0)) && ((newX != 3) || (newX == 3)))
            {
                #region After starting and eating
                if (matriz[mouseX, mouseY] == null)
                {
                    Moving();
                    turn = true;
                    turnColor = true;
                    alternador = true;
                }
                else
                {
                    blackEating();
                }
                #endregion
            }
        }

        public void whitePawn()
        {
            if (newY == 6)
            {
                #region Starting
                if ((mouseY == newY - 1) && (mouseX == newX))
                {
                    #region First movement
                    if (matriz[mouseX, mouseY] == null)
                    {
                        Moving();
                        turn = false;
                        turnColor = false;
                        alternador = false;
                    }
                    else
                    {
                        Notification.MessageQueue.Enqueue("It is ocuped", "ACCEPT", () => AcceptNotification());
                        objeto = null;
                    }
                    #endregion
                }
                else if ((mouseY == newY - 2) && (mouseX == newX))
                {
                    #region Second movement
                    if (matriz[mouseX, mouseY] == null)
                    {
                        Moving();
                        turn = false;
                        turnColor = false;
                        alternador = false;
                    }
                    else
                    {
                        Notification.MessageQueue.Enqueue("It is ocuped", "ACCEPT", () => AcceptNotification());
                        objeto = null;
                    }
                    #endregion
                }
                else if ((mouseY == newY - 1) && ((mouseX == newX - 1) || (mouseX == newX + 1)))
                {
                    #region Eating movement
                    if (matriz[mouseX, mouseY] != null)
                    {
                        whiteEating();
                    }
                    else
                    {
                        Notification.MessageQueue.Enqueue("It is empty", "ACCEPT", () => AcceptNotification());
                        objeto = null;
                    }
                    #endregion
                }
                else
                {
                    #region Wrong movement
                    Notification.MessageQueue.Enqueue("You can only move one or two positions in front of you", "ACCEPT", () => AcceptNotification());
                    objeto = null;
                    #endregion
                }
                #endregion
            }
            else if (newY != 6)
            {
                #region After starting
                if ((mouseY == newY - 1) && (mouseX == newX))
                {
                    #region First movement
                    if (matriz[mouseX, mouseY] == null)
                    {
                        Moving();
                        turn = false;
                        turnColor = false;
                        alternador = false;
                    }
                    else
                    {
                        Notification.MessageQueue.Enqueue("It is ocuped", "ACCEPT", () => AcceptNotification());
                        objeto = null;
                    }
                    #endregion
                }
                else if((mouseY == newY - 1) && ((mouseX == newX - 1) || (mouseX == newX + 1)))
                {
                    #region Eating movement
                    if (matriz[mouseX, mouseY] != null)
                    {
                        whiteEating();
                    }
                    else
                    {
                        Notification.MessageQueue.Enqueue("It is empty", "ACCEPT", () => AcceptNotification());
                        objeto = null;
                    }
                    #endregion
                }
                else
                {
                    #region Wrong movement
                    Notification.MessageQueue.Enqueue("ou can only move one position in front of you", "ACCEPT", () => AcceptNotification());
                    objeto = null;
                    #endregion
                }
                #endregion
            }
        }

        public void blackPawn()
        {
            if (newY == 1)
            {
                #region Starting
                if ((mouseY == newY + 1) && (mouseX == newX))
                {
                    #region First movement
                    if (matriz[mouseX, mouseY] == null)
                    {
                        Moving();
                        turn = true;
                        turnColor = true;
                        alternador = true;
                    }
                    else
                    {
                        Notification.MessageQueue.Enqueue("It is ocuped", "ACCEPT", () => AcceptNotification());
                        objeto = null;
                    }
                    #endregion
                }
                else if ((mouseY == newY + 2) && (mouseX == newX))
                {
                    #region Second movement
                    if (((sk8Chess.Pieces)matriz[mouseX, mouseY]) == null)
                    {
                        Moving();
                        turn = true;
                        turnColor = true;
                        alternador = true;
                    }
                    else
                    {
                        Notification.MessageQueue.Enqueue("It is ocuped", "ACCEPT", () => AcceptNotification());
                        objeto = null;
                    }
                    #endregion
                }
                else if ((mouseY == newY + 1) && ((mouseX == newX - 1) || (mouseX == newX + 1)))
                {
                    #region Eating movement
                    if (matriz[mouseX, mouseY] != null)
                    {
                        blackEating();
                    }
                    else
                    {
                        Notification.MessageQueue.Enqueue("It is empty", "ACCEPT", () => AcceptNotification());
                        objeto = null;
                    }
                    #endregion
                }
                else
                {
                    #region Wrong movement
                    Notification.MessageQueue.Enqueue("You can only move one or two positions in front of you", "ACCEPT", () => AcceptNotification());
                    objeto = null;
                    #endregion
                }
                #endregion
            }
            else if (newY != 1)
            {
                #region After starting
                if((mouseY == newY + 1) && (mouseX == newX))
                {
                    #region First movement
                    if (matriz[mouseX, mouseY] == null)
                    {
                        Moving();
                        turn = true;
                        turnColor = true;
                        alternador = true;
                    }
                    else
                    {
                        Notification.MessageQueue.Enqueue("It is ocuped", "ACCEPT", () => AcceptNotification());
                        objeto = null;
                    }
                    #endregion
                }
                else if ((mouseY == newY + 1) && ((mouseX == newX + 1) || (mouseX == newX - 1)))
                {
                    #region Eating movement
                    if (matriz[mouseX, mouseY] != null)
                    {
                        blackEating();
                    }
                    else
                    {
                        Notification.MessageQueue.Enqueue("It is emprty", "ACCEPT", () => AcceptNotification());
                        objeto = null;
                    }
                    #endregion
                }
                else
                {
                    #region Wrong movement
                    Notification.MessageQueue.Enqueue("You can only move one in front of you", "ACCEPT", () => AcceptNotification());
                    objeto = null;
                    #endregion
                }
                #endregion
            }
        }
        
        public void whiteEating()
        {
            #region White eating
            if ((((sk8Chess.Pieces)matriz[mouseX, mouseY]).Fill == PiecesEnumeration.BlackPawn) ||
                (((sk8Chess.Pieces)matriz[mouseX, mouseY]).Fill == PiecesEnumeration.BlackRook) ||
                (((sk8Chess.Pieces)matriz[mouseX, mouseY]).Fill == PiecesEnumeration.BlackBishop) ||
                (((sk8Chess.Pieces)matriz[mouseX, mouseY]).Fill == PiecesEnumeration.BlackKnight) ||
                (((sk8Chess.Pieces)matriz[mouseX, mouseY]).Fill == PiecesEnumeration.BlackQueen))
            {
                Eating();
                Moving();
                turn = false;
                turnColor = false;
                alternador = false;
            }
            else if (((sk8Chess.Pieces)matriz[mouseX, mouseY]).Fill == PiecesEnumeration.BlackKing)
            {
                musicWhenThereIsACheckMate(SoundType.whitePlayer);
                Eating();
                Moving();
                checkMate("White player");
            }
            else
            {
                Notification.MessageQueue.Enqueue("It is an incorrect movement", "ACCEPT", () => AcceptNotification());
                objeto = null;
            }
            #endregion
        }

        public void blackEating()
        {
            #region Black eating
            if ((((sk8Chess.Pieces)matriz[mouseX, mouseY]).Fill == PiecesEnumeration.WhitePawn) ||
                (((sk8Chess.Pieces)matriz[mouseX, mouseY]).Fill == PiecesEnumeration.WhiteRook) ||
                (((sk8Chess.Pieces)matriz[mouseX, mouseY]).Fill == PiecesEnumeration.WhiteBishop) ||
                (((sk8Chess.Pieces)matriz[mouseX, mouseY]).Fill == PiecesEnumeration.WhiteKnight) ||
                (((sk8Chess.Pieces)matriz[mouseX, mouseY]).Fill == PiecesEnumeration.WhiteQueen))
            {
                Eating();
                Moving();
                turn = true;
                turnColor = true;
                alternador = true;
            }
            else if (((sk8Chess.Pieces)matriz[mouseX, mouseY]).Fill == PiecesEnumeration.WhiteKing)
            {
                musicWhenThereIsACheckMate(SoundType.blackPlayer);
                Eating();
                Moving();
                checkMate("Black Player");
            }
            else
            {
                Notification.MessageQueue.Enqueue("It is an incorrect movement", "ACCEPT", () => AcceptNotification());
                objeto = null;
            }
            #endregion
        }

        public void Moving()
        {
            #region Moving
            Tablero.Children.Remove((sk8Chess.Pieces)matriz[newX, newY]);
            matriz[newX, newY] = null;
            Grid.SetColumn(((sk8Chess.Pieces)objeto), mouseX);
            Grid.SetRow(((sk8Chess.Pieces)objeto), mouseY);
            Tablero.Children.Add(((sk8Chess.Pieces)objeto));
            matriz[mouseX, mouseY] = objeto;
            objeto = null;
            #endregion
        }

        public void Eating()
        {
            Tablero.Children.Remove((sk8Chess.Pieces)matriz[mouseX, mouseY]);
        }

        private void PausingTime(object sender, RoutedEventArgs e)
        {
            #region  Stop time
            timer.Stop();
            StartTime.IsEnabled = true;
            StopTime.Visibility = Visibility.Hidden;
            StartTime.Visibility = Visibility.Visible;
            #endregion
        }

        private void StartingTime(object sender, RoutedEventArgs e)
        {
            #region Start time
            timer.Start();
            StartTime.Visibility = Visibility.Hidden;
            StopTime.Visibility = Visibility.Visible;
            #endregion
        }
        
        private void AcceptDialogRestartGame(object sender, RoutedEventArgs e)
        {
            newGame();
        }

        private void RestartGame(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            RestartGameDialog.IsOpen = true;
        }

        public void newGame()
        {
            #region New game
            Tablero.Children.Clear();

            for (int x = 0; x <= 7; x++)
            {
                for (int y = 0; y <= 7; y++)
                {
                    matriz[x, y] = null;
                }
            }

            turn = true;
            turnColor = true;
            alternador = true;

            paintingBoardRedAndBlue();
            placingPieces();

            Timer.Text = "00:00:00";

            seconds = 0;
            minutes = 0;
            hours = 0;

            Timer.Text = (String.Format(hours.ToString("00")) + ":" + String.Format(minutes.ToString("00")) +
            ":" + String.Format(seconds.ToString("00")));

            StopTime.Visibility = Visibility.Hidden;
            StartTime.Visibility = Visibility.Visible;
            StartTime.IsEnabled = false;
            RestartTime.IsEnabled = false;
                
            Positions.Text = "-,-";

            WhiteTurn.Fill = greenTurn;
            BlackTurn.Fill = redTurn;

            RestartGameDialog.IsOpen = false;
            #endregion
        }

        public void checkMate(string winner)
        {
            #region Checkmate
            timer.Stop();
            
            MessageBoxResult result =  MessageBox.Show(winner + " " + "YOU HAVE DONE CHECKMATE!", "CONGRATULATIONS!", MessageBoxButton.OK, MessageBoxImage.Hand);

            if (result == MessageBoxResult.OK)
            {
                Tablero.Children.Clear();

                for (int x = 0; x <= 7; x++)
                {
                    for (int y = 0; y <= 7; y++)
                    {
                        matriz[x, y] = null;
                    }
                }

                turn = true;
                turnColor = true;
                alternador = true;

                paintingBoardRedAndBlue();
                placingPieces();

                Timer.Text = "00:00:00";

                hours = 0;
                minutes = 0;
                seconds = 0;

                Positions.Text = "-,-";

                WhiteTurn.Fill = greenTurn;
                BlackTurn.Fill = redTurn;

                StopTime.Visibility = Visibility.Hidden;
                StartTime.Visibility = Visibility.Visible;
                StartTime.IsEnabled = false;
                RestartTime.IsEnabled = false;

                player.Stop();
            }

            #endregion
        }

        internal enum SoundType
        {
            whitePlayer,
            blackPlayer
        }

        private void musicWhenThereIsACheckMate(MainWindow.SoundType soundType)
        {
            #region After win
            //C:/Users/Monitor41P1/Downloads/13_Let_Me_Love_You_feat.wav
            //C:/Users/Monitor41P1/Downloads/01_All_Day.wav
            
            switch (soundType)
            {
                case SoundType.whitePlayer:
                    player.SoundLocation = "C:/Users/Monitor41P1/Downloads/13_Let_Me_Love_You_feat.wav";
                    player.Play();
                    break;
                case SoundType.blackPlayer:
                    player.SoundLocation = "C:/Users/Monitor41P1/Downloads/01_All_Day.wav";
                    player.Play();
                    break;
            }
            #endregion
        }

        private void ExitGame(object sender, RoutedEventArgs e)
        {
            #region Exit game
            MessageBoxResult question = MessageBox.Show("Are you sure you want to exit?", "¡WARNING!",  MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (question == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            #endregion
        }

        private void HowToPlay(object sender, RoutedEventArgs e)
        {
            ////Process.Start("../Rules/LEYES DEL AJEDREZ DE LA FIDE.pdf");
            //PDF.Navigate(new Uri("about:blank"));
            //PDF.Navigate("Rules/LEYES DEL AJEDREZ DE LA FIDE.pdf");
        }

        private void AbrirReproductor(object sender, RoutedEventArgs e)
        {
            sk8ChessPlayer sk8ChessPlayer = new sk8ChessPlayer();
            sk8ChessPlayer.Show();
        }

        private void AboutSk8Chess(object sender, RoutedEventArgs e)
        {
            AboutSk8Chess aboutSk8Chess = new AboutSk8Chess();
            aboutSk8Chess.Show();
        }

        private void OpeningSettings(object sender, RoutedEventArgs e)
        {
            sk8ChessSettings sk8ChessSettings = new sk8ChessSettings();
            sk8ChessSettings.Show();
        }

        public void paintingBoardBlackAndWhite()
        {
            #region Painting Black and white
            SolidColorBrush blackColor = new SolidColorBrush(Color.FromArgb(200, 0, 0, 0));
            SolidColorBrush whiteColor = new SolidColorBrush(Color.FromArgb(200, 255, 255, 255)); 

            for (int y = 0; y <= 7; y++)
            {
                for (int x = 0; x <= 7; x++)
                {
                    if (x % 2 == 1)
                    {
                        Rectangle blackSquare = new Rectangle();
                        blackSquare.Fill = blackColor;
                        if (y % 2 == 1)
                        {
                            Grid.SetRow(blackSquare, y);
                            Grid.SetColumn(blackSquare, x - 1);
                        }
                        else
                        {
                            Grid.SetRow(blackSquare, y);
                            Grid.SetColumn(blackSquare, x);
                        }
                        Tablero.Children.Add(blackSquare);
                    }
                    else
                    {
                        Rectangle whiteSquare = new Rectangle();
                        whiteSquare.Fill = whiteColor;
                        if (y % 2 == 1)
                        {
                            Grid.SetRow(whiteSquare, y);
                            Grid.SetColumn(whiteSquare, x + 1);
                        }
                        else
                        {
                            Grid.SetRow(whiteSquare, y);
                            Grid.SetColumn(whiteSquare, x);
                        }
                        Tablero.Children.Add(whiteSquare);
                    }
                }
            }
            #endregion
        }

        private void paintingBoardRedAndBlue()
        {
            #region Painting Red and Blue
            SolidColorBrush blackColor = new SolidColorBrush(Color.FromArgb(200, 255, 89, 84)); //red
            SolidColorBrush whiteColor = new SolidColorBrush(Color.FromArgb(200, 23, 171, 227)); //blue

            for (int y = 0; y <= 7; y++)
            {
                for (int x = 0; x <= 7; x++)
                {
                    if (x % 2 == 1)
                    {
                        Rectangle blackSquare = new Rectangle();
                        blackSquare.Fill = blackColor;
                        if (y % 2 == 1)
                        {
                            Grid.SetRow(blackSquare, y);
                            Grid.SetColumn(blackSquare, x - 1);
                        }
                        else
                        {
                            Grid.SetRow(blackSquare, y);
                            Grid.SetColumn(blackSquare, x);
                        }
                        Tablero.Children.Add(blackSquare);
                    }
                    else
                    {
                        Rectangle whiteSquare = new Rectangle();
                        whiteSquare.Fill = whiteColor;
                        if (y % 2 == 1)
                        {
                            Grid.SetRow(whiteSquare, y);
                            Grid.SetColumn(whiteSquare, x + 1);
                        }
                        else
                        {
                            Grid.SetRow(whiteSquare, y);
                            Grid.SetColumn(whiteSquare, x);
                        }
                        Tablero.Children.Add(whiteSquare);
                    }
                }
            }
            #endregion
        }
        
        private void CloseDialogRestarGame(object sender, RoutedEventArgs e)
        {
            RestartGameDialog.IsOpen = false;
            timer.Start();
        }
        
        private void AcceptNotification()
        {
            Notification.IsActive = false;
        }

        private void paintingBoardGreenAndYellow()
        {
            #region Painting Red and Blue
            SolidColorBrush blackColor = new SolidColorBrush(Color.FromArgb(200, 73, 232, 62)); //green
            SolidColorBrush whiteColor = new SolidColorBrush(Color.FromArgb(200, 255, 212, 50)); //yellow

            for (int y = 0; y <= 7; y++)
            {
                for (int x = 0; x <= 7; x++)
                {
                    if (x % 2 == 1)
                    {
                        Rectangle blackSquare = new Rectangle();
                        blackSquare.Fill = blackColor;
                        if (y % 2 == 1)
                        {
                            Grid.SetRow(blackSquare, y);
                            Grid.SetColumn(blackSquare, x - 1);
                        }
                        else
                        {
                            Grid.SetRow(blackSquare, y);
                            Grid.SetColumn(blackSquare, x);
                        }
                        Tablero.Children.Add(blackSquare);
                    }
                    else
                    {
                        Rectangle whiteSquare = new Rectangle();
                        whiteSquare.Fill = whiteColor;
                        if (y % 2 == 1)
                        {
                            Grid.SetRow(whiteSquare, y);
                            Grid.SetColumn(whiteSquare, x + 1);
                        }
                        else
                        {
                            Grid.SetRow(whiteSquare, y);
                            Grid.SetColumn(whiteSquare, x);
                        }
                        Tablero.Children.Add(whiteSquare);
                    }
                }
            }
            #endregion
        }

        public void placingPieces()
        {
            #region Placing
            for (int x = 0; x <= 7; x += 7)
            {
                Pieces blackRook = new Pieces();
                blackRook.Fill = PiecesEnumeration.BlackRook;
                Grid.SetColumn(blackRook, x);
                Grid.SetRow(blackRook, 0);
                Tablero.Children.Add(blackRook);
                matriz[x, 0] = blackRook;

                Pieces whiteRook = new Pieces();
                whiteRook.Fill = PiecesEnumeration.WhiteRook;
                Grid.SetColumn(whiteRook, x);
                Grid.SetRow(whiteRook, 7);
                Tablero.Children.Add(whiteRook);
                matriz[x, 7] = whiteRook;
            }

            for (int x = 1; x <= 6; x += 5)
            {
                Pieces blackKnight = new Pieces();
                blackKnight.Fill = PiecesEnumeration.BlackKnight;
                Grid.SetColumn(blackKnight, x);
                Grid.SetRow(blackKnight, 0);
                Tablero.Children.Add(blackKnight);
                matriz[x, 0] = blackKnight;

                Pieces whiteKnight = new Pieces();
                whiteKnight.Fill = PiecesEnumeration.WhiteKnight;
                Grid.SetColumn(whiteKnight, x);
                Grid.SetRow(whiteKnight, 7);
                Tablero.Children.Add(whiteKnight);
                matriz[x, 7] = whiteKnight;
            }

            for (int x = 2; x <= 5; x += 3)
            {
                Pieces blackBishop = new Pieces();
                blackBishop.Fill = PiecesEnumeration.BlackBishop;
                Grid.SetColumn(blackBishop, x);
                Grid.SetRow(blackBishop, 0);
                Tablero.Children.Add(blackBishop);
                matriz[x, 0] = blackBishop;

                Pieces whiteBishop = new Pieces();
                whiteBishop.Fill = PiecesEnumeration.WhiteBishop;
                Grid.SetColumn(whiteBishop, x);
                Grid.SetRow(whiteBishop, 7);
                Tablero.Children.Add(whiteBishop);
                matriz[x, 7] = whiteBishop;
            }
            
            for (int x = 4; x == 4; x++)
            {
                Pieces blackKing = new Pieces();
                blackKing.Fill = PiecesEnumeration.BlackKing;
                Grid.SetColumn(blackKing, x);
                Grid.SetRow(blackKing, 0);
                Tablero.Children.Add(blackKing);
                matriz[x, 0] = blackKing;

                Pieces whiteKing = new Pieces();
                whiteKing.Fill = PiecesEnumeration.WhiteKing;
                Grid.SetColumn(whiteKing, x);
                Grid.SetRow(whiteKing, 7);
                Tablero.Children.Add(whiteKing);
                matriz[x, 7] = whiteKing;
            }

            for (int x = 3; x == 3; x++)
            {
                Pieces blackQueen = new Pieces();
                blackQueen.Fill = PiecesEnumeration.BlackQueen;
                Grid.SetColumn(blackQueen, x);
                Grid.SetRow(blackQueen, 0);
                Tablero.Children.Add(blackQueen);
                matriz[x, 0] = blackQueen;

                Pieces whiteQueen = new Pieces();
                whiteQueen.Fill = PiecesEnumeration.WhiteQueen;
                Grid.SetColumn(whiteQueen, x);
                Grid.SetRow(whiteQueen, 7);
                Tablero.Children.Add(whiteQueen);
                matriz[x, 7] = whiteQueen;
            }

            for (int x = 0; x <= 7; x++)
            {
                Pieces blackPawn = new Pieces();
                blackPawn.Fill = PiecesEnumeration.BlackPawn;
                Grid.SetColumn(blackPawn, x);
                Grid.SetRow(blackPawn, 1);
                Tablero.Children.Add(blackPawn);
                matriz[x, 1] = blackPawn;

                Pieces whitePawn = new Pieces();
                whitePawn.Fill = PiecesEnumeration.WhitePawn;
                Grid.SetColumn(whitePawn, x);
                Grid.SetRow(whitePawn, 6);
                Tablero.Children.Add(whitePawn);
                matriz[x, 6] = whitePawn;
            }
            #endregion
        }
    }
}
