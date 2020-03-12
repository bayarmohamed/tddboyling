using System;
using System.Collections.Generic;

namespace Bowling.Models
{
    public interface IDataProvider
    {
        List<Frame> GetList(string[] args);
    }
}
