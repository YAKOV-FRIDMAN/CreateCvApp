using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace יצירת_קורות_חיים.Models
{
    [Serializable]
    public class CustomProgrammingLanguages
    {
        public string ProgrammingLanguages { get; set; }
        
        public PackIcon Icon { get; set; } = new PackIcon();
        public CustomProgrammingLanguages(string programmingLanguages)
        {
            ProgrammingLanguages = programmingLanguages;
            if (ProgrammingLanguages == "" || ProgrammingLanguages == null)
                ProgrammingLanguages = "Csharp";
            Icon.Kind = (PackIconKind)Enum.Parse(typeof(PackIconKind), $"Language{ProgrammingLanguages}");
            //Icon.Height = 18;
            //Icon.Width = 16;
            //Icon.HorizontalAlignment = HorizontalAlignment.Center;
            //Icon.VerticalAlignment = VerticalAlignment.Center;
         
        }
    }
     
}
