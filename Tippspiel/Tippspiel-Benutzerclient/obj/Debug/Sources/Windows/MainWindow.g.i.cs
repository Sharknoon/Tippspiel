#pragma checksum "..\..\..\..\Sources\Windows\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2FCB62F509F04F1EBE41FE8AA67D2D08"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Tippspiel_Benutzerclient;


namespace Tippspiel_Benutzerclient
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 24 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridSettings;

#line default
#line hidden


#line 38 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxSeasons;

#line default
#line hidden


#line 56 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Slider;

#line default
#line hidden


#line 67 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonLogout;

#line default
#line hidden


#line 81 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTable;

#line default
#line hidden


#line 84 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer ItemsControlTable;

#line default
#line hidden


#line 147 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelBets;

#line default
#line hidden


#line 155 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelBettors;

#line default
#line hidden


#line 158 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer ItemsControlBettors;

#line default
#line hidden


#line 210 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Logo;

#line default
#line hidden


#line 212 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LoginGrid;

#line default
#line hidden


#line 225 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxUsername;

#line default
#line hidden


#line 228 "..\..\..\..\Sources\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonLogin;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Tippspiel-Benutzerclient;component/sources/windows/mainwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Sources\Windows\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.GridSettings = ((System.Windows.Controls.Grid)(target));
                    return;
                case 2:
                    this.ComboBoxSeasons = ((System.Windows.Controls.ComboBox)(target));

#line 39 "..\..\..\..\Sources\Windows\MainWindow.xaml"
                    this.ComboBoxSeasons.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxSeasons_OnSelectionChanged);

#line default
#line hidden
                    return;
                case 3:
                    this.Slider = ((System.Windows.Controls.Slider)(target));

#line 60 "..\..\..\..\Sources\Windows\MainWindow.xaml"
                    this.Slider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Slider_OnValueChanged);

#line default
#line hidden

#line 60 "..\..\..\..\Sources\Windows\MainWindow.xaml"
                    this.Slider.AddHandler(System.Windows.Controls.Primitives.Thumb.DragStartedEvent, new System.Windows.Controls.Primitives.DragStartedEventHandler(this.Slider_OnDragStarted));

#line default
#line hidden

#line 61 "..\..\..\..\Sources\Windows\MainWindow.xaml"
                    this.Slider.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.Slider_OnDragCompleted));

#line default
#line hidden
                    return;
                case 4:
                    this.ButtonLogout = ((System.Windows.Controls.Button)(target));

#line 68 "..\..\..\..\Sources\Windows\MainWindow.xaml"
                    this.ButtonLogout.Click += new System.Windows.RoutedEventHandler(this.ButtonLogout_OnClick);

#line default
#line hidden
                    return;
                case 5:
                    this.LabelTable = ((System.Windows.Controls.Label)(target));
                    return;
                case 6:
                    this.ItemsControlTable = ((System.Windows.Controls.ScrollViewer)(target));

#line 85 "..\..\..\..\Sources\Windows\MainWindow.xaml"
                    this.ItemsControlTable.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ItemsControlTable_OnMouseEnter);

#line default
#line hidden

#line 86 "..\..\..\..\Sources\Windows\MainWindow.xaml"
                    this.ItemsControlTable.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ItemsControlTable_OnMouseLeave);

#line default
#line hidden
                    return;
                case 7:
                    this.LabelBets = ((System.Windows.Controls.Label)(target));
                    return;
                case 8:
                    this.ListBoxBets = ((System.Windows.Controls.ListBox)(target));
                    return;
                case 9:
                    this.LabelBettors = ((System.Windows.Controls.Label)(target));
                    return;
                case 10:
                    this.ItemsControlBettors = ((System.Windows.Controls.ScrollViewer)(target));

#line 159 "..\..\..\..\Sources\Windows\MainWindow.xaml"
                    this.ItemsControlBettors.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ItemsControlBettors_OnMouseEnter);

#line default
#line hidden

#line 160 "..\..\..\..\Sources\Windows\MainWindow.xaml"
                    this.ItemsControlBettors.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ItemsControlBettors_OnMouseLeave);

#line default
#line hidden
                    return;
                case 11:
                    this.Logo = ((System.Windows.Controls.Image)(target));
                    return;
                case 12:
                    this.LoginGrid = ((System.Windows.Controls.Grid)(target));
                    return;
                case 13:
                    this.TextBoxUsername = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 14:
                    this.ButtonLogin = ((System.Windows.Controls.Button)(target));

#line 231 "..\..\..\..\Sources\Windows\MainWindow.xaml"
                    this.ButtonLogin.Click += new System.Windows.RoutedEventHandler(this.ButtonLogin_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.ScrollViewer ItemsControlBets;
    }
}

