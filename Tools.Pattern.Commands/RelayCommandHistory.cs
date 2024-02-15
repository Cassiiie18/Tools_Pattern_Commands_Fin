using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Pattern.Commands
{
    public class RelayCommandHistory
    {
        private readonly Stack<IRelayCommand> _history = new Stack<IRelayCommand>();

        public IEnumerable<IRelayCommand> History 
        { 
            get {  return _history; } 
        }

        public void Undo()
        {
            if(_history.Count == 0)
            {
                return;
            }

            IRelayCommand command = _history.Pop();
            command.Undo();
        }

        public RelayCommandHistory()
        {
            Messenger.Instance.OnUndoableCommandHandler += _history.Push;
        }
    }
}
