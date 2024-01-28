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
        private readonly CaculateTopStudentInEachYear _topStudentInEachYear;
        private string _yearSelected;
        public MainWindow()
        {
            _context = new FileCsvContext();
            _topStudentInEachYear = new CaculateTopStudentInEachYear();
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
            _yearSelected = cbYear.SelectedItem.ToString();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(_yearSelected, out int selectedYear))
            {
                var loadDataA = _topStudentInEachYear.CaculateValedictorianWithBlockA(selectedYear);
                var loadDataB = _topStudentInEachYear.CaculateValedictorianWithBlockB(selectedYear);
                var loadDataC = _topStudentInEachYear.CaculateValedictorianWithBlockC(selectedYear);
                var loadDataD1 = _topStudentInEachYear.CaculateValedictorianWithBlockD1(selectedYear);
                var loadDataA1 = _topStudentInEachYear.CaculateValedictorianWithBlockA1(selectedYear);

                var combinedData = loadDataA.Concat(loadDataB).Concat(loadDataC).Concat(loadDataD1).Concat(loadDataA1).ToList();
                listData.ItemsSource = combinedData;
                MessageBox.Show("The students of " + selectedYear + " have been shown!");
            }
            else
            {
                MessageBox.Show("Invalid year selected.");
            }
        }
    }
}