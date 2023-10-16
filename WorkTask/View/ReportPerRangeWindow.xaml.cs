using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для ReportPerRangeWindow.xaml
    /// </summary>
    public partial class ReportPerRangeWindow : Window
    {
        List<Supply> supplies;
        WorkTaskContext context;
        public ReportPerRangeWindow()
        {
            InitializeComponent();
        }
        public ReportPerRangeWindow(WorkTaskContext context)
        {
            this.context = context;
            context.Supplies.Load();
            context.SupplyGoods.Load();
            InitializeComponent();

        }



        private void DateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FirstDatePicker.SelectedDate != null && SecondDatePicker.SelectedDate != null)
            {
                if (FirstDatePicker.SelectedDate < SecondDatePicker.SelectedDate)
                {
                    supplies = context.Supplies.Include(i => i.Provider).Where(item => FirstDatePicker.SelectedDate <= item.Date && SecondDatePicker.SelectedDate >= item.Date).GroupBy(test => test.ProviderId)
      .Select(grp => grp.First()).ToList();
                    SupplyDataGrid.ItemsSource= supplies;
                    SupplyDataGrid.Items.Refresh();
                }
            }
        }

        private void SupplyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SupplyDataGrid.SelectedItems.Count == 1) { 
                var source = context.Supplies.Include(i => i.Provider)
                    .Where(item => FirstDatePicker.SelectedDate <= item.Date && SecondDatePicker.SelectedDate >= item.Date)
                    .Where(i=>i.ProviderId==((Supply)SupplyDataGrid.SelectedItem).ProviderId).SelectMany(i=>i.SupplyGoods).Include(i=>i.Good).ToList();
                SupplyGoodsDataGrid.ItemsSource = source;
                var weight = source.Sum(i => i.Weight);
                var cost = source.Sum(i=> i.Price);
                SupplyGoodsDataGrid.Items.Refresh();
                SummaryLabel.Content = $"Всего: {weight} кг {cost} рублей";
            }
        }
    }
}
