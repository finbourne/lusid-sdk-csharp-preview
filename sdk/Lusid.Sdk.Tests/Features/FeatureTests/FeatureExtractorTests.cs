using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Features.FeatureTests
{    
    [TestFixture]
    public class FeatureExtractorTests
    {
        
        [Test]
        public void CheckIfValidFeaturesAreReturnedCorrectly()
        {
            List<string> expectedAttributes = new List<string> {"F1", "F2", "F3", "F4", "F5", "F6"};
            string nameSpace = "Lusid.Sdk.Tests.Features.FeatureTests.Dummy.valid";
            
            List<string> classAttributes = FeatureExtractor.GetAllMethodAttributesInNamespace(nameSpace);

            Assert.That(classAttributes.Count(), Is.EqualTo(6));
            Assert.That(classAttributes, Is.EquivalentTo(expectedAttributes));
        }
        
        [Test]
        public void CheckIfThrowsErrorWithDuplicateFeatureCodes()
        {
            string nameSpace = "Lusid.Sdk.Tests.Features.FeatureTests.Dummy.duplicates";

            Assert.That(
                () => FeatureExtractor.GetAllMethodAttributesInNamespace(nameSpace),
                Throws.InstanceOf<DuplicateFeatureException>().With.Message
                    .EqualTo("LusidFeature annotations with duplicate values have been found. " +
                             "Please make sure no LusidFeature annotations duplicates are present."));
        }
        
        [Test]
        public void CheckIfThrowsErrorWithEmptyStrings()
        {
            string nameSpace = "Lusid.Sdk.Tests.Features.FeatureTests.Dummy.empties";

            Assert.That(
                () => FeatureExtractor.GetAllMethodAttributesInNamespace(nameSpace),
                Throws.InstanceOf<EmptyFeatureValueException>().With.Message
                    .EqualTo("One of the LusidFeature annotations has not been assigned a value. " +
                             "Please assign it a value in the form \"[LusidFeature(\"<code-value>\")]"));
        }
        
        [Test]
        public void CheckIfReturnsEmptyListWithNoAnnotations()
        {
            string nameSpace = "Lusid.Sdk.Tests.Features.FeatureTests.Dummy.notannotated";

            List<string> returnedFeatures = FeatureExtractor.GetAllMethodAttributesInNamespace(nameSpace);

            Assert.That(returnedFeatures, Is.Empty);
        }
        
        

    }
}