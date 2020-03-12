using System;
namespace Bowling.Models
{
    public class Frame
    {
        public int CurrentIndex { get; set; }
        //public bool IsFirstFrame { get; set; }
        public bool IsStrike {
            get {
                return FirstThrow == 10;
            }
            set {
                IsStrike = value;
            }
        }
        public bool IsSpare {
            get
            {
                
                return (FirstThrow + SecondThrow) == 10 && FirstThrow != 10;
            }
            set
            {
                IsSpare = value;
            }
        }
        public int FirstThrow { get; set; }
        public int SecondThrow { get; set; }
        public int FrameScored { get; set; }
        
    }
}
