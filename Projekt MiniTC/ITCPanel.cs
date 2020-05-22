using System;
using System.Collections.Generic;


namespace Projekt_MiniTC
{
    public interface ITCPanel
    {
        string CurrPath { get; set; }
        string[] Dyski { get; set; }
        IEnumerable<object> PathCont { get; set; }
    }
}
