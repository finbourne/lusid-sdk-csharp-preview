using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lusid.Sdk.Tests.Features
{

    public static class FeatureExtractor
    {
        private static List<String> GetAttributesFromClassMethods(Type classType)
        {
            LusidFeature att;
            List<String> classAttributes = new List<string>();
 
            MethodInfo[] myMemberInfo = classType.GetMethods();

            // Loop through all methods in this class that are in the
            // MyMemberInfo array.
            foreach (var method in myMemberInfo)
            {
                att = (LusidFeature) Attribute.GetCustomAttribute(method, typeof (LusidFeature));
                
                if (att == null) continue;

                classAttributes.Add(att.Code);
            }
            return classAttributes;
        }
        
        public static List<String> GetAllMethodAttributesInNamespace(string nameSpace)
        {
            Type[] asmTypes = Assembly.GetExecutingAssembly().GetTypes();
            List<String> featureList = new List<string>();
            foreach (Type type in asmTypes)
            {
                if (type.Namespace != null && type.Namespace.ToLower().StartsWith(nameSpace.ToLower()))
                {
                    featureList.AddRange(GetAttributesFromClassMethods(type));
                }
            }
            
            ValidateFeatures(featureList);
    
            return featureList;
        }

        private static void ValidateFeatures(List<string> features)
        {
            int distinctAnnotationsCount = features.Distinct().Count();
            if(distinctAnnotationsCount < features.Count){
                throw new DuplicateFeatureException("LusidFeature annotations with duplicate values have been found. " +
                                                    "Please make sure no LusidFeature annotations duplicates are present.");
            }

            if(features.Contains("")) {
                throw new EmptyFeatureValueException("One of the LusidFeature annotations has not been assigned a value. " +
                                    "Please assign it a value in the form \"[LusidFeature(\"<code-value>\")]");
            }
        }


    }
}