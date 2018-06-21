using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Service;

namespace BaobabMobile.Implementation.Service
{
        public class TrackLocationService<T> : BaseService<T>, ITrackLocationService<T>
            where T : BaseViewModel
        {
            public TrackLocationService(Func<string, Dictionary<string, ParameterTypedValue>, BaseViewModel, BaseNetworkAccessEnum, Task<T>> networkInterface)
                :base(networkInterface)
            {
            }

        public async Task<T> TrackLocation(TrackLocationViewModel model)
        {
            string requestURL = "/path/{Parameter}";
            var httpMethod = BaseNetworkAccessEnum.Get;
            var parameters = new Dictionary<string, ParameterTypedValue>()
            {
                //{"Parameter", model.Property},
            };
            return await _NetworkInterface(requestURL, parameters, null, httpMethod);
        }
    }
}
