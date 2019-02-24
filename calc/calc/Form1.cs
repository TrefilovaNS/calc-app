﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc
{
    public partial class Form1 : Form
    {

        decimal firstElement = 0;
        decimal secondElement = 0;
        
        decimal result = 0;
        bool plusOperationType = false;
        bool minusOperationType = false;
        bool multipleOperationType = false;
        bool divideOperationType = false;

        

        public Form1()
        {
            InitializeComponent();


        }

        private void textField_TextChanged(object sender, EventArgs e)
        {
            CheckZero();
        }

       

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

            
            minusOperationType = false;
            multipleOperationType = false;
            divideOperationType = false;

            if (textField.Text != "")
            {
                firstElement = Convert.ToDecimal(textField.Text);
                textField.Text = "";
                plusOperationType = true;
                
            }
            
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {

            if (textField.Text != "")
            {
                secondElement = Convert.ToDecimal(textField.Text);
                textField.Text = "";
            }
            
          
           
                if (plusOperationType == true)

                    
                        result = firstElement + secondElement;
                    

                if (minusOperationType == true)
                {
                    
                   
                        result = firstElement - secondElement;
                  

                }

                if (multipleOperationType == true)
                {
                    
                  
                    
                        result = firstElement * secondElement;
                    

                }
                if (divideOperationType == true)
                {
                    
                    
                        result = (decimal)firstElement / (decimal)secondElement;
                    

                }
            

            string resultInField = Convert.ToString(result);
            textField.Text = resultInField;
            resetAll();
            changeImage();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            
            plusOperationType = false;
            multipleOperationType = false;
            divideOperationType = false;

            if (textField.Text != "")
            {
                firstElement = Convert.ToDecimal(textField.Text);
                textField.Text = "";
                minusOperationType = true;

            }
        }

        private void btnMultiple_Click(object sender, EventArgs e)
        {

            minusOperationType = false;
            plusOperationType = false;
            divideOperationType = false;

            if (textField.Text != "")
            {
                firstElement = Convert.ToDecimal(textField.Text);
                textField.Text = "";
                multipleOperationType = true;

            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            minusOperationType = false;
            plusOperationType = false;
            multipleOperationType = false;           

            if (textField.Text != "")
            {
                firstElement = Convert.ToDecimal(textField.Text);
                textField.Text = "";
                divideOperationType = true;

            }
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
                    textField.Update();
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
                picImage.ImageLocation = "https://stickershop.line-scdn.net/stickershop/v1/sticker/5715044/ANDROID/sticker.png";
                picImage.Update();
            
        }

        private void resetImage()
        {
            picImage.ImageLocation = "https://stickershop.line-scdn.net/stickershop/v1/sticker/5715055/ANDROID/sticker.png";
            picImage.Update();
        }
    }
}
