using System;
using System.Collections.Generic;
using CorePCL;

namespace BaobabMobile.iOS.Injection
{
    public abstract class PlatformServiceBonsai<T>
    {
        private Action<T> _ServiceCallback;

        public virtual string ServiceKey { get; }
        public Action<T> ServiceCallBack
        {
            set => _ServiceCallback = value;
        }

        public List<ValidationRule> ValidationRules { get; set; }
        public string[] ErrorList 
        { 
            get { return RunValidationRules(); } 
        }
        public Action<string[]> OnError { get; set; }

        public PlatformServiceBonsai()
        {
            ValidationRules = new List<ValidationRule>();
        }

        string[] RunValidationRules()
        {
            var errorList = new List<string>();

            foreach (ValidationRule rule in this.ValidationRules)
            {
                if (!rule.Check())
                {
                    errorList.Add(rule.ErrorMessage);
                }
            }

            return errorList.ToArray();
        }

        protected void ExecuteCallBack(T model)
        {
            var possibleErrors = RunValidationRules();
            if (possibleErrors.Length == 0)
            {
                _ServiceCallback?.Invoke(model);
            }
            else
            {
                OnError?.Invoke(possibleErrors);
            }
        }
    }
}
