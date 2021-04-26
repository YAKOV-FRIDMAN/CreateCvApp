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

namespace יצירת_קורות_חיים.ViewModels
{
    class CreateVC : ViewModelBase
    {
        public ObservableCollection<WorkExperience> WorkExperiences { get; set; }
        public ObservableCollection<ProgrammingProject> ProgrammingProjects { get; set; }
        public ObservableCollection<CustomProgrammingLanguages> CustomProgrammingLanguages { get; set; }
        public ProfessionalKnowledge ProfessionalKnowledge { get; set; }
        public ObservableCollection<CustomIDE> CustomIDEs { get; set; }

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
        public CreateVC()
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

        }

        private void GetSchoolFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Schools));
            string text = File.ReadAllText(@"C:\Users\user1\source\repos\יצירת קורות חיים\יצירת קורות חיים\Data\School.xml");
            using (StringReader reader = new StringReader(text))
            {
                var test = (Schools)serializer.Deserialize(reader);
                Schools = new ObservableCollection<string>(test.School.Select(_=>_.Name).ToList());
            }
        }

        private void GetCountries()
        {

            Countries = new ObservableCollection<string>();
            RegionInfo country = new RegionInfo(new CultureInfo("en-US", false).LCID);

            //To get the Country Names from the CultureInfo installed in windows
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                if (!Countries.Contains(country.DisplayName.ToString()))
                    Countries.Add(country.NativeName.ToString());
            }
        }

        void GetCityFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CityDada));
            string text = File.ReadAllText(@"C:\Users\user1\source\repos\יצירת קורות חיים\יצירת קורות חיים\Data\Citys.xml");
            using (StringReader reader = new StringReader(text))
            {
                var test = (CityDada)serializer.Deserialize(reader);
                //var c =   test.ROW.Where(_ => _.לשכה == "בית שמש ").ToList();
                Citys = new ObservableCollection<string>(test.ROW.Select(_ => _.שםישוב).ToList());
             
            }
        }
        private void FillCustomProgrammingLanguages()
        {
            foreach (var item in Enum.GetNames<ProgrammingLanguage>())
            {
                CustomProgrammingLanguages.Add(new Models.CustomProgrammingLanguages(item));
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
            // Educations.Add(new Education());
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
