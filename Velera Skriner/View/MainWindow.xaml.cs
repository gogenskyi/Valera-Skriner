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
using Velera_Skriner.ViewModel;

namespace Velera_Skriner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _vm = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;

            Loaded += async (_, __) =>
            {
                await _vm.LoadDataAsync();
            };
        }
    }
}