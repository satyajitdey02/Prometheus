using System;

namespace Framework.Constants
{
    public static partial class Constants
    {
        public struct Application
        {
            public struct Path
            {
                public static string BasePath => AppDomain.CurrentDomain.BaseDirectory;
            }
        }
    }
}
