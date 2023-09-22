using ComputerMethodsOfFinancialMath.WPF.ViewModels;
using System.Windows.Controls;

namespace ComputerMethodsOfFinancialMath.WPF.Views
{
    public partial class SolutionView : UserControl
    {
        public SolutionView()
        {
            InitializeComponent();
            DataContext = new SolutionViewModel();
        }
    }
}
