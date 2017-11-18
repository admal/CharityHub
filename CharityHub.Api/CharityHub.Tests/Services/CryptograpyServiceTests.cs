using CharityHub.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CharityHub.Tests.Services
{
    public class CryptograpyServiceTests
    {
        /// <summary>
        /// Test for test
        /// </summary>
        [Fact]
        public void HashTest()
        {
            // Prepare
            var cryptograpyService = new CryptographyService();

            // Act
            var result = cryptograpyService.GetHashString("123123");

            // Asserts
            Assert.Equal("087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a", result);
        }
    }
}
