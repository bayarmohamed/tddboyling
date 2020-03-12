using Bowling.Models;
using NUnit.Framework;
using System;
namespace BowlingTest
{
    [TestFixture()]
    public class TestFrame
    {
        private Frame frame;
        private Game game;
        [SetUp]
        public void Setup()
        {
            frame = new Frame();
            game = new Game();
        }
        [Test()]
        public void IsFrameAStrike()
        {
            frame.FirstThrow = 10;
            Assert.AreEqual(true,frame.IsStrike);
        }
        [Test()]
        public void IsFrameASpare()
        {
            frame.FirstThrow = 4;
            frame.SecondThrow = 6;
            Assert.AreEqual(true, frame.IsSpare);
        }
        [Test()]
        public void ComputeScoreOfTheFirstFrame()
        {
             frame.FirstThrow = 1;
             frame.SecondThrow = 4;
             Assert.AreEqual(5, game.ComputeCurrentScore(frame));
        }
    }
}
