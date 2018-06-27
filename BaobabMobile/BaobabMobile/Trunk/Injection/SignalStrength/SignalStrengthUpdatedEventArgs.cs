namespace BaobabMobile.Trunk.Injection.SignalStrength
{
    public class SignalStrengthUpdatedEventArgs<T> where T : ISignalStrength
    {
        T signalStrength;

        public SignalStrengthUpdatedEventArgs(T signalStrength)
        {
            this.signalStrength = signalStrength;
        }

        public T SignalStrength
        {
            get { return signalStrength; }
        }
    }
}
