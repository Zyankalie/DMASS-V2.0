using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DMASS
{
    public abstract class Tab : TabItem, ITab 
    {
        public Tab()
        {
            CloseCommand = new ActionCommand(p => CloseRequested?.Invoke(this, EventArgs.Empty));
        }
        public new string Name { get; set; }
        public ICommand CloseCommand { get; }
        public event EventHandler CloseRequested;
    }
}
