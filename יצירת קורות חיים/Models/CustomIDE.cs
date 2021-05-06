using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace יצירת_קורות_חיים.Models
{
    [Serializable]
    public class CustomIDE
    {
        public string Ide { get; set; }
        public PackIconKind Icon { get; set; }

        public CustomIDE(string ide)
        {
            Ide = ide;
            Icon = (PackIconKind)Enum.Parse(typeof(PackIconKind), Ide);
        }

    }
}
