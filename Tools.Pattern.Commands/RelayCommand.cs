namespace Tools.Pattern.Commands
{
    public class RelayCommand : IRelayCommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;
        private readonly Action? _undo;

        public RelayCommand(Action execute, Func<bool>? canExecute = null, Action? undo = null)
        {
            ArgumentNullException.ThrowIfNull(execute, nameof(execute));
            _execute = execute;
            _canExecute = canExecute;
            _undo = undo;
        }

        public void Execute()
        {
            if (CanExecute())
            {
                _execute();

                if(_undo is not null)
                {
                    Messenger.Instance.Publish(this);
                }
            }
        }

        public bool CanExecute()
        {
            return _canExecute is null ? true : _canExecute();
        }

        public void Undo()
        {
            if (_undo is null)
                throw new InvalidOperationException();

            _undo();
        }
    }
}
