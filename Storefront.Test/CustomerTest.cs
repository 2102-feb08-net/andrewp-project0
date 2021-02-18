using System;
using Xunit;

namespace Storefront.Test
{
    public class CustomerTest
    {
        [Theory]
        [InlineData("TestFirst", "TestLast", 100)]
        [InlineData("TESTFIRST", "TESTLAST", 100)]
        [InlineData("testfirst", "testlast", 100)]
        public void TestValidCustomerInfo(string first, string last, double balance)
        {
            //Customer customer = new Customer(first, last, balance);
            //Assert.Equal(first.ToLower(), customer.FirstName);
            //Assert.Equal(last.ToLower(), customer.LastName);
        }

        [Theory]
        [InlineData("$$$$", "validLast", 100)]
        [InlineData("validFirst", "$$$$", 100)]
        [InlineData("validFirst", "validLast", -10)]
        public void TestInvalidCustomerInfo(string first, string last, double balance)
        {
            //Customer customer;
            //Assert.ThrowsAny<InvalidOperationException>(() => customer = new Customer(first, last, balance));
        }
    }
}
