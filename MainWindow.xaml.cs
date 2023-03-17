using System;
using System.Collections.Generic;
using System.Data;
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

using PRAKTIKA.BASDANDataSetTableAdapters;

namespace PRAKTIKA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CLINICTableAdapter clinic = new CLINICTableAdapter();
        PATIENTTableAdapter patient = new PATIENTTableAdapter();
        STAFFTableAdapter staff = new STAFFTableAdapter();

        int id = 0;
        int phone= 0;

        public MainWindow()
        {
            InitializeComponent();
            BASDANGrid.ItemsSource = clinic.GetData();
            GridComboBox.ItemsSource = patient.GetData();
            GridComboBox.DisplayMemberPath = "ROOM_number";
        }

        private void GridComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (GridComboBox.SelectedItem as DataRowView).Row[0];
            id = (int)cell;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int phone = Convert.ToInt32(TxtboxCopy.Text);
            clinic.InsertQuery1(Txtbox.Text,phone ,id);
            BASDANGrid.ItemsSource = clinic.GetData();
            
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Window2 aboba = new Window2();
            aboba.Show();
            this.Close();
        }
    }
}
