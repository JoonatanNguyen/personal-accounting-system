﻿#pragma checksum "..\..\AdminWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4FA486A4888963F2933F3523E94296C326A692BF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Personal_Accounting_System_WPFApp;
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


namespace Personal_Accounting_System_WPFApp {
    
    
    /// <summary>
    /// AdminWindow
    /// </summary>
    public partial class AdminWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LogOutButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreatePayment;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ViewDailyTransaction;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ViewReport;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowUsers;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowCategory;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame AdminHomePage;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UserEmail;
        
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
            System.Uri resourceLocater = new System.Uri("/Personal_Accounting_System_WPFApp;component/adminwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminWindow.xaml"
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
            this.LogOutButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\AdminWindow.xaml"
            this.LogOutButton.Click += new System.Windows.RoutedEventHandler(this.LogOutButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CreatePayment = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\AdminWindow.xaml"
            this.CreatePayment.Click += new System.Windows.RoutedEventHandler(this.CreatePayment_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ViewDailyTransaction = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\AdminWindow.xaml"
            this.ViewDailyTransaction.Click += new System.Windows.RoutedEventHandler(this.ViewTodaysTransaction_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ViewReport = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\AdminWindow.xaml"
            this.ViewReport.Click += new System.Windows.RoutedEventHandler(this.ViewReport_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ShowUsers = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\AdminWindow.xaml"
            this.ShowUsers.Click += new System.Windows.RoutedEventHandler(this.ShowUsers_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 20 "..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowOtherEntities_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ShowCategory = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\AdminWindow.xaml"
            this.ShowCategory.Click += new System.Windows.RoutedEventHandler(this.ModifyCategory_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AdminHomePage = ((System.Windows.Controls.Frame)(target));
            return;
            case 9:
            this.UserEmail = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

