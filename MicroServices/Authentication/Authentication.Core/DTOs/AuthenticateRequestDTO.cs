using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Authentication.Core.DTOs
{
    [Serializable]
    public class AuthenticateRequestDTO
    {
        [JsonProperty("userName")]
        [Required]
        public string UserName { get; set; }

        [JsonProperty("password")]
        [Required]
        public byte[] Password { get; set; }

        [JsonProperty("isRemember")]
        public bool IsRemember { get; set; }
    }
}
