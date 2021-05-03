using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace יצירת_קורות_חיים.Models
{
	[XmlRoot(ElementName = "Company")]
	public class Company
	{
		public string Name { get; set; }
		public string NameInEnglish { get; set; }
		public string City { get; set; }
	}

	[XmlRoot(ElementName = "ArrayOfCompany")]
	public class Companys
	{
		[XmlElement(ElementName = "Company")]
		public List<Company> Company { get; set; }
	}
}
