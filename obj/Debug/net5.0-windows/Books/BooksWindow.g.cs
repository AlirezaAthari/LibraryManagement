﻿#pragma checksum "..\..\..\..\Books\BooksWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CF49B4EC43738160573A95025ED104B93506E67E"
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
using System.Windows.Controls.Ribbon;
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
using wpf_start.Books;


namespace wpf_start.Books {
    
    
    /// <summary>
    /// BooksWindow
    /// </summary>
    public partial class BooksWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\Books\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Badd;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Books\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bedit;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Books\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bremove;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Books\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BaddBook;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Books\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BmyBooks;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Books\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgList;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Books\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BallBooks;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Books\BooksWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackMembers;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/wpf_start;V1.0.0.0;component/books/bookswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Books\BooksWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\Books\BooksWindow.xaml"
            ((wpf_start.Books.BooksWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.WindowLoad);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Badd = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Books\BooksWindow.xaml"
            this.Badd.Click += new System.Windows.RoutedEventHandler(this.Add);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Bedit = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Books\BooksWindow.xaml"
            this.Bedit.Click += new System.Windows.RoutedEventHandler(this.Edit);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Bremove = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Books\BooksWindow.xaml"
            this.Bremove.Click += new System.Windows.RoutedEventHandler(this.Remove);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BaddBook = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Books\BooksWindow.xaml"
            this.BaddBook.Click += new System.Windows.RoutedEventHandler(this.AddBook);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BmyBooks = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Books\BooksWindow.xaml"
            this.BmyBooks.Click += new System.Windows.RoutedEventHandler(this.MyBooks);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 27 "..\..\..\..\Books\BooksWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Search);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dgList = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            
            #line 39 "..\..\..\..\Books\BooksWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back_Button);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BallBooks = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Books\BooksWindow.xaml"
            this.BallBooks.Click += new System.Windows.RoutedEventHandler(this.WindowLoad);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BackMembers = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\Books\BooksWindow.xaml"
            this.BackMembers.Click += new System.Windows.RoutedEventHandler(this.Members);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

