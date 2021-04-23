using System.IO;
using Lusid.Sdk.Utilities;

namespace Lusid.Sdk.Tests.Utilities
{
    public class TestLusidApiFactoryBuilder
    {
        public static ILusidApiFactory CreateApiFactory()
        {
            return File.Exists("secret.json")
                ? LusidApiFactoryBuilder.Build("secrets.json")
                : LusidApiFactoryBuilder.Build(null);
        }
    }
}