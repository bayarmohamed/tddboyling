using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace Bowling.Models
{
    public class Scorer
    {
        readonly IGame game;

        public Scorer(IKernel kernel)
        {
            this.game = kernel.Get<Game>();
        }

        public List<Frame> GetResult(List<Frame> frames)
        {
            foreach (var item in frames)
            {
                game.Add(item);
            }

            var computedFrames = new List<Frame>();
            var arrayOfFrame = game.frames.OrderBy(x => x.CurrentIndex);
            foreach (var frame in arrayOfFrame)
            {
                frame.FrameScored = game.ComputeCurrentScore(frame);
                computedFrames.Add(frame);
            }
            return computedFrames;
        }

    }
}
