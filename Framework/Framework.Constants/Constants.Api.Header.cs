using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Framework.Constants
{
    public static partial class Constants
    {
        public struct HttpRequestHeader
        {
            public struct ApiVersion
            {
                public static string Header => "sf-api-version";

                public static Dictionary<string, string> ApiVersion11 => new Dictionary<string, string>
                {
                    {
                        Header, "1.1"
                    }
                };
            }
        }
    }
}
