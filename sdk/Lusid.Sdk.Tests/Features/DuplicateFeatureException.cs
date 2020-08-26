using System;

namespace Lusid.Sdk.Tests.Features
{
    public class DuplicateFeatureException : Exception
    {

        public DuplicateFeatureException(string message)
            : base(message)
        {
            
        }
            
        
    }
}