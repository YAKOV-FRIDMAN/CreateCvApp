using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace יצירת_קורות_חיים.Models
{
    [Serializable]
    public class PersonalInformation
    {
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Adderss { get; set; }
        public string Country { get; set; }
        public string LinkGitHub { get; set; } //= "https://github.com/";
        public string LinkYourSite { get; set; } //= "https://www.google.com/";
        public string LinkLinkdin { get; set; } //= "https://www.linkedin.com/";
        public string LinkFacebook { get; set; } //= "https://www.facebook.com/";

    }
}
