using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace יצירת_קורות_חיים.Models
{
    [Serializable]
    public class TestModel
    {
        public PersonalInformation PersonalInformation { get; set; }
        public Education Education { get; set; }

        public ProfessionalKnowledge ProfessionalKnowledge { get; set; } = new ProfessionalKnowledge();
        public List<WorkExperience> WorkExperiences { get; set; }
        public List<ProgrammingProject> ProgrammingProjects { get; set; } = new List<ProgrammingProject>();
    }
}
