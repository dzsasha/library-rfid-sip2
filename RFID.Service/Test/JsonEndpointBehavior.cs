using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace IS.RFID.Service.Test {
    public class JsonEndpointBehavior : IEndpointBehavior {
        public void Validate(ServiceEndpoint endpoint) {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) {
            clientRuntime.ClientMessageInspectors.Add(new JsonClientMessageInspector());
        }
    }
}
