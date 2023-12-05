using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace prpts.Models
{
    public class EmailAttachment
    {
        [JsonProperty("@odata.type")]
        public string odatatype { get; set; }
        public byte[] contentBytes { get; set; }
        public string contentId { get; set; }
        public string contentLocation { get; set; }
        public string contentType { get; set; }
        public string name { get; set; }
    }
}
