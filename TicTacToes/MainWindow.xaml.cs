using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool direction;
        public int moves;
        // Make sure that initial the fields have a different value because of the 3 way comparision
        string[,] gameBoard = new string[3, 3] { { "A", "B", "C" }, { "B", "C", "D" }, { "C", "D", "E" } };
        public MainWindow()
        {
            InitializeComponent();
            direction = true;
            moves = 0;
        }

        public bool CheckWin()
        {
            return true;
        }


        public void Button_Click(object sender, RoutedEventArgs e)
        {
            // Code here to act upon
            var clickedButton = sender as Button;
            List<string> mylist = new List<string>();
            bool allElementsAreEqual = false;

            if (direction == false)
            {
                clickedButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#811717"));
                clickedButton.Content = "X";
                direction = true;
            }
            else if (direction == true)
            {
                clickedButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#126712"));
                clickedButton.Content = "O";
                direction = false;
            }
            //
            gameBoard[Grid.GetRow(clickedButton), Grid.GetColumn(clickedButton)] = clickedButton.Content.ToString();
            // Disable button field so it can't be clicked anymore
            clickedButton.IsHitTestVisible = false;
            moves++;
            this.Title = "TicTacToes - Moves: " + moves.ToString();

            if (moves > 4)
            {
                // Check for win horizontal
                for (int i = 0; i < gameBoard.GetLength(0); i++)
                {
                    mylist.Clear();
                    mylist.Add(gameBoard[i, 0]);
                    mylist.Add(gameBoard[i, 1]);
                    mylist.Add(gameBoard[i, 2]);
                    allElementsAreEqual = mylist.All(x => (x == mylist.First()));

                    if (allElementsAreEqual)
                    {
                        MessageBox.Show($"Player {gameBoard[i, 0]} wins");
                        break;
                    }
                }

                // Check for win vertical
                if (allElementsAreEqual == false)
                {
                    for (int i = 0; i < gameBoard.GetLength(0); i++)
                    {
                        mylist.Clear();
                        mylist.Add(gameBoard[0, i]);
                        mylist.Add(gameBoard[1, i]);
                        mylist.Add(gameBoard[2, i]);
                        allElementsAreEqual = mylist.All(x => (x == mylist.First()));

                        if (allElementsAreEqual)
                        {
                            MessageBox.Show($"Player {gameBoard[0, i]} wins");
                            break;
                        }
                    }
                }

                // Diagonal check 1
                if (allElementsAreEqual == false)
                {
                    mylist.Clear();
                    mylist.Add(gameBoard[0, 0]);
                    mylist.Add(gameBoard[1, 1]);
                    mylist.Add(gameBoard[2, 2]);
                    allElementsAreEqual = mylist.All(x => (x == mylist.First()));

                    if (allElementsAreEqual)
                        MessageBox.Show($"Player {gameBoard[0, 0]} wins");
                }

                // Diagonal check 2
                if (allElementsAreEqual == false)
                {
                    mylist.Clear();
                    mylist.Add(gameBoard[0, 2]);
                    mylist.Add(gameBoard[1, 1]);
                    mylist.Add(gameBoard[2, 0]);
                    allElementsAreEqual = mylist.All(x => (x == mylist.First()));

                    if (allElementsAreEqual)
                        MessageBox.Show($"Player {gameBoard[0, 2]} wins");
                }
            }

            if (moves == 9 || allElementsAreEqual)
            {
                if (allElementsAreEqual == false)
                    MessageBox.Show("DRAW");
                MessageBox.Show("END");
                Close();
            }
        }
    }
}
