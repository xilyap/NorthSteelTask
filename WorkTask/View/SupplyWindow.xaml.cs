using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для SupplyWindow.xaml
    /// </summary>
    public partial class SupplyWindow : Window
    {
        WorkTaskContext context;
        Provider goodsProvider;
        List<GoodForDatagrid> supplyGoods;
        public SupplyWindow()
        {
            InitializeComponent();
        }
        public SupplyWindow(WorkTaskContext context, Provider provider)
        {
            this.context = context;
            goodsProvider = provider;
            supplyGoods = new List<GoodForDatagrid>();
            InitializeComponent();
        }
        private void SupplyRegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SupplyDatePicker.SelectedDate != null && supplyGoods.Count>0)
            {
                Supply supply = new Supply();
                supply.Date = (DateTime)SupplyDatePicker.SelectedDate;
                supply.Provider = goodsProvider;
                supply.ProviderId = goodsProvider.Id;
                supply.SupplyGoods = supplyGoods.Select(item => item.Good).ToList();
                context.Supplies.Add(supply);
                context.SaveChanges();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Goods.Load();
            GoodsDataGrid.ItemsSource = supplyGoods;
            GoodComboBox.ItemsSource =context.Goods.Local.ToObservableCollection().Where(item => item.ProviderId== goodsProvider.Id);
        }
        private bool isPositiveNumber(string text)
        {
            float res;
            if (float.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
            {
                return res > 0;
            }
            return false;
                 
        }
        private void AddGoodBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GoodComboBox.SelectedItem != null && isPositiveNumber(WeightTextBox.Text) && isPositiveNumber(PriceTextBox.Text))
            {
                SupplyGood good = new SupplyGood();
                good.Price = int.Parse(PriceTextBox.Text);
                good.Weight= int.Parse(WeightTextBox.Text);
                good.Good = (Good)GoodComboBox.SelectedItem;
                good.GoodId = good.Id;
                GoodForDatagrid dgGood = new GoodForDatagrid() { Good = good, Price = good.Price, Title = ((Good)GoodComboBox.SelectedItem).Name, Weight=good.Weight }; 
                supplyGoods.Add(dgGood);
                GoodsDataGrid.Items.Refresh();
            }
        }

        private void SupplyRemoveGoodBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsDataGrid.SelectedIndex != -1)
            {
                supplyGoods.RemoveAt(GoodsDataGrid.SelectedIndex);
                GoodsDataGrid.Items.Refresh();
            }
            
        }
    }
}
