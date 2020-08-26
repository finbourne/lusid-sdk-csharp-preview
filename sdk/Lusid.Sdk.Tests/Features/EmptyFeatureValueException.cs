using System;

namespace Lusid.Sdk.Tests.Features
{
    public class EmptyFeatureValueException : Exception
    {

        public EmptyFeatureValueException(string message)
            : base(message)
        {
            
        }
            
        
    }
}