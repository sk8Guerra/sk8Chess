﻿#pragma checksum "..\..\sk8ChessPlayer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "108F59B79237DE205DF9AD7448180F07"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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
using sk8Chess;


namespace sk8Chess {
    
    
    /// <summary>
    /// sk8ChessPlayer
    /// </summary>
    public partial class sk8ChessPlayer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\sk8ChessPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Reproductor;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\sk8ChessPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StarMusic;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\sk8ChessPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RouteMusic;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\sk8ChessPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelMusic;
        
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
            System.Uri resourceLocater = new System.Uri("/sk8Chess;component/sk8chessplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\sk8ChessPlayer.xaml"
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
            this.Reproductor = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.StarMusic = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\sk8ChessPlayer.xaml"
            this.StarMusic.Click += new System.Windows.RoutedEventHandler(this.PlayMusic);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RouteMusic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CancelMusic = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\sk8ChessPlayer.xaml"
            this.CancelMusic.Click += new System.Windows.RoutedEventHandler(this.ClosePlayer);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

