using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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

using PRAKTIKA.BASDANDataSetTableAdapters;

namespace PRAKTIKA
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window

    {
        CLINICTableAdapter clinic = new CLINICTableAdapter();
        PATIENTTableAdapter patient = new PATIENTTableAdapter();
        STAFFTableAdapter staff = new STAFFTableAdapter();
        int id2 = 0;
        int room = 0;
        public Window2()

        {
            InitializeComponent();
            BASDANGRID2.ItemsSource = patient.GetData();
            GridCombobox2.ItemsSource = patient.GetData();
            GridCombobox2.DisplayMemberPath = "ROOM_number";
        }

        private void GridCombobox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (GridCombobox2.SelectedItem as DataRowView).Row[0];
            id2 = (int)cell;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            room = Convert.ToInt32(Txtbox2.Text);
            patient.InsertQuery2( id2, room);
            BASDANGRID2.ItemsSource = patient.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
