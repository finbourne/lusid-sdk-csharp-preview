using NUnit.Framework;

namespace Lusid.Sdk.Tests.Features.FeatureTests.Dummy.empties
{    
    [TestFixture]
    public class EmptyAttributesTests
    {
        
        [LusidFeature("")]
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