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
    /// Logika interakcji dla klasy Styl.xaml
    /// </summary>
    
    public partial class Styl : Window
    {
        public FontStyle styl { get; set; }
        public FontWeight grubosc { get; set; }
        public Styl()
        {
            InitializeComponent();
        }

        private void Zatwiedz(object sender, RoutedEventArgs e)
        {
            switch (style.SelectedIndex)
            {
                case 0:
                    styl = FontStyles.Normal;
                    grubosc = FontWeights.Normal;
                    break;
                case 1:
                    styl = FontStyles.Italic;
                    grubosc = FontWeights.Normal;
                    break;
                case 2:
                    styl = FontStyles.Normal;
                    grubosc = FontWeights.Bold;
                    break;
                case 3:
                    styl = FontStyles.Italic;
                    grubosc = FontWeights.Bold;
                    break;
                default:
                    styl = FontStyles.Normal;
                    grubosc = FontWeights.Normal;
                    break;
            }
            Close();
        }
    }
}
