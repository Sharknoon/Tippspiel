﻿#pragma checksum "..\..\..\..\Sources\Windows\MatchesWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "63086D11DBC09A1874E125B4C1652341"
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


namespace Tippspiel_Verwaltungsclient.Sources.Windows {
    
    
    /// <summary>
    /// MatchesWindow
    /// </summary>
    public partial class MatchesWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 24 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Slider;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonGenerate;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonImport;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/Tippspiel-Verwaltungsclient;component/sources/windows/matcheswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
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
            this.Slider = ((System.Windows.Controls.Slider)(target));
            
            #line 26 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
            this.Slider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Slider_OnValueChanged);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
            this.Slider.AddHandler(System.Windows.Controls.Primitives.Thumb.DragStartedEvent, new System.Windows.Controls.Primitives.DragStartedEventHandler(this.Slider_OnDragStarted));
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
            this.Slider.AddHandler(System.Windows.Controls.Primitives.Thumb.DragCompletedEvent, new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.Slider_OnDragCompleted));
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonGenerate = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
            this.ButtonGenerate.Click += new System.Windows.RoutedEventHandler(this.ButtonGenerate_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtonImport = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
            this.ButtonImport.Click += new System.Windows.RoutedEventHandler(this.ButtonImport_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ButtonAdd = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
            this.ButtonAdd.Click += new System.Windows.RoutedEventHandler(this.ButtonAdd_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 53 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDelete_OnClick);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 56 "..\..\..\..\Sources\Windows\MatchesWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonEdit_OnClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

