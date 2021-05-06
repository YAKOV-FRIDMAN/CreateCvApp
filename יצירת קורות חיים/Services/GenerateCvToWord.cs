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
//using System.Collections.ObjectModel;

namespace יצירת_קורות_חיים.Services
{
    public class GenerateCvToWord
    {
        public string PathToSave { get; }
        public PersonalInformation PersonalInformation { get; set; }
        public Education Education { get; set; }
        public ProfessionalKnowledge ProfessionalKnowledge { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }
        public List<ProgrammingProject> ProgrammingProjects { get; set; }
        public GenerateCvToWord(string pathToSave, PersonalInformation personalInformation, Education education, ProfessionalKnowledge professionalKnowledge , List<WorkExperience> workExperiences , List<ProgrammingProject> programmingProjects)
        {
            PathToSave = pathToSave;
            PersonalInformation = personalInformation;
            Education = education;
            ProfessionalKnowledge = professionalKnowledge;
            WorkExperiences = workExperiences;
            ProgrammingProjects = programmingProjects;
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
                    style.CharacterFormat.FontName = "Segoe UI";
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

                    #region PersonalInformation

                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    paragraph.BreakCharacterFormat.UnderlineStyle = UnderlineStyle.Double;
                    WTextRange textRange = paragraph.AppendText(PersonalInformation.FullName) as WTextRange;
                    textRange.CharacterFormat.FontSize = 14f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Red;
                    textRange.CharacterFormat.Bold = true;


                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText("כתובת: " + PersonalInformation.Adderss + " " + PersonalInformation.Country) as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;

                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText($"נייד: {PersonalInformation.Phone}" ) as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;


                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText(PersonalInformation.Email + " : דואר אלקרטוני") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;

                    if (PersonalInformation.LinkLinkdin != null && PersonalInformation.LinkLinkdin != "" && PersonalInformation.LinkLinkdin != string.Empty)
                    {
                        paragraph = section.AddParagraph();
                        paragraph.ApplyStyle("Normal");
                        paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                        textRange = paragraph.AppendHyperlink(PersonalInformation.LinkLinkdin, "Linkedin", HyperlinkType.WebLink) as WTextRange;
                        textRange.CharacterFormat.FontSize = 12f;
                        textRange.CharacterFormat.FontName = "Segoe UI";
                        textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;
                    }
                    if (PersonalInformation.LinkGitHub != null && PersonalInformation.LinkGitHub != "" && PersonalInformation.LinkGitHub != string.Empty)
                    {
                        paragraph = section.AddParagraph();
                        paragraph.ApplyStyle("Normal");
                        paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                        textRange = paragraph.AppendHyperlink(PersonalInformation.LinkGitHub, "GitHub", HyperlinkType.WebLink) as WTextRange;
                        textRange.CharacterFormat.FontSize = 12f;
                        textRange.CharacterFormat.FontName = "Segoe UI";
                        textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;
                    }
                    if (PersonalInformation.LinkYourSite != null && PersonalInformation.LinkYourSite != "" && PersonalInformation.LinkYourSite != string.Empty)
                    {
                        paragraph = section.AddParagraph();
                        paragraph.ApplyStyle("Normal");
                        paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                        textRange = paragraph.AppendHyperlink(PersonalInformation.LinkYourSite, "YourSite", HyperlinkType.WebLink) as WTextRange;
                        textRange.CharacterFormat.FontSize = 12f;
                        textRange.CharacterFormat.FontName = "Segoe UI";
                        textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;
                    }
                    if (PersonalInformation.LinkFacebook != null && PersonalInformation.LinkFacebook != "" && PersonalInformation.LinkFacebook != string.Empty)
                    {
                        paragraph = section.AddParagraph();
                        paragraph.ApplyStyle("Normal");
                        paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                        textRange = paragraph.AppendHyperlink(PersonalInformation.LinkFacebook, "Facebook", HyperlinkType.WebLink) as WTextRange;
                        textRange.CharacterFormat.FontSize = 12f;
                        textRange.CharacterFormat.FontName = "Segoe UI";
                        textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;
                    }

                    #endregion

                    #region Education

                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText("השכלה מקצועית") as WTextRange;
                    textRange.CharacterFormat.FontSize = 14f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Blue;
                    textRange.CharacterFormat.Bold = true;


                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText(Education.TypeOfStudy + " " + Education.School) as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;

                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText("תחילת לימודים " + Education.Start.ToString("dd/MM/yyyy") + " סיום לימודים " + Education.Finish.ToString("dd/MM/yyyy")) as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;


                    #endregion


                    #region Professional Knowledge 


                    string programmingLanguages = "";
                    foreach (var item in ProfessionalKnowledge.ProgrammingLanguages)
                    {
                        programmingLanguages += ((CustomProgrammingLanguages)item).ProgrammingLanguages + ", ";
                    }

                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText(programmingLanguages + "שפות תכנות ") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;

                    string technologys = "";
                    foreach (var item in ProfessionalKnowledge.Technologys)
                    {
                        technologys += ((CustomTechnology)item).Name + ", ";
                    }

                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText(technologys + "טכנולגיות ") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;

                    string ide = "";
                    foreach (var item in ProfessionalKnowledge.IDEs)
                    {
                        ide += ((CustomIDE)item).Ide + ", ";
                    }

                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText(ide + " סביביות עבודה " ) as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;

                    string designPatterns = "";
                    foreach (var item in ProfessionalKnowledge.DesignPatterns)
                    {
                        designPatterns += ((DesignPattern)item).Name + ", ";
                    }


                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText(designPatterns + " ידע בעבודה במתודולוגיות ") as WTextRange;
                    textRange.CharacterFormat.FontSize = 12f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;

                    #endregion

                    #region WorkExperiences
               

                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText("ניסיון תעסוקתי") as WTextRange;
                    textRange.CharacterFormat.FontSize = 14f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Blue;
                    textRange.CharacterFormat.Bold = true;


                    foreach (var item in WorkExperiences)
                    {
                        paragraph = section.AddParagraph();
                        paragraph.ApplyStyle("Normal");
                        paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                        textRange = paragraph.AppendText(item.Start.Year + "--" + item.Job + " " + item.Role ) as WTextRange;
                        textRange.CharacterFormat.FontSize = 12f;
                        textRange.CharacterFormat.FontName = "Segoe UI";
                        textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;

                    }

                    #endregion


                    paragraph = section.AddParagraph();
                    paragraph.ApplyStyle("Normal");
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    textRange = paragraph.AppendText("פרוייקטים") as WTextRange;
                    textRange.CharacterFormat.FontSize = 14f;
                    textRange.CharacterFormat.FontName = "Segoe UI";
                    textRange.CharacterFormat.TextColor = System.Drawing.Color.Blue;
                    textRange.CharacterFormat.Bold = true;

                    foreach (var item in ProgrammingProjects)
                    {
                        string langua = "";
                        foreach (var item1 in item.ProgrammingLanguges)
                        {
                            langua += ((CustomProgrammingLanguages)item1).ProgrammingLanguages + ", ";
                        }


                        string design = "";
                        foreach (var item1 in item.DesignPatterns)
                        {
                            design += ((DesignPattern)item1).Name + ", ";
                        }

                        string technologys1 = "";
                        foreach (var item1 in item.Technologys)
                        {
                            technologys1 += ((CustomTechnology)item1).Name + ", ";
                        }



                        paragraph = section.AddParagraph();
                        paragraph.ApplyStyle("Normal");
                        paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                        textRange = paragraph.AppendText($"התחלתי את הפרוייקט {item.Descritpion} ב {item.StartProject.ToString("dd/MM/yyyy")} אני הייתי {item.Role} השתמשתי בשפות {langua} בנוי בטכנולוגיה {technologys1} מתוגלוגית עבודה {design} וכן סיימתי את הפרוייקט ב  {item.FinishProject.ToString("dd/MM/yyyy")}") as WTextRange;
                        textRange.CharacterFormat.FontSize = 12f;
                        textRange.CharacterFormat.FontName = "Segoe UI";
                        textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;

                    }


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
