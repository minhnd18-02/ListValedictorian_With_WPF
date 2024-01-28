using AppData.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListValedictorian_With_DB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FileCsvContext _context;
        public MainWindow()
        {
            _context = new FileCsvContext();
            InitializeComponent();
            LoadYearsOnCombobox();
        }

        private void LoadYearsOnCombobox()
        {
            var year = _context.MarkReports.GroupBy(x => x.Year).Select(x => x.Key).ToList();
            cbYear.ItemsSource = year;
        }
        private void cbYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbYear.SelectedItem == null)
            {
                MessageBox.Show("Please selected year");
            }
            cbYear.SelectedItem.ToString();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            var selectedYear = cbYear.SelectedItem.ToString();
            var loadData = CaculateValedictorianWithBlockA(selectedYear);
            listData.ItemsSource = loadData;
        }

        private List<DataStatistics> CaculateValedictorianWithBlockA(string year)
        {
            var mathScore = _context.MarkReports.Where(x => x.Year.Equals(year)).
                Select(x => new DataStatistics
                {
                    Sbd = x.Sbd,
                    Score01 = x.Toan,
                    Score02 = x.Ly,
                    Score03 = x.Hoa,
                    TotalScore = x.Hoa + x.Ly + x.Toan,
                    Subjects = "Toan, Ly, Hoa"
                }).ToList();

            return mathScore;
        }
    }
}