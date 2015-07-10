using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace HomeWeather
{
    class ThingSpeakData
    {
        [JsonProperty(PropertyName = "channel")]
        public ThingSpeakChannel Channel { get; set; }

        [JsonProperty(PropertyName = "feeds")]
        public Collection<ThingSpeakFeed> Feeds { get; set; }
    }
}
