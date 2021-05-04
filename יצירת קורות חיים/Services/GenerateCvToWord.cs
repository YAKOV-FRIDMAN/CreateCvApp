using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using יצירת_קורות_חיים.Models;
using System.Windows;

namespace יצירת_קורות_חיים.Services
{
    public class GenerateCvToWord
    {
        public string PathToSave { get; }
        public PersonalInformation PersonalInformation { get; set; }
        public GenerateCvToWord(string pathToSave, PersonalInformation personalInformation)
        {
            PathToSave = pathToSave;
            PersonalInformation = personalInformation;
            Generate();
        }

        void Generate()
        {
            try
            {
                using (WordDocument document = new WordDocument())
                {
                    WSection section = document.AddSection() as WSection;
                    section.PageSetup.Margins.All = 72;
                    section.PageSetup.PageSize = new System.Drawing.SizeF(612, 792);


                    WParagraphStyle style = document.AddParagraphStyle("Normal") as WParagraphStyle;
                    style.CharacterFormat.FontName = "Calibri";
                    style.CharacterFormat.FontSize = 11f;
                    style.ParagraphFormat.BeforeSpacing = 0;
                    style.ParagraphFormat.AfterSpacing = 8;
                    style.ParagraphFormat.LineSpacing = 13.8f;

                    style = document.AddParagraphStyle("Heading 1") as WParagraphStyle;
                    style.ApplyBaseStyle("Normal");
                    style.CharacterFormat.FontName = "Calibri Light";
                    style.CharacterFormat.FontSize = 16f;
                    style.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(46, 116, 181);
                    style.ParagraphFormat.BeforeSpacing = 12;
                    style.ParagraphFormat.AfterSpacing = 0;
                    style.ParagraphFormat.Keep = true;
                    style.ParagraphFormat.KeepFollow = true;
                    style.ParagraphFormat.OutlineLevel = OutlineLevel.Level1;
                    IWParagraph paragraph = section.HeadersFooters.Header.AddParagraph();

                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    paragraph.BreakCharacterFormat.UnderlineStyle = UnderlineStyle.Double;
                    WTextRange textRange = paragraph.AppendText(PersonalInformation.FullName) as WTextRange;
                    textRange.CharacterFormat.FontSize = 14f;
                    textRange.CharacterFormat.FontName = "Calibri";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Red;
                    textRange.CharacterFormat.Bold = true;
                   

                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText("כתובת: " + PersonalInformation.Adderss + " " + PersonalInformation.Country) as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Calibri";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;
                    
                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText("נייד: " + PersonalInformation.Phone) as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Calibri";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;


                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText("דואר אלקטורני: " + PersonalInformation.Email) as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Calibri";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;

                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendHyperlink( PersonalInformation.LinkLinkdin, "Linkedin", HyperlinkType.WebLink) as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Calibri";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;



                    if (true)
                    {
                        document.Save("Hello World.doc");
                        MessageBox.Show("הקובץ נשמר בהצלחה");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
