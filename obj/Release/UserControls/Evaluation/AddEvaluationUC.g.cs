﻿#pragma checksum "..\..\..\..\UserControls\Evaluation\AddEvaluationUC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "92D91BEE07B6C97B004C2B7A024C428A83C25A19EA3765484E4DE17E7CB78B43"
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
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using ProjectA.UserControls.Student;
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


namespace ProjectA.UserControls.Evaluation {
    
    
    /// <summary>
    /// AddEvaluationUC
    /// </summary>
    public partial class AddEvaluationUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 176 "..\..\..\..\UserControls\Evaluation\AddEvaluationUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\..\UserControls\Evaluation\AddEvaluationUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTotalMarks;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\..\..\UserControls\Evaluation\AddEvaluationUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTotalWeightage;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\..\..\UserControls\Evaluation\AddEvaluationUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button revertBtn;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\..\..\UserControls\Evaluation\AddEvaluationUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectA;component/usercontrols/evaluation/addevaluationuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\Evaluation\AddEvaluationUC.xaml"
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
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtTotalMarks = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtTotalWeightage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.revertBtn = ((System.Windows.Controls.Button)(target));
            
            #line 197 "..\..\..\..\UserControls\Evaluation\AddEvaluationUC.xaml"
            this.revertBtn.Click += new System.Windows.RoutedEventHandler(this.revertBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.addBtn = ((System.Windows.Controls.Button)(target));
            
            #line 198 "..\..\..\..\UserControls\Evaluation\AddEvaluationUC.xaml"
            this.addBtn.Click += new System.Windows.RoutedEventHandler(this.addBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
