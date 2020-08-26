using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Features.FeatureTests
{    
    [TestFixture]
    public class FeatureFileWriterTests
    {

        [Test]
        public void CheckIfFilesWriteCorrectly()
        {
            char sep = Path.DirectorySeparatorChar;
            string fileWriteDirectory = $"{sep}Lusid.Sdk.Tests{sep}Features{sep}FeatureTests{sep}testFeatures.txt";
            string nameSpace = "Lusid.Sdk.Tests.Features.FeatureTests.Dummy.valid";
            FeatureFileWriter ffw = new FeatureFileWriter(fileWriteDirectory);

            List<String> featureList = FeatureExtractor.GetAllMethodAttributesInNamespace(nameSpace);
            string featuresFromMethod = string.Join("\n", featureList);
            ffw.CheckAndRemoveExistingFile();
            ffw.CreateAndWriteFile(featuresFromMethod);
            string featuresFromFile = ffw.ReadFile();

            Assert.AreEqual(featuresFromFile, featuresFromMethod);

        }
        
        [Test]
        public void WriteActualFeaturesToSdkFolder()
        {
            string nameSpace = "Lusid.Sdk.Tests.Tutorials";
            FeatureFileWriter ffw = new FeatureFileWriter("features.txt");

            List<String> featureList = FeatureExtractor.GetAllMethodAttributesInNamespace(nameSpace);
            string featuresFromMethod = string.Join("\n", featureList);
            ffw.CheckAndRemoveExistingFile();
            ffw.CreateAndWriteFile(featuresFromMethod);
            string featuresFromFile = ffw.ReadFile();

            Assert.AreEqual(featuresFromFile, featuresFromMethod);
        }

    }
}