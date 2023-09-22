using Common.WPF.ViewModels;
using ComputerMethodsOfFinancialMath.WPF.ViewModels;
using System.Windows;

namespace ComputerMethodsOfFinancialMath.WPF;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new SlidebarViewModel().AddNext(new ValueViewModel())
            .AddNext(new SolutionViewModel());
    }
}
