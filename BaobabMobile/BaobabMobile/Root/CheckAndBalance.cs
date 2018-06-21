using System;

namespace BaobabMobile.Root
{
    public class CheckAndBalance
    {
        public Func<bool> Check { get; set; }
        public string Balance { get; set; }
    }
}

