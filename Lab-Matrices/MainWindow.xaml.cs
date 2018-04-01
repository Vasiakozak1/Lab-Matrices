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
        private int LEFT_MATRIX_ROWS = 4;
        private int LEFT_MATRIX_COLS = 4;
        private int RIGHT_MATRIX_ROWS = 4;
        private int RIGHT_MATRIX_COLS = 4;
        private TextBox[,] RightMatrixCells;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        TextBox GetCell()
        {
            var textBox = new TextBox();
        }
    }
}
