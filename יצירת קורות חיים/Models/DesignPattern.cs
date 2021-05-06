using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace יצירת_קורות_חיים.Models
{
	[Serializable]
	[XmlRoot(ElementName = "DesignPattern")]
	public class DesignPattern
	{

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }
	}

	[Serializable]
	[XmlRoot(ElementName = "DesignPatterns")]
	public class DesignPatterns
	{

		[XmlElement(ElementName = "DesignPattern")]
		public List<DesignPattern> DesignPattern { get; set; }
	}

}
