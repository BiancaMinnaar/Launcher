using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Service;

namespace BaobabMobile.Implementation.Service
{
        public class DashboardService<T> : BaseService<T>, IDashboardService<T>
            where T : BaseViewModel
        {
            public DashboardService(Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<T>> networkInterface)
                :base(networkInterface)
            {
            }

        public async Task<T> Refresh(DashboardViewModel model)
        {
            string requestURL = "/dashboard";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                {"Lat", new ParameterTypedValue(model.Lat)},
                {"Lon", new ParameterTypedValue(model.Lon)}
            };
            return await _NetworkInterface(requestURL, parameters, null, httpMethod);
        }
    }
}
