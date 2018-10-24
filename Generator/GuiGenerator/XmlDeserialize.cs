using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace GuiGenerator
{
    public class XmlDeserialize
    {
		/// <summary>
		/// XML文件反序列化
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="xmlFile"></param>
		/// <returns></returns>
		public static object DeserializeFile<T>(string xmlFile)
		{
			try
			{
				using (StreamReader sr = new StreamReader(xmlFile))
				{
					XmlSerializer xmldes = new XmlSerializer(typeof(T));
					return xmldes.Deserialize(sr);
				}
			}
			catch (Exception ex)
			{
				return null;
			}
		}

    }
}
