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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WorkTaskContext context;
        public MainWindow()
        {
            context = new WorkTaskContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            InitializeComponent();
        }

        private void GetSupplyBtn_Click(object sender, RoutedEventArgs e)
        {
            //SupplyWindow window = new SupplyWindow();
            SelectProviderWindow window = new SelectProviderWindow(context);
            window.Show();
        }

        private void SupplyReportBtn_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow window = new ReportWindow(context);
            window.Show();
        }
    }
}
