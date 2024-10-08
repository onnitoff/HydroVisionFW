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
using System.Windows.Shapes;

namespace HydroVisionFW.View
{
    /// <summary>
    /// Логика взаимодействия для MixedActionFilterWindow.xaml
    /// </summary>
    public partial class MixedActionFilterWindow : Window
    {
        public event EventHandler WindowClosed;

        public MixedActionFilterWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            OnWindowClosed();
        }

        protected virtual void OnWindowClosed()
        {
            WindowClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}
