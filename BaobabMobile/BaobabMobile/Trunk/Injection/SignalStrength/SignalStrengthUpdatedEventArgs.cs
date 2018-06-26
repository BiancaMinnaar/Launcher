namespace BaobabMobile.Trunk.Injection.SignalStrength
{
    public class SignalStrengthUpdatedEventArgs<T> where T : ISignalSrength
    {
        T signalStrength;

        public SignalStrengthUpdatedEventArgs(T signalStrength)
        {
            this.signalStrength = signalStrength;
        }

        public T Location
        {
            get { return signalStrength; }
        }
    }
}
