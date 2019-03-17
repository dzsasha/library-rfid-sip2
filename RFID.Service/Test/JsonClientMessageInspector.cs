using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace IS.RFID.Service.Test {
    public class JsonClientMessageInspector : IClientMessageInspector {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            buffer.CreateMessage();
            return request;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
}
