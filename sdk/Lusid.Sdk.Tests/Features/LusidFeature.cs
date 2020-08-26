using System;

namespace Lusid.Sdk.Tests.Features
{
    public sealed class LusidFeature : Attribute
    {
        public LusidFeature(string code)
        {
            Code = code;
        }
        
        public string Code { get; }
    }
}