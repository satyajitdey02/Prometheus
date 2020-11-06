﻿using System;
using Newtonsoft.Json;

namespace FlightAction.Core.DTOs
{
    [Serializable]
    public class AirFileDTO
    {
        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("fileBytes")]
        public byte[] FileBytes { get; set; }
    }
}
