using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Pattern.Commands
{
    internal sealed class Messenger
    {
        public static Messenger Instance = new Messenger();

        public event Action<IRelayCommand>? OnUndoableCommandHandler;

        private Messenger() 
        { 
        }

        public void Publish(IRelayCommand command)
        {
            OnUndoableCommandHandler?.Invoke(command);
        }
    }
}
