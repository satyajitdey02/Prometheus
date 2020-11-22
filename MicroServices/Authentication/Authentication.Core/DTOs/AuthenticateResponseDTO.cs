using System;
using Authentication.Core.Models;
using Newtonsoft.Json;

namespace Authentication.Core.DTOs
{
    [Serializable]
    public class AuthenticateResponseDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("role")]
        public RoleEnum Role { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("isRemember")]
        public bool IsRemember { get; set; }

        protected AuthenticateResponseDTO(int id, string userName, RoleEnum role, string token, bool isRemember)
        {
            Id = id;
            UserName = userName;
            Role = role;
            Token = token;
            IsRemember = isRemember;
        }

        public static AuthenticateResponseDTO Create(int id, string userName, int roleId, string token, bool isRemember)
        {

            return new AuthenticateResponseDTO(id, userName, (RoleEnum)roleId, token, isRemember);
        }
    }
}
