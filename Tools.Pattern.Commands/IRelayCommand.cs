using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Pattern.Commands
{
    public interface IRelayCommand
    {
        void Execute();
        bool CanExecute();
        void Undo();
    }
}
