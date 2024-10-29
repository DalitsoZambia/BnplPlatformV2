using System.Xml.Serialization;

namespace BnplV2.Modules.Messaging;



public class MessageRequest
{
    public string Text { get; set; }
    public string Msisdn { get; set; }
}

[XmlRoot(ElementName="STATUS")]
public class Status { 

    [XmlElement(ElementName="RESPONSECODE")] 
    public int ResponseCode { get; set; } 

    [XmlElement(ElementName="DESCRIPTION")] 
    public string Description { get; set; } 
}

[XmlRoot(ElementName="RESPONSE")]
public class Response { 

    [XmlElement(ElementName="STATUS")] 
    public Status Status { get; set; } 
}

[XmlRoot(ElementName="COMMAND")]
public class SmsResponse { 

    [XmlElement(ElementName="RESPONSE")] 
    public Response Response { get; set; } 
}

