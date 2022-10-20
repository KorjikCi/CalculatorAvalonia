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
            CalcCommand = new DelegateCommand(OnCalc);
            ClearLastCommand = new DelegateCommand(OnClearLastSymbol);
            AllClearCommand = new DelegateCommand(AllClear);
        }

        private void OnCalc()
        {
            DisplayText = "Result";
        }

        private void OnClearLastSymbol()
        {
            if (!string.IsNullOrWhiteSpace(DisplayText))
            {
                DisplayText = DisplayText[..^1];
                //DisplayText = DisplayText.Substring(0, DisplayText.Length - 1);
                if (string.IsNullOrWhiteSpace(DisplayText))
                {
                    AllClear();
                }
            }
        }

        private void AllClear()
        {
            DisplayText = "0";
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
        public ICommand CalcCommand { get; }
        public ICommand ClearLastCommand { get; }
        public ICommand AllClearCommand { get; }
        
        private void SetSymbol(string? parameter)
        {
            if (DisplayText == "0" && IsDigit(parameter)) //Убираем дефолтный ноль с дисплея, когда начинаем вводить символы
            {
                DisplayText = string.Empty;
            }
            
            DisplayText += parameter;
        }

        private static bool IsDigit(string? parameter)
        {
            return int.TryParse(parameter, out var d);
        }
    }
}