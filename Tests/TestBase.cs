using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using Util;

namespace Tests
{
    public class TestBase
    {
        public SystemDto System;
        public virtual bool Parallel => true;

        [OneTimeSetUp]
        public void BaseClassInit()
        {
            System = TestController.GetSystemData();
        }
    }
}
