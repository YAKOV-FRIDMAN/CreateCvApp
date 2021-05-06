using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace יצירת_קורות_חיים.Models
{
	[Serializable]
	[XmlRoot(ElementName = "Technology")]
	public class CustomTechnology
	{

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "Image")]
		public string Image { get; set; }
	}

	[Serializable]
	[XmlRoot(ElementName = "Technologies")]
	public class Technologies
	{

		[XmlElement(ElementName = "Technology")]
		public List<CustomTechnology> Technology { get; set; }
	}
}
