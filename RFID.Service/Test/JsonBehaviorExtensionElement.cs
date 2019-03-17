using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace IS.RFID.Service.Test {
    public class JsonBehaviorExtensionElement : BehaviorExtensionElement, IServiceBehavior {
        public JsonBehaviorExtensionElement() : base()
        {
        }

        protected override object CreateBehavior() {
            return new JsonEndpointBehavior();
        }

        public override Type BehaviorType => typeof(JsonEndpointBehavior);
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters) { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}
