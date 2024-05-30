using System;

namespace WpfMVVMAgendaCommands.Exceptions
{
    class AgendaException:ApplicationException
    {
        public AgendaException(string message)
            : base(message)
        {
        }
    }
}
