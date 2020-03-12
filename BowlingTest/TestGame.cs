using Bowling.Models;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingTest
{
    [TestFixture()]
    public class TestGame
    {
        private IGame game;
        private Scorer scorer;
        IKernel kernel;
        
        [SetUp]
        public void Setup()
        {
            kernel = new StandardKernel(new CoreModule());
            scorer = new Scorer(kernel);
            game = kernel.Get<Game>(); 

        }
        [Test()]
        public void AddThreeFrameAndTestIfTheThirdFrameIsASpare()
        {
            game.Add(new Frame { FirstThrow = 1, SecondThrow = 4 });
            game.Add(new Frame { FirstThrow = 4, SecondThrow = 5 });
            game.Add(new Frame { FirstThrow = 6, SecondThrow = 4 });

            var frm = game.GetFrameByIndex(3);
            Assert.AreEqual(3, game.Count());
            Assert.AreEqual(true, frm.IsSpare);

        }
        [Test()]
        public void ComputeTheFirstFrameIfItIsASpare()
        {
            game.Add(new Frame { FirstThrow = 4, SecondThrow = 6 });
            game.Add(new Frame { FirstThrow = 3, SecondThrow = 5 });
            

            var frm = game.GetFrameByIndex(1);
            frm.FrameScored = game.ComputeCurrentScore(frm);
            Assert.AreEqual(13, frm.FrameScored);
            Assert.AreEqual(true, frm.IsSpare);

        }
        [Test()]
        public void ComputeTheFirstFrameIfItIsAStrike()
        {
            game.Add(new Frame { FirstThrow = 10, SecondThrow = 0 });
            game.Add(new Frame { FirstThrow = 3, SecondThrow = 5 });


            var frm = game.GetFrameByIndex(1);
            frm.FrameScored = game.ComputeCurrentScore(frm);
           
            Assert.AreEqual(18, frm.FrameScored);
            Assert.AreEqual(true, frm.IsStrike);

        }
        [Test()]
        public void PreviousScoreForTheFirstFrameMustBeZero()
        {
            game.Add(new Frame { FirstThrow = 10, SecondThrow = 0 });
            game.Add(new Frame { FirstThrow = 3, SecondThrow = 5 });


            var frm = game.GetFrameByIndex(1);
            var previousScore = game.GetPreviousScore(frm);

            Assert.AreEqual(0, previousScore);

        }
        [Test()]
        public void ComputeSimpleFrame()
        {
            game.Add(new Frame { FrameScored = 5 });
            game.Add(new Frame { FirstThrow = 4, SecondThrow = 5 });


            var frm = game.GetFrameByIndex(2);
            frm.FrameScored = game.ComputeCurrentScore(frm);
            Assert.AreEqual(14, frm.FrameScored);

        }
        [Test()]
        public void ComputeSimpleFrameIfItIsAStrike()
        {
            game.Add(new Frame { FrameScored = 5 });
            game.Add(new Frame { FirstThrow = 10, SecondThrow = 0 });
            game.Add(new Frame { FirstThrow = 4, SecondThrow = 5 });

            var frm = game.GetFrameByIndex(2);
            frm.FrameScored = game.ComputeCurrentScore(frm);
            Assert.AreEqual(24, frm.FrameScored);

        }
        [Test()]
        public void ComputeSimpleFrameIfItIsAStpare()
        {
            game.Add(new Frame { FrameScored = 5 });
            game.Add(new Frame { FirstThrow = 4, SecondThrow = 6 });
            game.Add(new Frame { FirstThrow = 4, SecondThrow = 5 });

            var frm = game.GetFrameByIndex(2);
            frm.FrameScored = game.ComputeCurrentScore(frm);
            Assert.AreEqual(19, frm.FrameScored);

        }
        [Test()]
        public void TestTheGame()
        {
            var frames = new List<Frame>();

            frames.Add(new Frame { FirstThrow = 1, SecondThrow = 4 });
            frames.Add(new Frame { FirstThrow = 4, SecondThrow = 5 });
            frames.Add(new Frame { FirstThrow = 6, SecondThrow = 4 });
            frames.Add(new Frame { FirstThrow = 5, SecondThrow = 5 });
            frames.Add(new Frame { FirstThrow = 10, SecondThrow = 0 });
            frames.Add(new Frame { FirstThrow = 0, SecondThrow = 1 });
            frames.Add(new Frame { FirstThrow = 7, SecondThrow = 3 });
            frames.Add(new Frame { FirstThrow = 6, SecondThrow = 4 });
            frames.Add(new Frame { FirstThrow = 10, SecondThrow = 0 });
            frames.Add(new Frame { FirstThrow = 4, SecondThrow = 6 });

            var computedScoredFrame = scorer.GetResult(frames);

            ILookup<int,int> GetScoredFrameByIndex = ((IEnumerable<Frame>) computedScoredFrame)
                .ToLookup(x => x.CurrentIndex, x => x.FrameScored); 
            var firstScore = GetScoredFrameByIndex[1].SingleOrDefault();
            var LastScore = GetScoredFrameByIndex[10].SingleOrDefault();

            Assert.AreEqual(5, firstScore);
            Assert.AreEqual(127, LastScore);

        }
    }
}
