using System;
using api_test.Helpers;
using Xunit;

namespace api_test
{
    public class UnitTest1 : IClassFixture<TestClassFixture>
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1 == 1);
        }
    }
}
