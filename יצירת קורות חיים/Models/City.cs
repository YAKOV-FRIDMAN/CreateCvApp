using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace יצירת_קורות_חיים.Models
{
	[XmlRoot(ElementName = "ROW")]
	public class City
    {
		[XmlElement(ElementName = "טבלה")]
		public string טבלה { get; set; }

		[XmlElement(ElementName = "סמל_ישוב")]
		public int סמלישוב { get; set; }

		[XmlElement(ElementName = "שם_ישוב")]
		public string שםישוב { get; set; }

		[XmlElement(ElementName = "שם_ישוב_לועזי")]
		public string שםישובלועזי { get; set; }

		[XmlElement(ElementName = "סמל_נפה")]
		public int סמלנפה { get; set; }

		[XmlElement(ElementName = "שם_נפה")]
		public string שםנפה { get; set; }

		[XmlElement(ElementName = "סמל_לשכת_מנא")]
		public int סמללשכתמנא { get; set; }

		[XmlElement(ElementName = "לשכה")]
		public string לשכה { get; set; }

		[XmlElement(ElementName = "סמל_מועצה_איזורית")]
		public int סמלמועצהאיזורית { get; set; }

		[XmlElement(ElementName = "שם_מועצה")]
		public object שםמועצה { get; set; }
	}

	[XmlRoot(ElementName = "ROWDATA")]
	public class CityDada
	{

		[XmlElement(ElementName = "ROW")]
		public List<City> ROW { get; set; }
	}

}
