using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using יצירת_קורות_חיים.Commands;
using יצירת_קורות_חיים.Models;
using System.Globalization;
using System.Xml.Serialization;
using System.IO;
using Meziantou.Framework;
using Microsoft.Extensions.FileProviders;
using יצירת_קורות_חיים.Utils;

namespace יצירת_קורות_חיים.ViewModels
{
    class CreateVC : ViewModelBase
    {
        public ObservableCollection<WorkExperience> WorkExperiences { get; set; }
        public ObservableCollection<ProgrammingProject> ProgrammingProjects { get; set; }
        public ObservableCollection<CustomProgrammingLanguages> CustomProgrammingLanguages { get; set; }
        public ProfessionalKnowledge ProfessionalKnowledge { get; set; }
        public ObservableCollection<CustomIDE> CustomIDEs { get; set; }
        public ObservableCollection<CustomTechnology> CustomTechnologies { get; set; }
        public ObservableCollection<DesignPattern> DesignPatterns { get; set; }
        public ObservableCollection<string> Companies { get; set; }


        private ObservableCollection<object> toSelectIde;

        public ObservableCollection<string> Citys { get; set; }
        public ObservableCollection<string> Schools { get; set; }
        public ObservableCollection<string> Countries { get; set; }

        public ObservableCollection<object> ToSelectIde
        {
            get { return toSelectIde; }
            set
            {
                toSelectIde = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<object> toSelectedItem;
        public ObservableCollection<object> ToSelectedItem
        {
            get { return toSelectedItem; }
            set
            {
                toSelectedItem = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> toSelectedItem1;
        public ObservableCollection<object> ToSelectedItem1
        {
            get { return toSelectedItem1; }
            set
            {
                toSelectedItem1 = value;
                OnPropertyChanged();
            }
        }

        private PersonalInformation personamInformation;

        public PersonalInformation PersonalInformation
        {
            get { return personamInformation; }
            set
            {
                personamInformation = value;
                OnPropertyChanged();
            }
        }

        private Education education;

        public Education Education
        {
            get { return education; }
            set
            {
                education = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand AddWorkExperience { get; set; }
        public RelayCommand AddProject { get; set; }
        public RelayCommand RemoveWorkExperience { get; set; }
        public RelayCommand RemovProject { get; set; }

        private string toText;

        public string ToText
        {
            get { return toText; }
            set
            {
                toText = value;
                OnPropertyChanged();
            }
        }
        public  CreateVC()
        {
            PersonalInformation = new PersonalInformation();
            WorkExperiences = new ObservableCollection<WorkExperience>();
            WorkExperiences.Add(new WorkExperience());
            Education = new Education();
            ProfessionalKnowledge = new ProfessionalKnowledge();
            ProgrammingProjects = new ObservableCollection<ProgrammingProject>();
            CustomProgrammingLanguages = new ObservableCollection<CustomProgrammingLanguages>();
            ToSelectedItem = new ObservableCollection<object>();
            ToSelectedItem1 = new ObservableCollection<object>();
            FillCustomProgrammingLanguages();
            CustomIDEs = new ObservableCollection<CustomIDE>();
            ToSelectIde = new ObservableCollection<object>();
            FillCustomIdes();
            ProgrammingProjects.Add(new ProgrammingProject());
            AddWorkExperience = new RelayCommand(FuncAddWorkExperience);
            RemoveWorkExperience = new RelayCommand(FuncRemoveWorkExperience);
            AddProject = new RelayCommand(FuncAddProject);
            RemovProject = new RelayCommand(FuncRemovProject);
            //Citys = new ObservableCollection<string>();
            GetCountries();
            GetCityFromXml();
            GetSchoolFromXml();
            GetCustomTechnologiesFromXml();
            GetDesignPatternsFromXml();
            GetCompaniesFromXml();
            // GetCompaniesFromXmlAsync();
        }

        //void GwtGenricDataFromXml<T1 , T2>(string path)
        //{
        //    string file = HelperFile.GetRootPath();
        //    file += path;
        //    XmlSerializer serializer = new XmlSerializer(typeof(List<T2>));
        //    string text = File.ReadAllText(file);
        //    using (StringReader reader = new StringReader(text))
        //    {
        //        var company = (List<T2>)serializer.Deserialize(reader);
        //        Companies = new ObservableCollection<T2>(company.ToList());
        //    }
        //}

        private void GetCompaniesFromXml()
        {
            string file = HelperFile.GetRootPath();
            file += "/Data/Company.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Companys));
            string text = File.ReadAllText(file);
            using (StringReader reader = new StringReader(text))
            {
                var company = (Companys)serializer.Deserialize(reader);
                Companies = new ObservableCollection<string>(company.Company.Select(_ => _.Name + " " + _.NameInEnglish + " " + _.City).ToList());
            }
        }

        private async Task GetCompaniesFromXmlAsync()
        {
            string file = HelperFile.GetRootPath();
            file += "/Data/Company.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Companys));
            string text = await File.ReadAllTextAsync(file);
            await Task.Run(() =>
            {
                using (StringReader reader = new StringReader(text))
                {
                    var company = (Companys)serializer.Deserialize(reader);
                    Companies = new ObservableCollection<string>(company.Company.Select(_ => _.Name + " " + _.NameInEnglish + " " + _.City).ToList());
                }
            });
        }

        private void GetDesignPatternsFromXml()
        {
            string file = HelperFile.GetRootPath();
            file += "/Data/DesignPattern.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(DesignPatterns));
            string text = File.ReadAllText(file);
            using (StringReader reader = new StringReader(text))
            {
                var designPatterns = (DesignPatterns)serializer.Deserialize(reader);
                DesignPatterns = new ObservableCollection<DesignPattern>(designPatterns.DesignPattern.ToList());
            }
        }

        private void GetCustomTechnologiesFromXml()
        {
            string file = HelperFile.GetRootPath();
            file += "/Data/Technology.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Technologies));
            string text = File.ReadAllText(file);
            file = "";
            using (StringReader reader = new StringReader(text))
            {
                var Technologies = (Technologies)serializer.Deserialize(reader);
                foreach (var item in Technologies.Technology)
                {
                    var s1 = item.Image;
                    item.Image = file + @"/Assets/" + s1;
                }
                CustomTechnologies = new ObservableCollection<CustomTechnology>(Technologies.Technology.ToList());
            }
        }

        private void GetSchoolFromXml()
        {
            string file = HelperFile.GetRootPath();
            file += @"/Data/School.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Schools));
            string text = File.ReadAllText(file);
            using (StringReader reader = new StringReader(text))
            {
                var test = (Schools)serializer.Deserialize(reader);
                Schools = new ObservableCollection<string>(test.School.Select(_ => _.Name).ToList());
            }
        }

        private void GetCountries()
        {

            Countries = new ObservableCollection<string>();
            RegionInfo country = new RegionInfo(new CultureInfo("en-US", false).LCID);
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                if (!Countries.Contains(country.DisplayName.ToString()))
                    Countries.Add(country.NativeName.ToString());
            }
        }

        void GetCityFromXml()
        {
            string file = HelperFile.GetRootPath();
            file += @"/Data/Citys.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(CityDada));
            string text = File.ReadAllText(file);
            using (StringReader reader = new StringReader(text))
            {
                var test = (CityDada)serializer.Deserialize(reader);
                Citys = new ObservableCollection<string>(test.ROW.Select(_ => _.שםישוב).ToList());
            }
        }
        private void FillCustomProgrammingLanguages()
        {
            foreach (var item in Enum.GetNames<ProgrammingLanguage>())
            {
                CustomProgrammingLanguages.Add(new CustomProgrammingLanguages(item));
            }
        }

        private void FillCustomIdes()
        {
            foreach (var item in Enum.GetNames<IDE>())
            {
                CustomIDEs.Add(new CustomIDE(item));
            }

        }

        private void FuncRemovProject(object obj)
        {
            var e = obj as ProgrammingProject;
            ProgrammingProjects.Remove(e);
        }

        private void FuncAddProject(object obj)
        {
            ProgrammingProjects.Add(new ProgrammingProject());
        }

        private void FuncRemoveWorkExperience(object obj)
        {
            var e = obj as WorkExperience;
            WorkExperiences.Remove(e);
        }


        private void FuncAddWorkExperience(object obj)
        {
            WorkExperiences.Add(new WorkExperience());
        }

        public override string ToString()
        {
            return "";
        }
    }
}
