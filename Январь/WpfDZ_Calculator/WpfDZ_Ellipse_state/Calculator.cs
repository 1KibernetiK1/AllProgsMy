using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDZ_Ellipse_state
{
    public class Calculator : IState
    {
        public bool UIBe { get; set; }

        private TextBox BoxNumber1;
        private TextBox BoxNumber2;
        private TextBlock _block;
        private Button _buttonClose;
        private Button _buttonAdd;
        private Button _buttonSubtract;
        private Button _buttonMultiply;
        private Button _buttonDivide;
        private Button _buttonClear;
        private Button _buttonClearLastLetter;
        private Grid _UI;
        private MainWindow _mainWindow;
        private int firstNumber;
        private int secondNumber;
        private int total;
        

        public Calculator(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        private void SetGridCell(UIElement uiElement, int row, int col)
        {
            Grid.SetColumn(uiElement, col);
            Grid.SetRow(uiElement, row);
        }

        protected void CreateUI()
        {
            UIBe = true;
            _UI = new Grid();
            _UI.RowDefinitions.Add(new RowDefinition());
            _UI.RowDefinitions.Add(new RowDefinition());
            _UI.RowDefinitions.Add(new RowDefinition());

            _UI.ColumnDefinitions.Add(new ColumnDefinition());
            _UI.ColumnDefinitions.Add(new ColumnDefinition());
            _UI.ColumnDefinitions.Add(new ColumnDefinition());

            _UI.ColumnDefinitions[0].Width = new GridLength(10);
            _UI.ColumnDefinitions[1].Width = new GridLength(240);
            _UI.ColumnDefinitions[2].Width = new GridLength(150);

            _UI.RowDefinitions[0].Height = new GridLength(25);
            _UI.RowDefinitions[1].Height = new GridLength(40);
            _UI.RowDefinitions[2].Height = new GridLength(30);
            SetCalc();


        }

        private void SetCalcName()
        {
            Border CalcNameBorder = new Border();
            _UI.Children.Add(CalcNameBorder);
            SetGridCell(CalcNameBorder, 0, 1);
            TextBlock CalcName = new TextBlock();
            CalcNameBorder.BorderBrush = Brushes.DarkGray;
            CalcName.Text = "Калькулятор";
            CalcName.Background = Brushes.Honeydew;
            CalcName.FontSize = 20;
            CalcName.Width = 220;
            CalcName.Height = 25;
            CalcName.HorizontalAlignment = HorizontalAlignment.Left;
            CalcName.VerticalAlignment = VerticalAlignment.Center;
            CalcName.TextAlignment = TextAlignment.Center;
            CalcNameBorder.Child = CalcName;
        }


        private void SetNumber1()
        {
            BoxNumber1 = new TextBox
            {
                FontSize = 20,
                Text = "",
                Background = Brushes.Beige,
                Width = 90,
                Height = 40,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            _UI.Children.Add(BoxNumber1);
            SetGridCell(BoxNumber1, 1, 1);
        }

        private void SetNumber2()
        {
            BoxNumber2 = new TextBox
            {
                FontSize = 20,
                Text = "",
                Background = Brushes.Beige,
                Width = 90,
                Height = 40,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            _UI.Children.Add(BoxNumber2);
            SetGridCell(BoxNumber2, 1, 1);
        }

        private void result()
        {
            _block = new TextBlock
            {
                FontSize = 20,
                Name = "Результат",
                Background = Brushes.DarkGray,
                Width = 100,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center
            };
            _UI.Children.Add(_block);
            SetGridCell(_block, 1, 1);
        }

        private void SetCalcButtonClose()
        {
            _buttonClose = new Button
            {
                Content = "X",
                Height = 25,
                Width = 20,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center
            };
            _UI.Children.Add(_buttonClose);
            SetGridCell(_buttonClose, 0, 1);
            _buttonClose.Click += _buttonClose_Click;
        }

        private void _buttonClose_Click(object sender, RoutedEventArgs e) => _mainWindow.Close();

        private void SetCalcButtons()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            _UI.Children.Add(stackPanel);
            SetGridCell(stackPanel, 2, 1);
            SetCalcButtonAdd();
            stackPanel.Children.Add(_buttonAdd);
            SetCalcButtonSubtract();
            stackPanel.Children.Add(_buttonSubtract);
            SetCalcButtonMultiply();
            stackPanel.Children.Add(_buttonMultiply);
            SetCalcButtonDivide();
            stackPanel.Children.Add(_buttonDivide);
            SetCalcButtonClear();
            stackPanel.Children.Add(_buttonClear);
            SetCalcButtonClearLastLetter();
            stackPanel.Children.Add(_buttonClearLastLetter);

        }

        private void SetCalcButtonSubtract()
        {
            _buttonSubtract = new Button
            {
                Content = "-",
                Width = 40,
                Height = 30
            };
            SetGridCell(_buttonSubtract, 2, 1);
            _buttonSubtract.Click += _buttonSubtract_Click;
        }

        private void _buttonSubtract_Click(object sender, RoutedEventArgs e) => Subtract();

        public void Subtract()
        {
            firstNumber = Convert.ToInt32(BoxNumber1.Text);
            secondNumber = Convert.ToInt32(BoxNumber2.Text);

            total = firstNumber - secondNumber;

            _block.Text = total.ToString();
        }

        private void SetCalcButtonMultiply()
        {
            _buttonMultiply = new Button
            {
                Content = "*",
                Width = 40,
                Height = 30
            };
            SetGridCell(_buttonMultiply, 2, 1);
            _buttonMultiply.Click += _buttonMultiply_Click;
        }

        private void _buttonMultiply_Click(object sender, RoutedEventArgs e) => Multiply();

        public void Multiply()
        {
            firstNumber = Convert.ToInt32(BoxNumber1.Text);
            secondNumber = Convert.ToInt32(BoxNumber2.Text);

            total = firstNumber * secondNumber;

            _block.Text = total.ToString();
        }

        private void SetCalcButtonAdd()
        {
            _buttonAdd = new Button
            {
                Content = "+",
                Width = 40,
                Height = 30
            };
            SetGridCell(_buttonAdd, 2, 1);
            _buttonAdd.Click += _buttonAdd_Click;

        }

        private void _buttonAdd_Click(object sender, RoutedEventArgs e) => Add();

        public void Add()
        {
            firstNumber = Convert.ToInt32(BoxNumber1.Text);
            secondNumber = Convert.ToInt32(BoxNumber2.Text);

            total = firstNumber + secondNumber;

            _block.Text = total.ToString();
        }

        private void SetCalcButtonDivide()
        {
            _buttonDivide = new Button
            {
                Content = "/",
                Width = 40,
                Height = 30
            };
            SetGridCell(_buttonDivide, 2, 1);
            _buttonDivide.Click += _buttonDivide_Click;
        }

        private void _buttonDivide_Click(object sender, RoutedEventArgs e) => Divide();

        public void Divide()
        {
            firstNumber = Convert.ToInt32(BoxNumber1.Text);
            secondNumber = Convert.ToInt32(BoxNumber2.Text);

            double total = (double)firstNumber / secondNumber;

            _block.Text = total.ToString("#.##");
        }

        private void SetCalcButtonClear()
        {
            _buttonClear = new Button
            {
                Content = "C",
                Width = 40,
                Height = 30
            };
            SetGridCell(_buttonClear, 2, 1);
            _buttonClear.Click += _buttonClear_Click;
        }

        private void _buttonClear_Click(object sender, RoutedEventArgs e) => Clear();

        public void Clear() => _block.Text = "";

        private void SetCalcButtonClearLastLetter()
        {
            _buttonClearLastLetter = new Button
            {
                Content = "←",
                Width = 40,
                Height = 30
            };
            SetGridCell(_buttonClearLastLetter, 2, 1);
            _buttonClearLastLetter.Click += _buttonClearLastLetter_Click;
        }

        private void _buttonClearLastLetter_Click(object sender, RoutedEventArgs e) => ClearLastLetter();

        public void ClearLastLetter()
        {
            int lenght = _block.Text.Length - 1;
            string text = _block.Text;
            _block.Text = " ";
            for (int i = 0; i < lenght; i++)
            {
                _block.Text = _block.Text + text[i];
            }
        }

        public Grid UI()
        {
           
            CreateUI();
           
            return _UI;
        }

        protected void SetCalc() => SetCalculateUI();

        private void SetCalculateUI()
        {
            SetCalcButtonClose();
            SetCalcName();
            SetNumber1();
            SetNumber2();
            result();
            SetCalcButtons();
        }

        
    }
}
