﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM_PersonDB.View
{
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : Window
    {
        //Die einzigen CodeBehind-Einträge innerhalb der Views dürfen die vorgenerierten Einträge sein (Konstruktor und sämtliche Teile im der anderen
        //Klassendatei (s. partial)
        public StartView()
        {
            InitializeComponent();
        }
    }
}
