using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using TicTacToePlusGame.GameLogic;
using TicTacToePlusGame.Graphics;

namespace TicTacToePlusGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int BIG_REC_SIZE = 150;
        const int SMALL_REC_SIZE = 30;
        int queueTeam;
        TicTacToeLogic mainLogic;
        public MainWindow()
        {
            InitializeComponent();          
        }

        private void button_newGame_Click(object sender, RoutedEventArgs e)
        {
            canvas_play.Children.Clear();
            InitializeField();
            queueTeam = 1;
            mainLogic = new TicTacToeLogic();
            label_queue.Content = "Ходит: X";
        }

        GameRectangle[,] outsideRecArr;
        GameRectangleInside[,][,] insideRecArr;

        private void InitializeField()
        {
            outsideRecArr = new GameRectangle[3, 3];
            insideRecArr = new GameRectangleInside[3, 3][,];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Rectangle temp = new Rectangle()
                    {
                        Fill = new SolidColorBrush(Color.FromArgb(150, 0, 0, 0)),
                        Height = BIG_REC_SIZE,
                        Width = BIG_REC_SIZE,
                        Margin = new Thickness((i + 1) * 10 + i * BIG_REC_SIZE, (j + 1) * 10 + j * BIG_REC_SIZE, 0, 0)
                    };                    
                    outsideRecArr[i, j] = new GameRectangle(temp, i, j);
                    canvas_play.Children.Add(temp);
                    insideRecArr[i, j] = new GameRectangleInside[3, 3];
                    for (int m = 0; m < 3; m++)
                    {
                        for (int n = 0; n < 3; n++)
                        {
                            Rectangle temp1 = new Rectangle()
                            {
                                Fill = new SolidColorBrush(Color.FromArgb(255, 150, 150, 150)),
                                Height = SMALL_REC_SIZE,
                                Width = SMALL_REC_SIZE,
                                Margin = new Thickness( 
                                    (i + 1) * 10 + i * BIG_REC_SIZE + 10 + (m + 1) * 10 + m * SMALL_REC_SIZE, 
                                    (j + 1) * 10 + j * BIG_REC_SIZE + 10 + (n + 1) * 10 + n * SMALL_REC_SIZE,
                                    0, 0)
                            };
                            temp1.MouseUp += Cell_Click;
                            insideRecArr[i, j][m, n] = new GameRectangleInside(temp1, i, j, m, n);
                            canvas_play.Children.Add(temp1);                            
                        }
                    }                     
                    
                }
            }
        }

        private void Cell_Click(object sender, MouseButtonEventArgs e)
        {
            var rec = (Rectangle)sender;
            foreach (var itemArr in insideRecArr)
            {
                foreach (var item in itemArr)
                {
                    if (item.Border == rec)
                    {
                        try
                        {
                            mainLogic.MakeMove(item.X1, item.Y1, item.X2, item.Y2, queueTeam);
                            UpdateField();
                            if (mainLogic.IsWon(queueTeam))
                            {
                                string message = queueTeam == 1 ? "X выиграл" : "O выиграл";
                                MessageBox.Show(message);
                                label_queue.Content = message;
                                queueTeam = -1;
                            }
                            else if (mainLogic.IsDraw())
                            {
                                string message = "Ничья";
                                MessageBox.Show(message);
                                label_queue.Content = message;
                                queueTeam = -1;
                            }
                            else
                            {
                                queueTeam = queueTeam % 2 + 1;
                                string qu = queueTeam == 1 ? "Ходит: X" : "Ходит: O";
                                label_queue.Content = qu;
                            }
                        }
                            
                        catch
                        {
                            //Can't move
                        }
                    }
                }
            }
        }

        private void UpdateField()
        {
            canvas_play.Children.Clear();
            for (int x1 = 0; x1 < 3; x1++)
            {
                for (int y1 = 0; y1 < 3; y1++)
                {
                    int tempCellValue = mainLogic.GetOutsideCell(x1, y1);
                    switch (tempCellValue)
                    {
                        case 1:
                            if (outsideRecArr[x1, y1].Item == null)
                            {
                                outsideRecArr[x1, y1].Item = new ControlX(
                                    outsideRecArr[x1, y1].Border.Margin.Left + 10,
                                    outsideRecArr[x1, y1].Border.Margin.Top + 10,
                                    outsideRecArr[x1, y1].Border.Width - 20
                                    );
                            }
                            canvas_play.Children.Add(outsideRecArr[x1, y1].Border);
                            outsideRecArr[x1, y1].Item.AddTo(canvas_play.Children);
                            continue;                         
                        case 2:
                            if (outsideRecArr[x1, y1].Item == null)
                            {
                                outsideRecArr[x1, y1].Item = new ControlO(
                                    outsideRecArr[x1, y1].Border.Margin.Left + 10,
                                    outsideRecArr[x1, y1].Border.Margin.Top + 10,
                                    outsideRecArr[x1, y1].Border.Width - 20
                                    );
                            }
                            canvas_play.Children.Add(outsideRecArr[x1, y1].Border);
                            outsideRecArr[x1, y1].Item.AddTo(canvas_play.Children);
                            continue;
                        case 10:
                            if (outsideRecArr[x1, y1].Item == null)
                            {
                                outsideRecArr[x1, y1].Item = new ControlNAN(
                                    outsideRecArr[x1, y1].Border.Margin.Left + 10,
                                    outsideRecArr[x1, y1].Border.Margin.Top + 10,
                                    outsideRecArr[x1, y1].Border.Width - 20
                                    );
                            }
                            canvas_play.Children.Add(outsideRecArr[x1, y1].Border);
                            outsideRecArr[x1, y1].Item.AddTo(canvas_play.Children);
                            continue;
                        case 0:
                            outsideRecArr[x1, y1].Item = null;
                            canvas_play.Children.Add(outsideRecArr[x1, y1].Border);
                            break;
                    }

                    for (int x2 = 0; x2 < 3; x2++)
                    {
                        for (int y2 = 0; y2 < 3; y2++)
                        {
                            int tempInsideCell = mainLogic.GetInsideCell(x1, y1, x2, y2);
                            switch (tempInsideCell)
                            {
                                case 1:
                                    if (insideRecArr[x1, y1][x2,y2].Item == null)
                                    {
                                        insideRecArr[x1, y1][x2, y2].Item = new ControlX(
                                            insideRecArr[x1, y1][x2, y2].Border.Margin.Left + 2,
                                            insideRecArr[x1, y1][x2, y2].Border.Margin.Top + 2,
                                            insideRecArr[x1, y1][x2, y2].Border.Width - 4
                                            );
                                    }
                                    canvas_play.Children.Add(insideRecArr[x1, y1][x2, y2].Border);
                                    insideRecArr[x1, y1][x2, y2].Item.AddTo(canvas_play.Children);
                                    break;
                                case 2:
                                    if (insideRecArr[x1, y1][x2, y2].Item == null)
                                    {
                                        insideRecArr[x1, y1][x2, y2].Item = new ControlO(
                                            insideRecArr[x1, y1][x2, y2].Border.Margin.Left + 2,
                                            insideRecArr[x1, y1][x2, y2].Border.Margin.Top + 2,
                                            insideRecArr[x1, y1][x2, y2].Border.Width - 4
                                            );
                                    }
                                    canvas_play.Children.Add(insideRecArr[x1, y1][x2, y2].Border);
                                    insideRecArr[x1, y1][x2, y2].Item.AddTo(canvas_play.Children);
                                    break;
                                case 0:
                                    insideRecArr[x1, y1][x2, y2].Item = null;
                                    canvas_play.Children.Add(insideRecArr[x1, y1][x2, y2].Border);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void UpdateGraphics()
        {

        }


    }
}
