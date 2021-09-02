using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorCommandApp
{
    public class Calculation:INotifyPropertyChanged
    {
        RelayCommand buttonClickObj = null;
        public ICommand ButtonClickObj
        {
            get { return buttonClickObj; }
        }
        RelayCommand resultObj = null;
        public ICommand ResultObj
        {
            get { return resultObj; }
        }
        RelayCommand clearAllObj = null;
        public ICommand ClearAllObj
        {
            get { return clearAllObj; }
        }
        RelayCommand deleteOneObj = null;
        public ICommand DeleteOneObj
        {
            get{ return deleteOneObj; }
        }
        RelayCommand shutdown = null;
        public ICommand Shutdown
        {
            get { return shutdown; }
        }
        public Calculation()
        {
            buttonClickObj = new RelayCommand(ButtonClick);
            resultObj = new RelayCommand(btnResultClick);
            clearAllObj = new RelayCommand(ClearAll);
            deleteOneObj = new RelayCommand(DeleteOne);
            shutdown = new RelayCommand(ShutDown);
        }
        private string operator1;
        private double firstNumber;
        private double secondNumber;
        private string result;
        public string Operator
        {
            get { return operator1; }
            set
            {
                operator1 = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("Input"));
            }
        }
        public double FirstNumber
        {
            get { return firstNumber; }
            set
            {
                firstNumber= value;
                //PropertyChanged(this, new PropertyChangedEventArgs("FirstNumber"));
            }
        }
        public double SecondNumber
        {
            get { return secondNumber; }
            set
            {
                secondNumber = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("SecondNumber"));
            }
        }
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        public void ButtonClick(object sender)//any numeric button click
        {
            
            Result += sender.ToString();
        }
        public void btnResultClick(object sender)//on clicking =
        {
            try
            {
                CalculateResult();
            }
            catch (Exception)
            {
                Result= "Error!";
            }
        }
        public void CalculateResult()
        {
            String op;
            int iOp = 0;
            if (Result.Contains("+"))
            {
                iOp =Result.IndexOf("+");
            }
            else if (Result.Contains("-"))
            {
                iOp = Result.IndexOf("-");
            }
            else if (Result.Contains("*"))
            {
                iOp = Result.IndexOf("*");
            }
            else if (Result.Contains("/"))
            {
                iOp = Result.IndexOf("/");
            }
            else
            {
                //error    
            }

            op = Result.Substring(iOp, 1);
            FirstNumber = Convert.ToDouble(Result.Substring(0, iOp));
            SecondNumber = Convert.ToDouble(Result.Substring(iOp + 1, Result.Length - iOp - 1));

            if (op == "+")
            {
                Result += "=" + (FirstNumber + SecondNumber);
            }
            else if (op == "-")
            {
                Result += "=" + (FirstNumber - SecondNumber);
            }
            else if (op == "*")
            {
                Result += "=" + (FirstNumber * SecondNumber);
            }
            else
            {
                Result += "=" + (FirstNumber / SecondNumber);
            }
        }

        public void ClearAll(object sender)
        {
            Result = "";
        }
        public void DeleteOne(object sender)
        {
            if (Result.Length>0)
            {
                Result = Result.Substring(0, Result.Length - 1);
            }
        }
        public void ShutDown(object sender)
        {
            Application.Current.Shutdown();
        }

    }
}
