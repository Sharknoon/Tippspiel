using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Tippspiel_Benutzerclient.ServiceReference;
using Tippspiel_Benutzerclient.Sources.Controller;

namespace Tippspiel_Benutzerclient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Login-Binding
        public string Username { get; set; } = "";

        //Settings-Bindings
        public ObservableCollection<SeasonMessage> Seasons { get; set; } = new ObservableCollection<SeasonMessage>();
        public SeasonMessage CurrentSeason { get; set; }
        public int CurrentMatchDay { get; set; } = 1;

        //Table-Bindings
        public ObservableCollection<TeamMessage> Teams { get; set; } = new ObservableCollection<TeamMessage>();

        //Bet-Bindings
        public ObservableCollection<BetMessage> Bets { get; set; } = new ObservableCollection<BetMessage>();

        //BettorBindings
        public ObservableCollection<BettorMessage> Bettors { get; set; } = new ObservableCollection<BettorMessage>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            MainController.Init(this);
        }


        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            MainController.OnLogin();
        }

        bool _firstClick = true;
        public void FadeOutLoginContent()
        {
            if (!_firstClick) return;
            _firstClick = false;
            Logo.BeginAnimation(Image.MarginProperty, GetAnimationForMargin(from: 120, to: 10));
            DoubleAnimation imageSmallerAnim = new DoubleAnimation();
            imageSmallerAnim.From = 1000;
            imageSmallerAnim.To = 500;
            Logo.BeginAnimation(Image.WidthProperty, imageSmallerAnim);
            DoubleAnimation gridFadeOutAnim = new DoubleAnimation();
            gridFadeOutAnim.From = 1;
            gridFadeOutAnim.To = 0;
            gridFadeOutAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            gridFadeOutAnim.Completed += (s, ea) => FadeInMainContent();
            LoginGrid.BeginAnimation(Grid.OpacityProperty, gridFadeOutAnim);

            LoginGrid.BeginAnimation(Grid.MarginProperty, GetAnimationForMargin(MarginSide.Bottom, to: 50));
        }

        private void FadeInMainContent()
        {
            //Settings
            GridSettings.BeginAnimation(Grid.OpacityProperty, GetAnimationForOpacity());
            //Table
            LabelTable.BeginAnimation(Label.OpacityProperty, GetAnimationForOpacity());
            LabelTable.BeginAnimation(Label.MarginProperty, GetAnimationForMargin(from: 70, to: 100));
            ListBoxTable.BeginAnimation(ListBox.OpacityProperty, GetAnimationForOpacity());
            ListBoxTable.BeginAnimation(ListBox.MarginProperty, GetAnimationForMargin(from: 150, to: 180));
            //Bets
            LabelBets.BeginAnimation(Label.OpacityProperty, GetAnimationForOpacity());
            LabelBets.BeginAnimation(Label.MarginProperty, GetAnimationForMargin(from: 70, to: 100));
            ListBoxBets.BeginAnimation(ListBox.OpacityProperty, GetAnimationForOpacity());
            ListBoxBets.BeginAnimation(ListBox.MarginProperty, GetAnimationForMargin(from: 150, to: 180));
            //Bettor
            LabelBettors.BeginAnimation(Label.OpacityProperty, GetAnimationForOpacity());
            LabelBettors.BeginAnimation(Label.MarginProperty, GetAnimationForMargin(from: 70, to: 100));
            ListBoxBettors.BeginAnimation(ListBox.OpacityProperty, GetAnimationForOpacity());
            ListBoxBettors.BeginAnimation(ListBox.MarginProperty, GetAnimationForMargin(from: 150, to: 180));
        }

        private enum MarginSide
        {
            Top,
            Bottom,
            Left,
            Right
        }

        private static ThicknessAnimation GetAnimationForMargin(MarginSide side = MarginSide.Top, int from = 0,
            int to = 1, int millis = 500)
        {
            var fromThickness = new Thickness();
            var toThickness = new Thickness();
            switch (side)
            {
                case MarginSide.Top:
                    fromThickness.Top = from;
                    toThickness.Top = to;
                    break;
                case MarginSide.Bottom:
                    fromThickness.Bottom = from;
                    toThickness.Bottom = to;
                    break;
                case MarginSide.Left:
                    fromThickness.Left = from;
                    toThickness.Left = to;
                    break;
                case MarginSide.Right:
                    fromThickness.Right = from;
                    toThickness.Right = to;
                    break;
                default:
                    fromThickness.Top = from;
                    toThickness.Top = to;
                    break;
            }
            return new ThicknessAnimation()
            {
                From = fromThickness,
                To = toThickness,
                BeginTime = new TimeSpan(millis)
            };
        }

        private static DoubleAnimation GetAnimationForOpacity(int millis = 500, bool fadeIn = true)
        {
            if (fadeIn)
            {
                return new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    BeginTime = TimeSpan.FromMilliseconds(millis)
                };
            }
            return new DoubleAnimation
            {
                From = 1,
                To = 0,
                BeginTime = TimeSpan.FromMilliseconds(millis)
            };
        }
    }
}
