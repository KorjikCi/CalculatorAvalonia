using System.Windows.Input;
using Prism.Commands;
using ReactiveUI;

namespace CalculatorAvalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _displayText = "0";

        public MainWindowViewModel()
        {
            SetInputSymbolCommand = new DelegateCommand<string?>(SetSymbol);
        }
        public string DisplayText
        {
            get => _displayText;
            set
            {
                _displayText = value;
                OnPropertyChanged();
            }
        }

        public ICommand SetInputSymbolCommand { get; }
        
        private void SetSymbol(string? parameter)
        {
            DisplayText += parameter;
        }
    }
}