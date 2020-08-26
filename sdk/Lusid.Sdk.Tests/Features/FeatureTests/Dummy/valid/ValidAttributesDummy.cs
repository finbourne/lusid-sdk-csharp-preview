using NUnit.Framework;

namespace Lusid.Sdk.Tests.Features.FeatureTests.Dummy.valid
{    
    [TestFixture]
    public class ValidAttributesTests
    {
        
        [LusidFeature("F1")]
        [Test]
        public void DummyMethod()
        {

        }
        
        [LusidFeature("F2")]
        [Test]
        public void DummyMethod2()
        {

        }
        
        [Test]
        public void DummyMethod3()
        {

        }
        
    }
}