﻿#pragma checksum "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4BCAA15F9AE594FBAA38F7EFD49E9765"
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
using Tippspiel_Verwaltungsclient.Sources.Windows;
using Xceed.Wpf.Toolkit;


namespace Tippspiel_Verwaltungsclient.Sources.Windows {
    
    
    /// <summary>
    /// MatchEditingWindow
    /// </summary>
    public partial class MatchEditingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonOk;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCancel;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxSeasons;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Slider;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxHomeTeams;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxAwayTeams;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxHomeTeamScore;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextAwayTeamScore;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Tippspiel-Verwaltungsclient;component/sources/windows/matcheditingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ButtonOk = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
            this.ButtonOk.Click += new System.Windows.RoutedEventHandler(this.ButtonOk_OnClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
            this.ButtonCancel.Click += new System.Windows.RoutedEventHandler(this.ButtonCancel_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ComboBoxSeasons = ((System.Windows.Controls.ComboBox)(target));
            
            #line 52 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
            this.ComboBoxSeasons.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxSeasons_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Slider = ((System.Windows.Controls.Slider)(target));
            return;
            case 5:
            this.ComboBoxHomeTeams = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.ComboBoxAwayTeams = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.TextBoxHomeTeamScore = ((System.Windows.Controls.TextBox)(target));
            
            #line 99 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
            this.TextBoxHomeTeamScore.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBoxTeamScore_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TextAwayTeamScore = ((System.Windows.Controls.TextBox)(target));
            
            #line 104 "..\..\..\..\Sources\Windows\MatchEditingWindow.xaml"
            this.TextAwayTeamScore.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBoxTeamScore_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

