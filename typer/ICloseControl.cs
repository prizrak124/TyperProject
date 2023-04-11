using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Typer
{
    public delegate void GoBack();
    public interface ICloseControl
    {
        event GoBack GoBackEvent;
    }
}
