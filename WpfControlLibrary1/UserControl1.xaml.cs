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

namespace WpfControlLibrary1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        int maxNumber = 0;
        int currentNumber = 0;
        

        public UserControl1()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
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

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }
    }
}
