﻿using System;
using System.Collections.Generic;
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

namespace DMASS
{
    /// <summary>
    /// Interaktionslogik für AuthorListTabView.xaml
    /// </summary>
    public partial class AuthorListTabView : UserControl
    {
        public AuthorListTabView()
        {
            InitializeComponent();
        }
        
        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AuthorListTabViewModel avm = this.DataContext as AuthorListTabViewModel;
            avm.DoubleClickEvent.Execute(null);
        }
    }
}
