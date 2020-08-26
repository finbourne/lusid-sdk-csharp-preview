using NUnit.Framework;

namespace Lusid.Sdk.Tests.Features.FeatureTests.Dummy.duplicates
{    
    [TestFixture]
    public class DuplicateAttributesTests
    {
        
        [LusidFeature("F1")]
        [Test]
        public void DummyMethod()
        {

        }
        
        [LusidFeature("F1")]
        [Test]
        public void DummyMethod2()
        {

        }
        
        [LusidFeature("F2")]
        [Test]
        public void DummyMethod3()
        {

        }
        
    }
}