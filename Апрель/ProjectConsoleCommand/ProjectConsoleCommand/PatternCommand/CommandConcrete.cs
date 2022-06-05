using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConsoleCommand.PatternCommand
{
    /// <summary>
    /// 4) шаг - конкретная команда
    /// "на вычисление зарплаты"
    /// </summary>
    public class CommandConcrete : CommandBase
    {
        private readonly Receiver _receiver;

        public CommandConcrete(Receiver receiver)
        {
            _receiver = receiver;
        }

        public override void Execute()
        {
            _receiver.CalculateSalary();
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
