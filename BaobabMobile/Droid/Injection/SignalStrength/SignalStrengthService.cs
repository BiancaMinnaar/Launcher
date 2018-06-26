﻿using System;
using BaobabMobile.Droid.Injection.SignalStrength;
using BaobabMobile.Trunk.Injection.SignalStrength;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalStrengthService))]
namespace BaobabMobile.Droid.Injection.SignalStrength
{
    public class SignalStrengthService : ISignalStrengthService<ISignalSrength>
    {
        public event EventHandler<SignalStrengthUpdatedEventArgs<ISignalSrength>> SignalStrengthChanged;

        public int SignalStrength 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public int WifiSignalStrength 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public int GetConnectionStrength(ConnectionType connectionType)
        {
            throw new NotImplementedException();
        }
    }
}
