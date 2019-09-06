using System;
using Xunit;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using CSharp_GDP1;
namespace XUnitTestGDP
{
    public class UnitTest1
    {
        //string expectedPath = "../../../../expected-output.json";
        //string actualPath = "../../../../Output.json";
        [Fact]
        public void Test1()
        {
            Program.GDP_Calc();
            bool right = false;
            if (File.Exists("../../../expected-output.json"))
            {
                JObject xpctJSON = JObject.Parse("../../../expected-output.json");
                JObject actJSON = JObject.Parse("../../../Output.json");
                right = JToken.DeepEquals(xpctJSON, actJSON);
                Assert.True(right);
            }
        }
        [Fact]
        public void Test2()
        {
            if (!File.Exists("../../../../Output.json"))
            {
                throw new FileNotFoundException(string.Format("Cannot find the file Output.json"));
            }
            if (!File.Exists("../../../../expected-output.json"))
            {
                throw new FileNotFoundException(string.Format("Cannot find the file expected-output.json"));
            }
            if (!File.Exists("../../../../datafile.csv"))
            {
                throw new FileNotFoundException(string.Format("Cannot find the file datafile.csv"));
            }
        }
        [Fact]
        public void Test3()
        {
            bool flag = true;
            if (new FileInfo("../../../../Output.json").Length == 0)
            {
                flag = false;
            }
            Assert.True(flag);
        }
    }
}