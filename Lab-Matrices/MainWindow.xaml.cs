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

namespace Lab_Matrices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int LEFT_MATRIX_ROWS = 4;
        private const int LEFT_MATRIX_COLS = 4;
        private const int RIGHT_MATRIX_ROWS = 4;
        private const int RIGHT_MATRIX_COLS = 4;
        private const int MARGIN_BETWEEN_COLS = 5;
        private const int CELL_HEIGHT = 40;
        private const int CELL_WiDTH = 40;
        private TextBox[,] LeftMatrixCells;
        private TextBox[,] RightMatrixCells;
        private TextBox[,] ResultMatrixCells;
        public MainWindow()
        {
            InitializeComponent();
            LeftMatrixCells = new TextBox[LEFT_MATRIX_ROWS, LEFT_MATRIX_COLS];
            RightMatrixCells = new TextBox[RIGHT_MATRIX_ROWS, RIGHT_MATRIX_COLS];
            ResultMatrixCells = new TextBox[RIGHT_MATRIX_ROWS, LEFT_MATRIX_COLS];
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LeftMatrixGrid.Width = (LEFT_MATRIX_COLS * CELL_WiDTH) + ((LEFT_MATRIX_COLS + 1) * MARGIN_BETWEEN_COLS);
            this.LeftMatrixGrid.Height = (LEFT_MATRIX_ROWS * CELL_HEIGHT) + ((LEFT_MATRIX_ROWS + 1) * MARGIN_BETWEEN_COLS);
            this.RightMatrixGrid.Width = (RIGHT_MATRIX_COLS * CELL_WiDTH) + ((RIGHT_MATRIX_COLS + 1) * MARGIN_BETWEEN_COLS);
            this.RightMatrixGrid.Height = (RIGHT_MATRIX_ROWS * CELL_HEIGHT) + ((RIGHT_MATRIX_ROWS + 1) * MARGIN_BETWEEN_COLS);
            this.ResultGrid.Width = (LEFT_MATRIX_COLS * CELL_WiDTH) + ((LEFT_MATRIX_COLS + 1) * MARGIN_BETWEEN_COLS);
            this.ResultGrid.Height = (RIGHT_MATRIX_ROWS * CELL_HEIGHT) + ((RIGHT_MATRIX_ROWS + 1) * MARGIN_BETWEEN_COLS);

            this.InitLeftMatrix();
            this.InitRightMatrix();
            this.InitResultMatrix();
        }

        private void InitLeftMatrix()
        {
            var marginLeft = MARGIN_BETWEEN_COLS;
            var marginTop = MARGIN_BETWEEN_COLS;
            for (int i = 0; i < LEFT_MATRIX_ROWS; i++)
            {
                for (int j = 0; j < LEFT_MATRIX_COLS; j++)
                {
                    var cell = GetCell(marginLeft, marginTop);
                    this.LeftMatrixGrid.Children.Add(cell);
                    LeftMatrixCells[i, j] = cell;
                    marginLeft += (CELL_WiDTH + MARGIN_BETWEEN_COLS);
                }
                marginTop += (CELL_HEIGHT + MARGIN_BETWEEN_COLS);
                marginLeft = MARGIN_BETWEEN_COLS;
            }
        }
        private void InitRightMatrix()
        {
            var marginLeft = MARGIN_BETWEEN_COLS;
            var marginTop = MARGIN_BETWEEN_COLS;
            for (int i = 0; i < RIGHT_MATRIX_ROWS; i++)
            {
                for (int j = 0; j < RIGHT_MATRIX_COLS; j++)
                {
                    var cell = GetCell(marginLeft, marginTop);
                    this.RightMatrixGrid.Children.Add(cell);
                    RightMatrixCells[i, j] = cell;
                    marginLeft += (CELL_WiDTH + MARGIN_BETWEEN_COLS);
                }
                marginTop += (CELL_HEIGHT + MARGIN_BETWEEN_COLS);
                marginLeft = MARGIN_BETWEEN_COLS;
            }
        }
        private void InitResultMatrix()
        {
            var marginLeft = MARGIN_BETWEEN_COLS;
            var marginTop = MARGIN_BETWEEN_COLS;
            for (int i = 0; i < RIGHT_MATRIX_ROWS; i++)
            {
                for (int j = 0; j < LEFT_MATRIX_COLS; j++)
                {
                    var cell = GetCell(marginLeft, marginTop);
                    this.ResultGrid.Children.Add(cell);
                    ResultMatrixCells[i, j] = cell;
                    marginLeft += (CELL_WiDTH + MARGIN_BETWEEN_COLS);
                }
                marginTop += (CELL_HEIGHT + MARGIN_BETWEEN_COLS);
                marginLeft = MARGIN_BETWEEN_COLS;
            }
        }


        TextBox GetCell(int marginLeft, int marginTop)
        {
            var textBox = new TextBox();
            textBox.VerticalAlignment = VerticalAlignment.Top;
            textBox.HorizontalAlignment = HorizontalAlignment.Left;
            textBox.VerticalContentAlignment = VerticalAlignment.Center;
            textBox.HorizontalContentAlignment = HorizontalAlignment.Center;
            textBox.FontSize = 18;
            textBox.Margin = new Thickness(marginLeft, marginTop, 0, 0);
            textBox.Width = CELL_WiDTH;
            textBox.Height = CELL_HEIGHT;
            textBox.Text = "0";

            return textBox;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < LeftMatrixCells.GetLength(0); i++)
            {
                double currentCellSum = 0;
                for (int j = 0; j < RightMatrixCells.GetLength(1); j++)
                {
                    for (int k = 0; k < RightMatrixCells.GetLength(1); k++)
                    {
                        double leftMatrixCellValue;
                        double rightMatrixCellValue;
                        if (!double.TryParse(LeftMatrixCells[i, k].Text, out leftMatrixCellValue)
                             || !double.TryParse(RightMatrixCells[k, j].Text, out rightMatrixCellValue))
                        {
                            MessageBox.Show("неправильно введені дані");
                            return;
                        }
                        currentCellSum += (leftMatrixCellValue * rightMatrixCellValue);
                    }
                    ResultMatrixCells[i, j].Text = currentCellSum.ToString();
                    currentCellSum = 0;
                }
            }
        }
    }
}
