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
using ZooloskiVrt.Server.Main;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        int maxNumber = 0;
        int currentNumber = 0;


        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            Next.IsEnabled = false;
            
        }

        private async Task LoadImage(int imageNumber = 0)
        {
            var comic = await ComicProcessor.LoadCommic(imageNumber);

            if (imageNumber == 0)
            {
                maxNumber = comic.Num;
            }
            currentNumber = comic.Num;

            var source = new Uri(comic.Img, UriKind.Absolute);// absolute jer je to ceo uri, ne samo deo

            pic.Source = new BitmapImage(source);

        }

        private async void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber < maxNumber)
            {
                currentNumber += 1;
                Previous.IsEnabled = true;
                await LoadImage(currentNumber);

                if (currentNumber == maxNumber)
                {
                    Next.IsEnabled = false;
                }
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (currentNumber > 1)
            {
                currentNumber -= 1;
                Next.IsEnabled = true;
                await LoadImage(currentNumber);

                if (currentNumber == 1)
                {
                    Previous.IsEnabled = false;
                }
            }
        }
    }
}
