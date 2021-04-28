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
		[XmlElement(ElementName = "שםחברה")]
		public string שםחברה { get; set; }
		[XmlElement(ElementName = "שםעיר")]
		public string שםעיר { get; set; }
		[XmlElement(ElementName = "שםבאנגלית")]
		public string שםבאנגלית { get; set; }
	}

	[XmlRoot(ElementName = "Companys")]
	public class Companys
	{
		[XmlElement(ElementName = "Company")]
		public List<Company> Company { get; set; }
	}
}
