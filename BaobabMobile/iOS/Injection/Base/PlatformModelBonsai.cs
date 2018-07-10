﻿using System;
using BaobabMobile.Trunk.Injection.Base;

namespace BaobabMobile.iOS.Injection.Base
{
    public class PlatformModelBonsai : IPlatformModelBonsai
    {
        public bool IsBackgroundAvailable { get; set; }
        public bool IsInBackground { get; set; }

        public string PlatformName { get; }

        public PlatformModelBonsai()
        {
            IsInBackground = false;
            IsBackgroundAvailable = false;
        }
    }
}
