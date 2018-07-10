using System;
using System.Collections.Generic;
using CorePCL;

namespace BaobabMobile.Trunk.Injection.Base
{
    public abstract class PlatformServiceBonsai<model> where model : IPlatformModelBase
    {
        public virtual string ServiceKey { get; }
        private Action<model> _ServiceCallback;
        public Action<model> ServiceCallBack
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
            ConfigureRules();
            Activate();
        }

        protected ValidationRule GetRule(Func<bool> check, string errorMessage)
        {
            return new ValidationRule
            {
                Check = check,
                ErrorMessage = errorMessage
            };
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

        protected void ExecuteCallBack(model model)
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

        protected abstract void ConfigureRules();
        protected abstract void Activate();
    }
}
