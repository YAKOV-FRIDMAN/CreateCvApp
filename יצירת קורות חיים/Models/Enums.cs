using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace יצירת_קורות_חיים.Models
{
    public enum Gender
    {
        [Description("נְקֵבָה")]
        [Display(Name = "נְקֵבָה" , Description = "נְקֵבָה" )]
        GenderFemale,
        [Description("זָכָר")]
        GenderMale,
        [Description("זכר נקבה")]
        GenderMaleFemale,
        [Description("משתנה נקבה זכר")]
        GenderMaleFemaleVariant,
        [Description("לא בינארי")]
        GenderNonBinary,
        [Description("אנבי")]
        GenderEnby,
        [Description("טרנסג'נדר")]
        GenderTransgender,
    }

    public enum ProgrammingLanguage
    {
        //CSharp,
        //CPlusPlus,
        //C,
        //Pyton,
        //Java,
        //Kotlin,
        //JavaScript,
        //Assembly,
        //FSharp,
        //Php,
        //Html,
        //Css,
        //Sql,
        //Go,
        //Swift,
        //ObjectiveC,
        //Ruby,
        //VB,
        //COBOL,
        //MySQL
        C,
        Cpp,
        Csharp,
        Css3,
        Fortran,
        Go,
        Haskell,
        Html5,
        Java,
        Javascript,
        Kotlin,
        Lua,
        Markdown,
        MarkdownOutline,
        Php,
        Python,
        R,
        Ruby,
        RubyOnRails,
        Rust,
        Swift,
        Typescript,
        Xaml,
    }
    public enum Technology
    {
     
    }
    public enum DesignPattern
    {

    } 
    public enum IDE
    {
        Microsoft,
        MicrosoftAccess,
        MicrosoftAzure,
        MicrosoftAzureDevops,
        MicrosoftBing,
        MicrosoftDynamics365,
        MicrosoftEdgeLegacy,
        MicrosoftExcel,
        MicrosoftInternetExplorer,
        MicrosoftOffice,
        MicrosoftOnedrive,
        MicrosoftOnenote,
        MicrosoftOutlook,
        MicrosoftPowerpoint,
        MicrosoftSharepoint,
        MicrosoftTeams,
        MicrosoftVisualStudio,
        Visualstudio,
        MicrosoftVisualStudioCode,
        VsCode,
        MicrosoftWindows,
        MicrosoftWindowsClassic,
        MicrosoftWord,
        AndroidStudio,
    }
}
