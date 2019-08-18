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

namespace calc_wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //bool advancedCalc = false;

        decimal firstElement = 0;
        decimal secondElement = 0;

        decimal result = 0;
        bool plusOperationType = false;
        bool minusOperationType = false;
        bool multipleOperationType = false;
        bool divideOperationType = false;

                              
        private void button2_Click(object sender, EventArgs e)
        {

            textField.AppendText("1");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            textField.AppendText("3");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            textField.AppendText("2");

        }
        private void btn4_Click(object sender, EventArgs e)
        {
            textField.AppendText("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {

            textField.AppendText("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            textField.AppendText("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            textField.AppendText("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            textField.AppendText("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            textField.AppendText("9");
        }
        private void btnZero_Click(object sender, EventArgs e)
        {

            textField.AppendText("0");
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {

             textField.AppendText(" + ");
            
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
           
                var textFromField = textField.Text;
                var textFieldArray = textFromField.Split(' ');

                int digitsCounter = 0;
                int charsCounter = 0;

                foreach (string text in textFieldArray)
                {

                    if ((text == "+") || (text == "-") || (text == "*") || (text == "/"))
                    {
                        charsCounter++;
                    }
                    else
                    {
                        digitsCounter++;

                    }

                

                decimal[] digits = new decimal[digitsCounter];
                int indexDigits = 0;
                char[] operations = new char[charsCounter];
                int indexChar = 0;
                bool skipNextDigit = false;

                foreach (string value in textFieldArray)
                {

                    if (value == "*")
                    {
                        digits[indexDigits - 1] = setUpOperationWithTwoElements("*");
                        //Need to get index of current text
                        int changedIndex = Array.IndexOf(textFieldArray, value);
                        if (!(changedIndex == digits.Length))
                        {

                            textFieldArray[changedIndex + 1] = Convert.ToString(setUpOperationWithTwoElements("*"));
                        }

                        //indexDigits++;
                        skipNextDigit = true;
                    }
                    else if (value == "/")
                    {
                        digits[indexDigits - 1] = setUpOperationWithTwoElements("/");
                        //indexDigits++;
                        skipNextDigit = true;
                    }
                    else
                    {
                        if ((value == "+") || (value == "-"))
                        {
                            operations[indexChar] = Convert.ToChar(value);
                            indexChar++;
                        }
                        else
                        {


                            if (skipNextDigit == true)
                            {
                                skipNextDigit = false;
                                continue;

                            }
                            else
                            {
                                digits[indexDigits] = Convert.ToDecimal(value);
                                indexDigits++;
                            }

                        }
                    }




                }



                decimal leftSideItem, rightSideItem;
                int operationIndex;

                decimal setUpOperationWithTwoElements(string value)
                {
                    operationIndex = Array.FindIndex(textFieldArray, row => row.Contains(value));

                    leftSideItem = Convert.ToDecimal(textFieldArray[operationIndex - 1]);
                    rightSideItem = Convert.ToDecimal(textFieldArray[operationIndex + 1]);

                    if (value == "*")
                    {
                        return leftSideItem * rightSideItem;
                    }
                    else
                    {
                        return leftSideItem / rightSideItem;
                    }

                }


                
                displayResult();

            }





        }

        private void btnMinus_Click(object sender, EventArgs e)
        {

           
                textField.AppendText(" - ");

        }

        private void btnMultiple_Click(object sender, EventArgs e)
        {
            
                textField.AppendText(" * ");

        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            
                textField.AppendText(" / ");

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetAll();
            textField.Text = "";
            resetImage();
        }

        private void resetAll()
        {
            firstElement = 0;
            secondElement = 0;
            result = 0;

        }

        private void CheckZero()
        {

            if (textField.Text.Contains(",") == false)
            {
                if (textField.Text.Length >= 2 && textField.Text.IndexOf("0") == 0)
                {
                    textField.Text = textField.Text.Remove(0, 1);
                    textField.UpdateLayout();
                }
            }

        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            textField.AppendText(",");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void picImage_Click(object sender, EventArgs e)
        {
            changeImage();
        }
        private void changeImage()
        {
            Uri uri = new Uri("https://stickershop.line-scdn.net/stickershop/v1/sticker/5715044/ANDROID/sticker.png");
            BitmapImage bitmap = new BitmapImage(uri);
            Image img = new Image();
            picImage.Source = bitmap;
           // picImage.UpdateLayout();
           
        }

        private void resetImage()
        {
         
            Uri uri = new Uri("https://stickershop.line-scdn.net/stickershop/v1/sticker/5715055/ANDROID/sticker.png");
            BitmapImage bitmap = new BitmapImage(uri);
            Image img = new Image();
            picImage.Source = bitmap;
            // picImage.UpdateLayout();
        }



        private void sqrtButton_Click(object sender, EventArgs e)
        {


            if (textField.Text != "")
            {
                firstElement = Convert.ToDecimal(textField.Text);
                double doubleElement = (double)firstElement;
                textField.Text = "";
                result = (decimal)Math.Sqrt(doubleElement);
                displayResult();
            }
        }

        private void displayResult()
        {

            string resultInField = Convert.ToString(result);
            textField.Text = resultInField;
            resetAll();
            changeImage();
        }

       
    }
}
