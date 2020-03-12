using System;
using Bowling.Models;
using Ninject;
using NUnit.Framework;

namespace BowlingTest
{
    [TestFixture()]
    public class TestProviders
    {
        private IDataProvider dataProvider;
        IKernel kernel;

        [SetUp]
        public void Setup()
        {
            kernel = new StandardKernel(new CoreModule());
            dataProvider = kernel.Get<StringDataProvider>();

        }

        [Test()]
        public void StringDataProviderShouldThrowAnArgumentException()
        {
            var args = new string[6];
            args.SetValue("12", 0);
            args.SetValue("1", 1);
            args.SetValue("4", 2);
            args.SetValue("1", 3);
            args.SetValue("2", 4);
            args.SetValue("6", 5);

            Assert.Throws<ArgumentException>(() => dataProvider.GetList(args));
        }
    }
}
