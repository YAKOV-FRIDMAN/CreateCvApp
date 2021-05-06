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
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using יצירת_קורות_חיים.Services;
using System.Threading;
using System.Runtime;
using System.Diagnostics;

namespace יצירת_קורות_חיים.ViewModels
{
    [Serializable]
    class CreateVC : ViewModelBase
    {

        private ObservableCollection<WorkExperience> workExperiences;

        public ObservableCollection<WorkExperience> WorkExperiences
        {
            get { return workExperiences; }
            set
            {
                workExperiences = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<ProgrammingProject> programmingProjects;

        public ObservableCollection<ProgrammingProject> ProgrammingProjects
        {
            get { return programmingProjects; }
            set
            {
                programmingProjects = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CustomProgrammingLanguages> CustomProgrammingLanguages { get; set; }

        private ProfessionalKnowledge professionalKnowledge;

        public ProfessionalKnowledge ProfessionalKnowledge
        {
            get { return professionalKnowledge; }
            set
            {
                professionalKnowledge = value;
                OnPropertyChanged();
            }
        }

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
        private int indexPage;
        public int IndexPage
        {
            get { return indexPage; }
            set
            {
                indexPage = value;
                OnPropertyChanged();

                if (indexPage == 6)
                {
                    IsPogresssVisivle = true;
                    FunFinish();
                    LoadWord?.Invoke(null, new EventArgs());
                }
                else
                    IsPogresssVisivle = false;
            }
        }
        private bool isPogresssVisivle;
        public bool IsPogresssVisivle
        {
            get { return isPogresssVisivle; }
            set
            {
                isPogresssVisivle = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand AddWorkExperience { get; set; }
        public RelayCommand AddProject { get; set; }
        public RelayCommand RemoveWorkExperience { get; set; }
        public RelayCommand RemovProject { get; set; }
        public RelayCommand OpenProjectVc { get; set; }
        public RelayCommandAsync OpenProjectVcAsync { get; set; }
        public event EventHandler LoadWord;
        public event EventHandler RefreshPage;

        private int loadBinProgress;

        public int LoadBinProgress
        {
            get { return loadBinProgress; }
            set
            {
                loadBinProgress = value;
                OnPropertyChanged();
            }
        }

        private bool isBus;

        public bool IsBus
        {
            get { return isBus; }
            set
            {
                isBus = value;
                OnPropertyChanged();
            }
        }

        Thread t;
        Thread t2;

        private void Test(object obj)
        {

            GetCityFromXmlAsync();
            GetCityFromXmlAsync();
            GetSchoolFromXmlAsync();
            GetCustomTechnologiesFromXmlAsync();
            GetDesignPatternsFromXml();
            // GetCompaniesFromXml();
            // DeserializeJsonAsync();
            DeserializeAsync();
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect();


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
            OpenProjectVc = new RelayCommand(FunOpenProjctVc);
            OpenProjectVcAsync = new RelayCommandAsync(FunOpenProjctVcAsync);
            //Citys = new ObservableCollection<string>();
            GetCountries();
            t = new Thread(Test);
            t.SetApartmentState(ApartmentState.MTA);
            t.Start();

            //Deserialize();
            // GetCompaniesFromXmlAsync();

            // DeserializeAllVc();

        }

        private async Task FunOpenProjctVcAsync()
        {
            IsBus = true;
            LoadBinProgress = 10;
            //await Task.Run(() =>
            //{
            //});

            Debug.WriteLine("----------befor Deserialize All Vc Async-----------");
            Debug.WriteLine(DateTime.Now.Second + "--" + DateTime.Now.Millisecond);
            DeserializeAllVc();
            // await DeserializeAllVcAsync();
            Debug.WriteLine(DateTime.Now.Second + "--" + DateTime.Now.Millisecond);
            Debug.WriteLine("----------After Deserialize All Vc Async-----------");
            LoadBinProgress = 50;
            Debug.WriteLine("----------befor RefreshPage-----------");
            Debug.WriteLine(DateTime.Now.Second + "--" + DateTime.Now.Millisecond);
            RefreshPage?.Invoke(null, new EventArgs());
            Debug.WriteLine(DateTime.Now.Second + "--" + DateTime.Now.Millisecond);
            Debug.WriteLine("----------After RefreshPage-----------");
            LoadBinProgress = 100;
            IsBus = false;
            Debug.WriteLine("----------befor  GC.Collect()-----------");
            Debug.WriteLine(DateTime.Now.Second + "--" + DateTime.Now.Millisecond);
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect();
            Debug.WriteLine(DateTime.Now.Second + "--" + DateTime.Now.Millisecond);
            Debug.WriteLine("----------After  GC.Collect()-----------");
            //t2 = new Thread(Test2);
            //t2.SetApartmentState(ApartmentState.STA);
            //t2.Start();
            //RefreshPage?.Invoke(null, new EventArgs());

            // await Task.Run(() =>
            // {

            // });

            //await Task.Run(() =>
            //{
            //});



            // await Task.Run(() =>
            //  {

            //  });

        }

        private void Test2(object obj)
        {
            DeserializeAllVcAsync();
            LoadBinProgress = 50;
            //RefreshPage?.Invoke(null, new EventArgs());
            //DeserializeAllVcAsync();
            LoadBinProgress = 100;
            IsBus = false;
        }

        private void FunOpenProjctVc(object obj)
        {
            Task.Run(() =>
            {
                LoadBinProgress = 10;
            });

            DeserializeAllVc();

            Task.Run(() =>
            {
                LoadBinProgress = 50;
            });

            RefreshPage?.Invoke(null, new EventArgs());

            Task.Run(() =>
            {
                LoadBinProgress = 100;
            });
        }

        private void FunFinish()
        {
            SerializeAllVc();

            GenerateCvToWord generateCvToWord = new GenerateCvToWord("", PersonalInformation, Education, ProfessionalKnowledge, WorkExperiences.ToList(), ProgrammingProjects.ToList());
            IsPogresssVisivle = true;
        }

        void SerializeAllVc()
        {
            string filename = Path.Combine(@"Data\", "CreateCv.bin");
            Stream ms = File.OpenWrite(filename);
            BinaryFormatter formatter = new BinaryFormatter();
            var programmingLanguages = ProfessionalKnowledge.ProgrammingLanguages.Select(_ => ((CustomProgrammingLanguages)_).ProgrammingLanguages).ToList();
            TestModel testModel = new TestModel
            {
                Education = Education,
                PersonalInformation = PersonalInformation,
                WorkExperiences = WorkExperiences.ToList()
            };
            testModel.ProfessionalKnowledge.ProgrammingLanguages = new ObservableCollection<object>(programmingLanguages);
            testModel.ProfessionalKnowledge.Technologys = ProfessionalKnowledge.Technologys;
            testModel.ProfessionalKnowledge.IDEs = new ObservableCollection<object>(ProfessionalKnowledge.IDEs.Select(_ => ((CustomIDE)_).Ide).ToList());
            testModel.ProfessionalKnowledge.DesignPatterns = ProfessionalKnowledge.DesignPatterns;


            foreach (var item in ProgrammingProjects)
            {
                testModel.ProgrammingProjects.Add(new ProgrammingProject
                {
                    Descritpion = item.Descritpion,
                    Role = item.Role,
                    StartProject = item.StartProject,
                    FinishProject = item.FinishProject,
                    ProgrammingLanguges = new ObservableCollection<object>(item.ProgrammingLanguges.Select(_ => ((CustomProgrammingLanguages)_).ProgrammingLanguages).ToList()),
                    DesignPatterns = item.DesignPatterns,
                    Technologys = item.Technologys
                });
            }

            formatter.Serialize(ms, testModel);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        void DeserializeAllVc()
        {
            string filename = Path.Combine(@"Data\", "CreateCv.bin");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = File.Open(filename, FileMode.Open);
            object obj = formatter.Deserialize(fs);
            TestModel testModel = (TestModel)obj;
            PersonalInformation = testModel.PersonalInformation;
            Education = testModel.Education;
            WorkExperiences = new ObservableCollection<WorkExperience>(testModel.WorkExperiences);

            foreach (var item in testModel.ProfessionalKnowledge.ProgrammingLanguages)
            {
                ProfessionalKnowledge.ProgrammingLanguages.Add(new CustomProgrammingLanguages((string)item));
            }

            ProfessionalKnowledge.Technologys = testModel.ProfessionalKnowledge.Technologys;

            foreach (var item in testModel.ProfessionalKnowledge.IDEs)
            {
                ProfessionalKnowledge.IDEs.Add(new CustomIDE((string)item));
            }

            ProfessionalKnowledge.DesignPatterns = testModel.ProfessionalKnowledge.DesignPatterns;
            ProgrammingProjects = new ObservableCollection<ProgrammingProject>();
            foreach (var item in testModel.ProgrammingProjects)
            {
                ProgrammingProject programmingProject = new ProgrammingProject();
                programmingProject.Descritpion = item.Descritpion;
                programmingProject.Role = item.Role;
                programmingProject.StartProject = item.StartProject;
                programmingProject.FinishProject = item.FinishProject;

                foreach (var item1 in item.ProgrammingLanguges)
                {
                    programmingProject.ProgrammingLanguges.Add(new CustomProgrammingLanguages((string)item1));
                }
                if (item.Technologys != null)
                {
                    programmingProject.Technologys = new ObservableCollection<object>(item.Technologys);
                }
                programmingProject.DesignPatterns = item.DesignPatterns;



                ProgrammingProjects.Add(programmingProject);
            }


            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

        async Task DeserializeAllVcAsync()
        {
            TestModel testModel = new TestModel();
            await Task.Run(() =>
            {
                string filename = Path.Combine(@"Data\", "CreateCv.bin");
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = File.Open(filename, FileMode.Open);
                object obj = formatter.Deserialize(fs);
                fs.Flush();
                fs.Close();
                fs.Dispose();
                testModel = (TestModel)obj;
                PersonalInformation = testModel.PersonalInformation;
                Education = testModel.Education;
                WorkExperiences = new ObservableCollection<WorkExperience>(testModel.WorkExperiences);
            });

            foreach (var item in testModel.ProfessionalKnowledge.ProgrammingLanguages)
            {
                ProfessionalKnowledge.ProgrammingLanguages.Add(new CustomProgrammingLanguages((string)item));
            }

            ProfessionalKnowledge.Technologys = testModel.ProfessionalKnowledge.Technologys;

            foreach (var item in testModel.ProfessionalKnowledge.IDEs)
            {
                ProfessionalKnowledge.IDEs.Add(new CustomIDE((string)item));
            }
            await Task.Run(() =>
            {
                ProfessionalKnowledge.DesignPatterns = testModel.ProfessionalKnowledge.DesignPatterns;
                ProgrammingProjects = new ObservableCollection<ProgrammingProject>();
            });
            foreach (var item in testModel.ProgrammingProjects)
            {
                ProgrammingProject programmingProject = new ProgrammingProject();
                await Task.Run(() =>
                {
                    programmingProject.Descritpion = item.Descritpion;
                    programmingProject.Role = item.Role;
                    programmingProject.StartProject = item.StartProject;
                    programmingProject.FinishProject = item.FinishProject;
                    programmingProject.DesignPatterns = item.DesignPatterns;
                });

                foreach (var item1 in item.ProgrammingLanguges)
                {
                    programmingProject.ProgrammingLanguges.Add(new CustomProgrammingLanguages((string)item1));
                }
                if (item.Technologys != null)
                {
                    programmingProject.Technologys = new ObservableCollection<object>(item.Technologys);
                }



                ProgrammingProjects.Add(programmingProject);
            }



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
            var fileNew = file + "/Data/CompanyBin.bin";
            file += "/Data/Company.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Companys));
            string text = File.ReadAllText(file);
            using (StringReader reader = new StringReader(text))
            {
                var company = (Companys)serializer.Deserialize(reader);
                //  Serialize(company, fileNew);
                SeralizeJson(company);
                Companies = new ObservableCollection<string>(company.Company.Select(_ => _.Name + " " + _.NameInEnglish + " " + _.City).ToList());
            }
        }


        public static void Serialize(Companys copmp, string filename)
        {
            System.IO.Stream ms = File.OpenWrite(filename);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, copmp);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }
        static void SeralizeJson(Companys copmp)
        {
            string filename = "";//HelperFile.GetRootPath();
                                 //  filename += "/Data/CompanyJson.json";
            filename = Path.Combine(@"Data\", "CompanyJson.json");
            File.WriteAllText(filename, JsonConvert.SerializeObject(copmp));
            using (StreamWriter file = File.CreateText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, copmp);
            }
        }


        async Task DeserializeJsonAsync()
        {
            await Task.Run(() =>
            {
                Debug.WriteLine("----------befor Deserialize Json Async-----------");
                Debug.WriteLine(DateTime.Now.Second + "--" + DateTime.Now.Millisecond);
                string filename = Path.Combine(@"Data\", "CompanyJson.json");
                Task<string> text = File.ReadAllTextAsync(filename);
                var company = JsonConvert.DeserializeObject<Companys>(text.Result);
                Companies = new ObservableCollection<string>(company.Company.Select(_ => _.Name + " " + _.NameInEnglish + " " + _.City).ToList());
                Debug.WriteLine(DateTime.Now.Second + "--" + DateTime.Now.Millisecond);
                Debug.WriteLine("----------after Deserialize Json Async-----------");
            });
        }


        [STAThread]
        public async Task DeserializeAsync()
        {
            await Task.Run(() =>
            {
                Debug.WriteLine("----------befor Deserialize Bin Async-----------");
                Debug.WriteLine(DateTime.Now.Second + "--" + DateTime.Now.Millisecond);
                string filename = HelperFile.GetRootPath();
                filename += "/Data/CompanyBin.bin";
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = File.Open(filename, FileMode.Open);
                object obj = formatter.Deserialize(fs);
                Companys company = (Companys)obj;
                fs.Flush();
                fs.Close();
                fs.Dispose();
                Companies = new ObservableCollection<string>(company.Company.Select(_ => _.Name + " " + _.NameInEnglish + " " + _.City).ToList());
                Debug.WriteLine(DateTime.Now.Second + "--" + DateTime.Now.Millisecond);
                Debug.WriteLine("----------after Deserialize Bin Async-----------");
            });
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

        private async Task GetDesignPatternsFromXml()
        {
            await Task.Run(() =>
            {
                string filename = Path.Combine(@"Data\", "DesignPattern.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(DesignPatterns));
                Task<string> text = File.ReadAllTextAsync(filename);
                using (StringReader reader = new StringReader(text.Result))
                {
                    var designPatterns = (DesignPatterns)serializer.Deserialize(reader);
                    DesignPatterns = new ObservableCollection<DesignPattern>(designPatterns.DesignPattern.ToList());
                }
            });
        }

        private async Task GetCustomTechnologiesFromXmlAsync()
        {
            await Task.Run(() =>
            {
                string filename = Path.Combine(@"Data\", "Technology.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(Technologies));
                Task<string> text = File.ReadAllTextAsync(filename);
                filename = "";
                using (StringReader reader = new StringReader(text.Result))
                {
                    var Technologies = (Technologies)serializer.Deserialize(reader);
                    foreach (var item in Technologies.Technology)
                    {
                        var s1 = item.Image;
                        item.Image = filename + @"/Assets/" + s1;
                    }
                    CustomTechnologies = new ObservableCollection<CustomTechnology>(Technologies.Technology.ToList());
                }
            });
        }

        private async Task GetSchoolFromXmlAsync()
        {
            await Task.Run(() =>
            {
                string filename = Path.Combine(@"Data\", "School.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(Schools));
                Task<string> text = File.ReadAllTextAsync(filename);
                using (StringReader reader = new StringReader(text.Result))
                {
                    var test = (Schools)serializer.Deserialize(reader);
                    Schools = new ObservableCollection<string>(test.School.Select(_ => _.Name).ToList());
                }
            });
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

        async Task GetCityFromXmlAsync()
        {
            await Task.Run(() =>
            {
                string filename = Path.Combine(@"Data\", "Citys.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(CityDada));
                Task<string> text = File.ReadAllTextAsync(filename);
                using (StringReader reader = new StringReader(text.Result))
                {
                    var test = (CityDada)serializer.Deserialize(reader);
                    Citys = new ObservableCollection<string>(test.ROW.Select(_ => _.שםישוב).ToList());
                }
            });
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
