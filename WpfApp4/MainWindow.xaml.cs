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
using System.Drawing;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Triangle> triangles = new List<Triangle>();
        public MainWindow()
        {
            InitializeComponent();
            //檢查是否為三角形
            trianglesCheck(triangles);

        }

        private bool trianglesCheck(List<Triangle> mytriangles)
        {   
            bool answer = false;
            foreach (var item in mytriangles)
            {
                if ((item.Side1) * (item.Side1)+(item.Side2) * (item.Side2) == item.Side3* item.Side3) answer = true;
                else if ((item.Side1) * (item.Side1)+(item.Side3)*(item.Side3) == item.Side2* item.Side2) answer = true;
                else if ((item.Side2) * (item.Side2)+(item.Side3)*(item.Side3) == item.Side1* item.Side1) answer = true;
                else answer = false;

            }
            return answer;
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
            triangles.Add(new Triangle()
            {
                Side1 = double.Parse(textbox1.Text),
                Side2 = double.Parse(textbox2.Text),
                Side3 = double.Parse(textbox3.Text),
                Comfirm = false
            }) ;





            foreach (var item in triangles)
            {
                item.Comfirm= trianglesCheck(triangles); ; //判斷是否為三角形的函數
                if (item.Comfirm == true)
                {
                    labelbar.Content = $"邊長{item.Side1},{item.Side2},{item.Side3} 可構成三角形";
                    labelbar.Background = System.Windows.Media.Brushes.Green;

                }
                else
                {
                    labelbar.Content = $"邊長{item.Side1},{item.Side2},{item.Side3} 不可構成三角形";
                    labelbar.Background = System.Windows.Media.Brushes.Red;
                }
                
                



            }
        }
    }
}
