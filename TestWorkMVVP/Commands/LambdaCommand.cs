using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkMVVP.Commands.Base;

namespace TestWorkMVVP.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;
        public LambdaCommand(Action<object> Execute, Func<Object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        public override void Execute(object parameter) => _Execute(parameter);

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

    }
}
