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
using System.Windows.Shapes;

namespace notatnik_
{
    /// <summary>
    /// Logika interakcji dla klasy kolor.xaml
    /// </summary>
    public partial class kolor : Window
    {
        public Color color;
        public kolor()
        {
            InitializeComponent();            
        }

        private void zatwierdzenie(object sender, RoutedEventArgs e)
        {
            color = Color.FromRgb(wejscie(wejscieR), wejscie(wejscieG), wejscie(wejscieB));
            Close();
        }
        byte wejscie(TextBox input)
        {
            if (int.TryParse(input.Text,out int value))
            {
                return (byte)value;
            }
            return 0;
        }
    }
}
