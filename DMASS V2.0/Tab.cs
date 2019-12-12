using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMASS_V2._0
{
    public abstract class Tab : CustomTab
    {
        public Tab()
        {
            CloseCommand = new ActionCommand(p => CloseRequested?.Invoke(this, EventArgs.Empty));
        }
        public string Name { get; set; }
        public ICommand CloseCommand { get; }

        ICommand CustomTab.CloseCommand => throw new NotImplementedException();

        public event EventHandler CloseRequested;

    }
}
