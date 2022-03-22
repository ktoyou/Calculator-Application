using Calculator.Commands;
using Calculator.Models;
using System;
using System.Windows.Input;

namespace Calculator.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public string CurrentNumber
        {
            get => _currentNumber;
            set
            {
                _currentNumber = value;
                OnPropertyChanged(nameof(CurrentNumber));
            }
        }

        public string Expression
        {
            get => _expression;
            set
            {
                _expression = value;
                OnPropertyChanged(nameof(Expression));
            }
        }

        public ICommand EnterNumberCommand { get; set; }

        public ICommand DeleteNumberCommand { get; set; }

        public ICommand ActionCommand { get; set; }

        public ICommand EqualCommand { get; set; }

        public ICommand ClearCommand { get; set; }

        public ICommand SqrtCommand { get; set; }

        public ICommand ClearCurrentNumberCommand { get; set; }

        public MainWindowViewModel()
        {
            EnterNumberCommand = new RelayCommand(obj => CurrentNumber += (string)obj, true);
            ClearCurrentNumberCommand = new RelayCommand(obj => CurrentNumber = null, true);
            DeleteNumberCommand = new RelayCommand(DeleteNumber, true);
            ActionCommand = new RelayCommand(EnterAction, true);
            EqualCommand = new RelayCommand(Equal, true);
            ClearCommand = new RelayCommand(Clear, true);
            SqrtCommand = new RelayCommand(Sqrt, true);
        }

        private void Sqrt(object obj)
        {
            if (CurrentNumber == null) return;
            if (!float.TryParse(CurrentNumber, out _)) return;
            CurrentNumber = Math.Pow(double.Parse(CurrentNumber), 2).ToString();
        }

        private void Clear(object obj)
        {
            CurrentNumber = null;
            Expression = String.Empty;
            _previousNumber = null;
            _currentAction = null;
        }

        private void DeleteNumber(object obj)
        {
            if (CurrentNumber == null || CurrentNumber.Length == 0) return;
            CurrentNumber = CurrentNumber.Substring(0, CurrentNumber.Length - 1);
        }

        private void Equal(object obj)
        {
            if (_previousNumber == null || CurrentNumber == null) return;
            CurrentNumber = _currentAction.Calculate(float.Parse(_previousNumber), float.Parse(_currentNumber)).ToString();
            Expression = String.Empty;
            _previousNumber = null;
            _currentAction = null;
        }

        private void EnterAction(object obj)
        {
            ICalculator action = obj as ICalculator;

            if(_currentAction == null) _currentAction = action;

            if (_currentAction != action)
            {
                Expression = Expression.Replace(_currentAction.GetExpression(), action.GetExpression());
                _currentAction = action;
                return;
            }
            if (CurrentNumber == null || CurrentNumber.Length == 0) return;
            if(!float.TryParse(CurrentNumber, out _)) return;

            if(_previousNumber == null)
            {
                _previousNumber = CurrentNumber;
                Expression = _previousNumber + " " + _currentAction.GetExpression();
                CurrentNumber = null;
            }
        }

        private string _currentNumber;

        private ICalculator _currentAction;

        private string _previousNumber;

        private string _expression;
    }
}
