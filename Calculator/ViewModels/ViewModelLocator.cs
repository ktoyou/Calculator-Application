using Calculator.Services;

namespace Calculator.ViewModels
{
    internal class ViewModelLocator
    {
        public static ViewModelLocator Instance = new ViewModelLocator();

        public MainWindowViewModel MainWindowViewModel { get; set; } = 
            ServiceProvider.GetViewModel<MainWindowViewModel>() as MainWindowViewModel;
    }
}
