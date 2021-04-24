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
        public ObservableCollection<Education> Educations { get; set; }
        public ObservableCollection<ProgrammingProject> ProgrammingProjects { get; set; }
        public ObservableCollection<CustomProgrammingLanguages> CustomProgrammingLanguages { get; set; }
        public ObservableCollection<CustomIDE> CustomIDEs { get; set; }

        private ObservableCollection<object> toSelectIde;

        private ObservableCollection<string> citys;

        public ObservableCollection<string> Citys
        {
            get { return citys; }
            set { citys = value; }
        }

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


        public RelayCommand AddEducation { get; set; }
        public RelayCommand AddProject { get; set; }
        public RelayCommand RemovEducation { get; set; }
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
            //var i = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            //var ii = new RegionInfo(new CultureInfo(i[1].Name, false).LCID);
            PersonalInformation = new PersonalInformation();
            Educations = new ObservableCollection<Education>();
            ProgrammingProjects = new ObservableCollection<ProgrammingProject>();
            CustomProgrammingLanguages = new ObservableCollection<CustomProgrammingLanguages>();
            ToSelectedItem = new ObservableCollection<object>();
            ToSelectedItem1 = new ObservableCollection<object>();
            FillCustomProgrammingLanguages();
            CustomIDEs = new ObservableCollection<CustomIDE>();
            ToSelectIde = new ObservableCollection<object>();
            FillCustomIdes();
            ProgrammingProjects.Add(new ProgrammingProject());
            Educations.Add(new Education());
            AddEducation = new RelayCommand(FuncAddEducation);
            RemovEducation = new RelayCommand(FuncRemoveEducation);
            AddProject = new RelayCommand(FuncAddProject);
            RemovProject = new RelayCommand(FuncRemovProject);
            //Citys = new ObservableCollection<string>();
            GetCityFromXml();
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

        private void FuncRemoveEducation(object obj)
        {
            var e = obj as Education;
            Educations.Remove(e);
            // Educations.Add(new Education());
        }


        private void FuncAddEducation(object obj)
        {
            Educations.Add(new Education());
        }

        public override string ToString()
        {
            return "";
        }
    }
}
