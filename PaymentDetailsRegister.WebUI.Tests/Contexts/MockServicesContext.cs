using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Tests.Mocks;

namespace WebUI.Tests.Contexts
{
    public class MockServicesContext
    {
        private PaymentDetailsMock paymentDetailsMock;

        public PaymentDetailsMock PaymentDetailsMock
        {
            get => paymentDetailsMock != null ? paymentDetailsMock : paymentDetailsMock = new PaymentDetailsMock();
            set => paymentDetailsMock = value;
        }
    }
}
