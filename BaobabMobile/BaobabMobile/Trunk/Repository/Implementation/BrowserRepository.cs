using System;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Root.Repository;
using System.Collections.Generic;

namespace BaobabMobile.Implementation.Repository
{
    public class BrowserRepository<T> : ProjectBaseRepository, IBrowserRepository<T>
        where T : BaseViewModel
    {
        IBrowserService<T> _Service;

        public BrowserRepository(IMasterRepository masterRepository, IBrowserService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public bool TestURL(string urlToTest)
        {
            //GetFromsomeware else
            var urlDictionary = new Dictionary<string, bool>
            {{"www.google.com", true}, {"www.yahoo.com", false}};

            return urlDictionary[urlToTest];
        }
    }
}