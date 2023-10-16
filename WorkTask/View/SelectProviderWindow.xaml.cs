using Microsoft.EntityFrameworkCore;
using System;
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
using WorkTask.Model;

namespace WorkTask.View
{
    /// <summary>
    /// Логика взаимодействия для SelectProviderWindow.xaml
    /// </summary>
    public partial class SelectProviderWindow : Window
    {
        WorkTaskContext context;
        public SelectProviderWindow()
        {
            InitializeComponent();
        }
        public SelectProviderWindow(WorkTaskContext context)
        {
            this.context = context;
            InitializeComponent();
        }
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProviderComboBox.SelectedItem!= null)
            {
                SupplyWindow window= new SupplyWindow(context, (Provider)ProviderComboBox.SelectedItem);
                window.Show();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Providers.Load();
            ProviderComboBox.ItemsSource = context.Providers.Local.ToObservableCollection();
        }
    }
}
