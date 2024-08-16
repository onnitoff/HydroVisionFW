using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WPF_Design_Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public async Task<List<FilterType>> LoadFilterType()
        {
            using (var context = new Model())
            {
                return await (from first in context.Filters
                              select new FilterType
                              {
                                  Id = first.Id,
                                  Name = first.Name
                              }).ToListAsync();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Task.Run(async () =>
            {
                listBox.ItemsSource = await LoadFilterType();
            }).Wait();
        }
    }
}
