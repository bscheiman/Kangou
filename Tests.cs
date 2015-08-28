#region
using System;
using NUnit.Framework;

#endregion

namespace Kangou {
    [TestFixture]
    public class Tests {
        [Test]
        public void Test_Constructor() {
            Assert.IsNotNull(GetLib());
            Assert.Throws<ArgumentNullException>(() => new KangouLib("", "asd"));
            Assert.Throws<ArgumentNullException>(() => new KangouLib("asd", ""));
            Assert.Throws<ArgumentNullException>(() => new KangouLib(null, "asd"));
            Assert.Throws<ArgumentNullException>(() => new KangouLib("asd", null));
        }

        [Test]
        public void Test_CreateOrder() {
        }

        [Test]
        public void Test_GetOrderInfo() {
        }

        [Test]
        public void Test_GetOrders() {
        }

        [Test]
        public void Test_GetQuote() {
            GetLib().GetQuote("Goldmisth 40, Polanco", "Zamora 128, Condesa");
        }

        private static KangouLib GetLib() {
            return new KangouLib("cus_XXXX", "XXXXXXXXXXXXXX");
        }
    }
}
