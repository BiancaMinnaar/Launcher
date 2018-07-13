using BaobabMobile.Trunk.Injection.FingerPrint;

namespace BaobabMobile.Droid.Injection.FingerPrintScanner
{
    public class FingerPrint : IFingerPrint
    {
        public string ErrorMessage { get; }
        public bool IsValid { get; set; }
    }
}
