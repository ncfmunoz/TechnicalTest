using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Util
{
    public static class TestController
    {
        public static SystemDto GetSystemData()
        {
            var file = File.OpenRead(Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("Tests\\bin")) + "Util\\TestSettings.json");
            var testSettings = JsonConvert.DeserializeObject<TestSettings>(new StreamReader(file).ReadToEnd());
            return testSettings.System;
        }

    }

    public class TestSettings
    {
        public SystemDto System { get; set; }
    }

    public class SystemDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Headless { get; set; }
        public string ApiUrl { get; set; }
        public string Token { get; set; }
    }
}
