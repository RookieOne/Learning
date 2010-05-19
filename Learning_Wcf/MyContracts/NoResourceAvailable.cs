using System.Runtime.Serialization;

namespace MyContracts
{
    [DataContract]
    public class NoResourceAvailable
    {
        [DataMember]
        public string Reason { get; set; }
    }
}