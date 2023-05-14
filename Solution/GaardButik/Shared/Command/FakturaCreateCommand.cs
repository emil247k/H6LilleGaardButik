using GaardButik.Shared.Command.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaardButik.Shared.Command
{
    public class FakturaCreateCommand : ICommand
    {
        public string To { get; set; }

        public string Address { get; set; }

        public ICollection<long> Products { get; set; }
    }
}
