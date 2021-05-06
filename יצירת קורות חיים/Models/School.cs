using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace יצירת_קורות_חיים.Models
{
	[Serializable]
	[XmlRoot(ElementName = "School")]
	public class School
	{
		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "Image")]
		public object Image { get; set; }
	}

	[Serializable]
	[XmlRoot(ElementName = "Schools")]
	public class Schools
	{
		[XmlElement(ElementName = "School")]
		public List<School> School { get; set; }
	}
}
