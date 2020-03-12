using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Models
{
    public class Game : IGame
    {
        public List<Frame> frames { get; set; }

        int CurrentFrameIndex;
        public Game()
        {
            frames = new List<Frame>();
            CurrentFrameIndex = 1;
        }

        public void Add(Frame frame)
        {
            frame.CurrentIndex = CurrentFrameIndex++;
            frames.Add(frame);
        }
        public int Count()
        {
            return frames.Count;
        }
        public Frame GetFrameByIndex(int index)
        {
            return frames.SingleOrDefault(x => x.CurrentIndex == index);
        }

        public int ComputeCurrentScore(Frame frame)
        {
            if (!frame.IsSpare && !frame.IsStrike)
            {
                return GetPreviousScore(frame) + frame.FirstThrow + frame.SecondThrow;
            }
            else if (frame.IsSpare)
            {
                return GetPreviousScore(frame) + 10 + GetNextFirstThrow(frame);
            }
            else if (frame.IsStrike)
            {
                return GetPreviousScore(frame) + 10 + GetNextTwoThrows(frame);
            }
            else
            {
                return 0;
            }
        }
        private int GetNextFirstThrow(Frame frame)
        {
            var frm = frames
                .SingleOrDefault(x => x.CurrentIndex == (frame.CurrentIndex + 1));

            return frm == null ? 0 : frm.FirstThrow;
        }
        private int GetNextTwoThrows(Frame frame)
        {
            var frm = frames
                .SingleOrDefault(x => x.CurrentIndex == (frame.CurrentIndex + 1));

            return frm == null ? 0 : frm.FirstThrow + frm.SecondThrow;
        }
        public int GetPreviousScore(Frame frame)
        {
            var frm = frames
                .SingleOrDefault(x => x.CurrentIndex == (frame.CurrentIndex - 1));

            if (frm == null) return 0;

            return frm.FrameScored;
        }
    }
}
