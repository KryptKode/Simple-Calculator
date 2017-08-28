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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       private Operations.Operation currentOperation;
        private double firstNum;
        private double secondNum;
        private string input;
        private string content;
        private double ans;
        private bool end;

        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void BtnEntry_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            DisplayValue(button.Content.ToString());
                
        }

        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {

            SetOperation(Operations.Operation.Divide, sender);
              
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            SetOperation(Operations.Operation.Add, sender);
        }

        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            SetOperation(Operations.Operation.Multiply, sender);
        }

        private void BtnSubtract_Click(object sender, RoutedEventArgs e)
        {
            SetOperation(Operations.Operation.Subtract, sender);
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (!Double.TryParse(input, out secondNum))
            {
                SolutionTextBlock.Text = "Error";
            }
            else
            {
                input = "";
            }



           ans =  Operations.PerformOperation(firstNum, secondNum, currentOperation);

            DisplayValue(firstNum + " " +  content + " " + secondNum);
            SolutionTextBlock.Text = "Ans = " + ans;

            ResetValues();
        }

        private void ResetValues()
        {
            input = "";
            
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearValuesTextBox();
            ClearSolutionTextBox();
        }

        private void ClearValuesTextBox() {
            ValuesTextBox.Text = "";
        }

        private void ClearSolutionTextBox()
        {
            SolutionTextBlock.Text = "";
            input = "";
        }

        private void DisplayValue (string buttonType) {
            if (end) {
                ValuesTextBox.Text = "";
                end = false;
            }
            input += buttonType;
            ValuesTextBox.Text = input;
            
        }

        private void SetOperation(Operations.Operation op, object sender) {

            Button button = (Button)sender;
            content = button.Content.ToString();

            currentOperation = op;
            ValuesTextBox.Text = content;
            if(!Double.TryParse(input, out firstNum)){
                SolutionTextBlock.Text = "Error";
            }else {
                input = "";
            }
        }
    }
}
