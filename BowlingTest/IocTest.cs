using System;
using Bowling.Models;
using Ninject;
using NUnit.Framework;

namespace BowlingTest
{
    [TestFixture()]
    public class IocTest
    {
        IKernel kernel;

        [SetUp]
        public void Setup()
        {
            kernel = new StandardKernel(new CoreModule());
        }

        [Test()]
        public void ShouldBeAbleToGetGameFromNinject()
        {
            var game = kernel.Get<Game>();
            Assert.IsNotNull(game);
        }
        [Test()]
        public void ShouldBeAbleToGetStringProviderFromNinject()
        {
            var stringProvider = kernel.Get<IDataProvider>();
            Assert.IsNotNull(stringProvider);
        }
    }
}
