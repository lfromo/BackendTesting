using System.IO;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;

namespace BaseClientProject
{
    public class EndpointXmlResponse<T> : EndpointResponse<T>
    {
        public EndpointXmlResponse(HttpResponseMessage response) : base(response) { }

        public override T GetResponseContent()
        {
            XmlReader _reader = XmlReader.Create(new StringReader(GetResponseRawBodyContent()));
            XmlSerializer _serializer = new XmlSerializer(_responseModel.GetType());
            return (T) _serializer.Deserialize(_reader);
        }
    }
}
