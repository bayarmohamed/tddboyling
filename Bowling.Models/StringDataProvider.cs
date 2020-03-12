using System;
using System.Collections.Generic;
using Ninject;

namespace Bowling.Models
{
    public class StringDataProvider:IDataProvider
    {
        List<Frame> frames;

        public StringDataProvider()
        {
            frames = new List<Frame>();
        }

        public List<Frame> GetList(string[] args)
        {
            for (int i = 0; i < args.Length - 1; i += 2)
            {
                if ((Convert.ToInt32(args[i]) + Convert.ToInt32(args[i + 1]) > 10))
                    throw new ArgumentException("Verify your inputs");
                frames.Add(new Frame { FirstThrow = Convert.ToInt32(args[i]), SecondThrow = Convert.ToInt32(args[i + 1]) }); ;
            }
            return frames;
        }
    }
}
