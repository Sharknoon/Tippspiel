using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using Tippspiel_Benutzerclient.Sources.Models;

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
        public ObservableCollection<SeasonTableEntry> Teams { get; set; } = new ObservableCollection<SeasonTableEntry>();

        //Bet-Bindings
        public ObservableCollection<SeasonBetEntry> Bets { get; set; } = new ObservableCollection<SeasonBetEntry>();

        //BettorBindings
        public ObservableCollection<SeasonBettorEntry> Bettors { get; set; } = new ObservableCollection<SeasonBettorEntry>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            MainController.OnLogin();
            TextBoxUsername.Clear();
        }

        public void FadeOutLoginContent()
        {
            Logo.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 120, to: 10));
            Logo.BeginAnimation(WidthProperty, GetDoubleAnimation(from: 1000, to: 500));
            var gridFadeOutAnim = GetAnimationForOpacity(fadeIn: false);
            gridFadeOutAnim.Completed += (s, ea) => FadeInMainContent();
            LoginGrid.BeginAnimation(OpacityProperty, gridFadeOutAnim);
            LoginGrid.BeginAnimation(MarginProperty, GetAnimationForMargin(MarginSide.Bottom, to: 50));
        }

        public void FadeInLoginContent()
        {
            Logo.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 10, to: 120));
            Logo.BeginAnimation(WidthProperty, GetDoubleAnimation(from: 500, to: 1000));
            LoginGrid.BeginAnimation(OpacityProperty, GetAnimationForOpacity());
            LoginGrid.BeginAnimation(MarginProperty, GetAnimationForMargin(MarginSide.Bottom, 50, 0));
        }

        private void FadeInMainContent()
        {
            //Settings & Logout
            GridSettings.BeginAnimation(OpacityProperty, GetAnimationForOpacity());
            ButtonLogout.BeginAnimation(OpacityProperty, GetAnimationForOpacity());
            //Table
            LabelTable.BeginAnimation(OpacityProperty, GetAnimationForOpacity());
            LabelTable.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 70, to: 100));
            ItemsControlTable.BeginAnimation(OpacityProperty, GetAnimationForOpacity());
            ItemsControlTable.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 150, to: 180));
            //Bets
            LabelBets.BeginAnimation(OpacityProperty, GetAnimationForOpacity());
            LabelBets.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 70, to: 100));
            ItemsControlBets.BeginAnimation(OpacityProperty, GetAnimationForOpacity());
            ItemsControlBets.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 150, to: 180));
            ButtonSaveBets.BeginAnimation(OpacityProperty, GetAnimationForOpacity());
            ButtonSaveBets.BeginAnimation(MarginProperty, GetAnimationForMargin(MarginSide.Bottom,40,10));
            //Bettor
            LabelBettors.BeginAnimation(OpacityProperty, GetAnimationForOpacity());
            LabelBettors.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 70, to: 100));
            ItemsControlBettors.BeginAnimation(OpacityProperty, GetAnimationForOpacity());
            ItemsControlBettors.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 150, to: 180));
        }

        public void FadeOutMainContent()
        {
            //Settings & Logout
            GridSettings.BeginAnimation(OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            ButtonLogout.BeginAnimation(OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            //Table
            LabelTable.BeginAnimation(OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            LabelTable.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 100, to: 70));
            ItemsControlTable.BeginAnimation(OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            ItemsControlTable.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 180, to: 150));
            //Bets
            LabelBets.BeginAnimation(OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            LabelBets.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 100, to: 70));
            ItemsControlBets.BeginAnimation(OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            ItemsControlBets.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 180, to: 150));
            ButtonSaveBets.BeginAnimation(OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            ButtonSaveBets.BeginAnimation(MarginProperty, GetAnimationForMargin(MarginSide.Bottom, 10, 40));
            //Bettor
            LabelBettors.BeginAnimation(OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            LabelBettors.BeginAnimation(MarginProperty, GetAnimationForMargin(from: 100, to: 70));
            ItemsControlBettors.BeginAnimation(OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            var anim = GetAnimationForMargin(from: 180, to: 150);
            anim.Completed += (s, ea) => FadeInLoginContent();
            ItemsControlBettors.BeginAnimation(MarginProperty, anim);
        }

        private enum MarginSide
        {
            Top,
            Bottom,
            Left,
            Right
        }

        private static ThicknessAnimation GetAnimationForMargin(MarginSide side = MarginSide.Top, int from = 0,
            int to = 1, int millis = 750)
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
                Duration = TimeSpan.FromMilliseconds(millis)
            };
        }

        private static DoubleAnimation GetAnimationForOpacity(int millis = 750, bool fadeIn = true)
        {
            return fadeIn ? GetDoubleAnimation(millis) : GetDoubleAnimation(millis, 1, 0);
        }

        private static DoubleAnimation GetDoubleAnimation(int millis = 750, int from = 0, int to = 1)
        {
            return new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(millis)
            };
        }

        private bool _dragStarted;
        private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_dragStarted)
                MatchDayChanged();
        }

        private void Slider_OnDragStarted(object sender, DragStartedEventArgs e)
        {
            _dragStarted = true;
        }

        private void Slider_OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            MatchDayChanged();
            _dragStarted = false;
        }

        private void MatchDayChanged()
        {
            MainController.OnMatchDayChanged();
        }

        private void ItemsControlTable_OnMouseEnter(object sender, MouseEventArgs e)
        {
            ItemsControlTable.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            var noMargin = new Thickness();
            ItemsControlTable.Padding = noMargin;
        }

        private void ItemsControlTable_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (!ItemsControlTable.ComputedVerticalScrollBarVisibility.Equals(Visibility.Visible)) return;
            ItemsControlTable.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            var margin = new Thickness()
            {
                Right = 17
            };
            ItemsControlTable.Padding = margin;
        }

        private void ComboBoxSeasons_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainController.OnSeasonChanged();
        }

        public void InitScrollBarPaddings()
        {
            var margin = new Thickness()
            {
                Right = 17
            };
            if (ItemsControlTable.ComputedVerticalScrollBarVisibility.Equals(Visibility.Visible))
            {
                ItemsControlTable.Padding = margin;
            }
            if (ItemsControlBettors.ComputedVerticalScrollBarVisibility.Equals(Visibility.Visible))
            {
                ItemsControlBettors.Padding = margin;
            }
            if (ItemsControlBets.ComputedVerticalScrollBarVisibility.Equals(Visibility.Visible))
            {
                ItemsControlBets.Padding = margin;
            }
        }

        private void ItemsControlBettors_OnMouseEnter(object sender, MouseEventArgs e)
        {
            ItemsControlBettors.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            var noMargin = new Thickness();
            ItemsControlBettors.Padding = noMargin;
        }

        private void ItemsControlBettors_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (!ItemsControlBettors.ComputedVerticalScrollBarVisibility.Equals(Visibility.Visible)) return;
            ItemsControlBettors.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            var margin = new Thickness()
            {
                Right = 17
            };
            ItemsControlBettors.Padding = margin;
        }

        private void ButtonLogout_OnClick(object sender, RoutedEventArgs e)
        {
            MainController.OnLogout();
        }

        private void ItemsControlBets_OnMouseEnter(object sender, MouseEventArgs e)
        {
            ItemsControlBets.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            var noMargin = new Thickness();
            ItemsControlBets.Padding = noMargin;
        }

        private void ItemsControlBets_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (!ItemsControlBets.ComputedVerticalScrollBarVisibility.Equals(Visibility.Visible)) return;
            ItemsControlBets.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            var margin = new Thickness()
            {
                Right = 17
            };
            ItemsControlBets.Padding = margin;
        }

        private void ButtonHometeamUp_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonHometeamDown_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonAwayteamUp_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonAwayteamDown_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonSaveBets_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
