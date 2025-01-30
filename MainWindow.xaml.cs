using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace notatnik_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string nazwa { get; set; } = "";
        bool wprowadzonoZmiany { get; set; } =false;
        bool motywNocny {  get; set; } =false;
        public string textSize { get; set; } = "10";
        Color black = Color.FromRgb(00, 00, 00);
        Color white = Color.FromRgb(200, 200, 200);
        public Color Buttonfore { get; set; }
        public Color Buttonback { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Buttonfore = black;
            Buttonback = white;
        }

        private void NewFile(object sender, RoutedEventArgs e)
        {
            if (UnsavedContentWarning())
            {
                nazwa = "";
                miejsce.Text = "";
            }
            UpdateWindowName();
        }
        
        private void Zmiana(object sender, RoutedEventArgs e)
        {
            Title = nazwa+ "*";
            wprowadzonoZmiany = true;
            
        }
        private void textSizeChange(object sender, RoutedEventArgs e)
        {
            textSize = textSizeInput.Text;
            if (int.TryParse(textSize,out int size))
            {
                if (size>10&&size<1000)
                {
                    miejsce.FontSize = size;
                }
            }
        }
        private void UpdateWindowName()
        {
            Title = nazwa;
            wprowadzonoZmiany=false;
        }

        bool UnsavedContentWarning()
        {
            if (miejsce.Text==""||!wprowadzonoZmiany)
            {
                return true;
            }
            var result = MessageBox.Show("masz niezapisane zmainy czy chcesz je zapisac?", "Warning", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                File.WriteAllText(nazwa, miejsce.Text);
            }
            else if (result == MessageBoxResult.Cancel)
            {
                return false;
            }
            return true;
        }
        private void Save(object sender, RoutedEventArgs e)
        {
                        
            if (nazwa == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "text file | *.txt";
                if (saveFileDialog.ShowDialog()==true)
                {
                    nazwa = saveFileDialog.FileName;
                    File.WriteAllText(nazwa,miejsce.Text);
                }
                
            }
            else
            {
                File.WriteAllText(nazwa, miejsce.Text);
            }
            UpdateWindowName();
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            if (UnsavedContentWarning())
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "text file | *.txt";
                if (openFileDialog.ShowDialog() == true)
                {
                    nazwa = openFileDialog.FileName;
                    miejsce.Text = File.ReadAllText(openFileDialog.FileName);
                }
                UpdateWindowName();
            }
        }

        private void Motyw(object sender, RoutedEventArgs e)
        {
            if (!motywNocny)
            {
                motywNocny = true;
                miejsce.Foreground = Brushes.Gray;
                miejsce.Background = Brushes.Black;
                textSizeInput.Foreground = Brushes.Gray;
                textSizeInput.Background = Brushes.Black;
                window.Background = Brushes.Black;
                menu.Background = Brushes.Black;
                menu.Foreground = Brushes.White; 
                menu2.Background = Brushes.Black;
                menu2.Foreground = Brushes.White;
                Buttonback = black;
                Buttonfore = white;
            }
            else
            {
                motywNocny = false;
                miejsce.Foreground = Brushes.Black;
                miejsce.Background = Brushes.White;
                textSizeInput.Foreground = Brushes.Black;
                textSizeInput.Background = Brushes.White;
                window.Background = Brushes.White;
                menu.Background = Brushes.White;
                menu.Foreground = Brushes.Black;
                menu2.Background = Brushes.White;
                menu2.Foreground = Brushes.Black;
                Buttonback = white;
                Buttonfore = black;
            }
        }

        private void InfoApp(object sender, RoutedEventArgs e)
        {
            InfoApp infoApp = new InfoApp();
            infoApp.Show();
        }

        private void InfoAutor(object sender, RoutedEventArgs e)
        {
            InfoAutor infoApp = new InfoAutor();
            infoApp.ShowDialog();

        }

        private void Kolor(object sender, RoutedEventArgs e)
        {
            kolor color = new kolor();
            color.ShowDialog();
            miejsce.Foreground = new SolidColorBrush(color.color);
        }
        private void Styl(object sender, RoutedEventArgs e)
        {
            Styl styl = new Styl();
            styl.ShowDialog();
            miejsce.FontStyle = styl.styl;
            miejsce.FontWeight = styl.grubosc;
        }
    }
}