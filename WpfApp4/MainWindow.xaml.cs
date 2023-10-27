using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Triangle> triangles = new List<Triangle>();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            var targetTextBox = sender as TextBox;
            bool success = double.TryParse(targetTextBox.Text, out double amount);

            if (!success && !string.IsNullOrEmpty(targetTextBox.Text))
            {
                MessageBox.Show("請輸入數字，輸入錯誤");
                targetTextBox.Clear();
            }
            else if (amount <= 0 && !string.IsNullOrEmpty(targetTextBox.Text))
            {
                MessageBox.Show("輸入數值必須大於0，輸入錯誤");
                targetTextBox.Clear();
            }


        }

        private void Botton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textbox1.Text) || string.IsNullOrEmpty(textbox2.Text) || string.IsNullOrEmpty(textbox3.Text))
            {
                MessageBox.Show($"有數值尚未輸入!");
            }
            else
            {
                triangles.Add(new Triangle()
                {
                    Side1 = double.Parse(textbox1.Text),
                    Side2 = double.Parse(textbox2.Text),
                    Side3 = double.Parse(textbox3.Text),
                });


                foreach (var item in triangles)
                {

                    item.Comfirm = item.Side1 + item.Side2 > item.Side3 && item.Side1 + item.Side3 > item.Side2 && item.Side2 + item.Side3 > item.Side1; //判斷是否為三角形的函數

                    textblock.Text = $"你所輸入的三個邊長分別為{item.Side1}, {item.Side2}, {item.Side3}\n";
                    if (item.Comfirm == true)
                    {
                        labelbar.Content = $"邊長{item.Side1},{item.Side2},{item.Side3} 可構成三角形";
                        labelbar.Background = System.Windows.Media.Brushes.Green;
                        textblock.Text += "經過計算後，任意兩邊的和都大於第三邊\n";
                    }
                    else
                    {
                        labelbar.Content = $"邊長{item.Side1},{item.Side2},{item.Side3} 不可構成三角形";
                        labelbar.Background = System.Windows.Media.Brushes.Red;
                        textblock.Text += "經過計算後，有兩邊的和小於第三邊\n";
                    }
                    textblock.Text += $"最終你的所存入的數據分別為:\n邊1 = {item.Side1}  邊2 = {item.Side2}  邊3 = {item.Side3}  布林值為 = {item.Comfirm} ";
                }
            }

        }

        private void result_botton(object sender, RoutedEventArgs e)
        {
            textblock.Text = "";
            for (int i = 0; i < triangles.Count; i++) 
            {
                textblock.Text += $"第{i+1}個三角形: 邊1 = {triangles[i].Side1} 邊2 = {triangles[i].Side2} 邊3 = {triangles[i].Side3} 布林值為 = {triangles[i].Comfirm}\n";
            }
        }
    }
}
