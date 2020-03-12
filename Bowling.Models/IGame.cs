using System.Collections.Generic;

namespace Bowling.Models
{
    public interface IGame
    {
        List<Frame> frames { get; set; }
        void Add(Frame frame);
        int ComputeCurrentScore(Frame frame);
        int Count();
        Frame GetFrameByIndex(int index);
        int GetPreviousScore(Frame frame);
    }
}