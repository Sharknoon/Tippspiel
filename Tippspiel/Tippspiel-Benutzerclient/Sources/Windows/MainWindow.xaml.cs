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
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Tippspiel_Benutzerclient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        ThicknessAnimation bottomGoUpAnim = new ThicknessAnimation()
        {
            From = new Thickness()
            {
                Bottom = 0
            },
            To = new Thickness()
            {
                Bottom = 50
            }
        };
        ThicknessAnimation bottomGoDownAnim = new ThicknessAnimation()
        {
            From = new Thickness()
            {
                Bottom = 50
            },
            To = new Thickness()
            {
                Bottom = 0
            }
        };
        ThicknessAnimation topGoUp = new ThicknessAnimation()
        {
            From = new Thickness()
            {
                Top = 50
            },
            To = new Thickness()
            {
                Top = 100
            }
        };

        bool firstClick = true;
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!firstClick) return;
            firstClick = false;
            ThicknessAnimation imageGoUpAnim = new ThicknessAnimation()
            {
                From = new Thickness()
                {
                    Top = 120
                },
                To = new Thickness()
                {
                    Top = 10
                }
            };
            Logo.BeginAnimation(Image.MarginProperty, imageGoUpAnim);
            DoubleAnimation imageSmallerAnim = new DoubleAnimation();
            imageSmallerAnim.From = 1000;
            imageSmallerAnim.To = 500;
            Logo.BeginAnimation(Image.WidthProperty, imageSmallerAnim);
            DoubleAnimation gridFadeOutAnim = new DoubleAnimation();
            gridFadeOutAnim.From = 1;
            gridFadeOutAnim.To = 0;
            gridFadeOutAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            gridFadeOutAnim.Completed += (s,ea) => FadeInMainContent();
            LoginGrid.BeginAnimation(Grid.OpacityProperty, gridFadeOutAnim);

            LoginGrid.BeginAnimation(Grid.MarginProperty, bottomGoUpAnim);
        }

        private void FadeInMainContent()
        {
            DoubleAnimation fadeInAnim = new DoubleAnimation();
            fadeInAnim.From = 0;
            fadeInAnim.To = 1;
            fadeInAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            LabelBettors.BeginAnimation(Label.OpacityProperty, fadeInAnim);
            LabelBettors.BeginAnimation(Label.MarginProperty, topGoUp);
            LabelBets.BeginAnimation(Label.OpacityProperty, fadeInAnim);
            LabelBets.BeginAnimation(Label.MarginProperty, topGoUp);
            LabelTable.BeginAnimation(Label.OpacityProperty, fadeInAnim);
            LabelTable.BeginAnimation(Label.MarginProperty, topGoUp);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += (s,ea) => { timer.Stop(); FadeInMainContent2(); };
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }

        private void FadeInMainContent2()
        {
            
        }
    }
}
