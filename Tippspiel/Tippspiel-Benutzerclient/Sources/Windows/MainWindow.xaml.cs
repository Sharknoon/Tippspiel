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
        public ObservableCollection<BetMessage> Bets { get; set; } = new ObservableCollection<BetMessage>();

        //BettorBindings
        public ObservableCollection<SeasonBettorEntry> Bettors { get; set; } = new ObservableCollection<SeasonBettorEntry>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            MainController.Init(this);
        }


        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            MainController.OnLogin();
            TextBoxUsername.Clear();
        }

        public void FadeOutLoginContent()
        {
            Logo.BeginAnimation(Image.MarginProperty, GetAnimationForMargin(from: 120, to: 10));
            Logo.BeginAnimation(Image.WidthProperty, GetDoubleAnimation(from: 1000, to: 500));
            DoubleAnimation gridFadeOutAnim = GetAnimationForOpacity(fadeIn: false);
            gridFadeOutAnim.Completed += (s, ea) => FadeInMainContent();
            LoginGrid.BeginAnimation(Grid.OpacityProperty, gridFadeOutAnim);
            LoginGrid.BeginAnimation(Grid.MarginProperty, GetAnimationForMargin(MarginSide.Bottom, to: 50));
        }

        public void FadeInLoginContent()
        {
            Logo.BeginAnimation(Image.MarginProperty, GetAnimationForMargin(from: 10, to: 120));
            Logo.BeginAnimation(Image.WidthProperty, GetDoubleAnimation(from: 500, to: 1000));
            LoginGrid.BeginAnimation(Grid.OpacityProperty, GetAnimationForOpacity());
            LoginGrid.BeginAnimation(Grid.MarginProperty, GetAnimationForMargin(MarginSide.Bottom, 50, 0));
        }

        private void FadeInMainContent()
        {
            //Settings & Logout
            GridSettings.BeginAnimation(Grid.OpacityProperty, GetAnimationForOpacity());
            ButtonLogout.BeginAnimation(Button.OpacityProperty, GetAnimationForOpacity());
            //Table
            LabelTable.BeginAnimation(Label.OpacityProperty, GetAnimationForOpacity());
            LabelTable.BeginAnimation(Label.MarginProperty, GetAnimationForMargin(from: 70, to: 100));
            ItemsControlTable.BeginAnimation(ListBox.OpacityProperty, GetAnimationForOpacity());
            ItemsControlTable.BeginAnimation(ListBox.MarginProperty, GetAnimationForMargin(from: 150, to: 180));
            //Bets
            LabelBets.BeginAnimation(Label.OpacityProperty, GetAnimationForOpacity());
            LabelBets.BeginAnimation(Label.MarginProperty, GetAnimationForMargin(from: 70, to: 100));
            ListBoxBets.BeginAnimation(ListBox.OpacityProperty, GetAnimationForOpacity());
            ListBoxBets.BeginAnimation(ListBox.MarginProperty, GetAnimationForMargin(from: 150, to: 180));
            //Bettor
            LabelBettors.BeginAnimation(Label.OpacityProperty, GetAnimationForOpacity());
            LabelBettors.BeginAnimation(Label.MarginProperty, GetAnimationForMargin(from: 70, to: 100));
            ItemsControlBettors.BeginAnimation(ListBox.OpacityProperty, GetAnimationForOpacity());
            ItemsControlBettors.BeginAnimation(ListBox.MarginProperty, GetAnimationForMargin(from: 150, to: 180));
        }

        public void FadeOutMainContent()
        {
            //Settings & Logout
            GridSettings.BeginAnimation(Grid.OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            ButtonLogout.BeginAnimation(Button.OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            //Table
            LabelTable.BeginAnimation(Label.OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            LabelTable.BeginAnimation(Label.MarginProperty, GetAnimationForMargin(from: 100, to: 70));
            ItemsControlTable.BeginAnimation(ListBox.OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            ItemsControlTable.BeginAnimation(ListBox.MarginProperty, GetAnimationForMargin(from: 180, to: 150));
            //Bets
            LabelBets.BeginAnimation(Label.OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            LabelBets.BeginAnimation(Label.MarginProperty, GetAnimationForMargin(from: 100, to: 70));
            ListBoxBets.BeginAnimation(ListBox.OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            ListBoxBets.BeginAnimation(ListBox.MarginProperty, GetAnimationForMargin(from: 180, to: 150));
            //Bettor
            LabelBettors.BeginAnimation(Label.OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            LabelBettors.BeginAnimation(Label.MarginProperty, GetAnimationForMargin(from: 100, to: 70));
            ItemsControlBettors.BeginAnimation(ListBox.OpacityProperty, GetAnimationForOpacity(fadeIn:false));
            ThicknessAnimation anim = GetAnimationForMargin(from: 180, to: 150);
            anim.Completed += (s, ea) => FadeInLoginContent();
            ItemsControlBettors.BeginAnimation(ListBox.MarginProperty, anim);
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

        private bool dragStarted = false;
        private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!dragStarted)
            {
                MatchDayChanged();
            }
        }

        private void Slider_OnDragStarted(object sender, DragStartedEventArgs e)
        {
            this.dragStarted = true;
        }

        private void Slider_OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            MatchDayChanged();
            this.dragStarted = false;
        }

        private void MatchDayChanged()
        {
            MainController.OnMatchDayChanged();
        }

        private void ItemsControlTable_OnMouseEnter(object sender, MouseEventArgs e)
        {
            ItemsControlTable.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Thickness noMargin = new Thickness();
            ItemsControlTable.Padding = noMargin;
        }

        private void ItemsControlTable_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (!ItemsControlTable.ComputedVerticalScrollBarVisibility.Equals(Visibility.Visible)) return;
            ItemsControlTable.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            Thickness margin = new Thickness()
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
            if (!ItemsControlTable.ComputedVerticalScrollBarVisibility.Equals(Visibility.Visible)) return;
            Thickness margin = new Thickness()
            {
                Right = 17
            };
            ItemsControlTable.Padding = margin;
            if (!ItemsControlBettors.ComputedVerticalScrollBarVisibility.Equals(Visibility.Visible)) return;
            ItemsControlBettors.Padding = margin;
        }

        private void ItemsControlBettors_OnMouseEnter(object sender, MouseEventArgs e)
        {
            ItemsControlBettors.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Thickness noMargin = new Thickness();
            ItemsControlBettors.Padding = noMargin;
        }

        private void ItemsControlBettors_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (!ItemsControlBettors.ComputedVerticalScrollBarVisibility.Equals(Visibility.Visible)) return;
            ItemsControlBettors.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            Thickness margin = new Thickness()
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
            
        }

        private void ItemsControlBets_OnMouseLeave(object sender, MouseEventArgs e)
        {
            
        }
    }
}
