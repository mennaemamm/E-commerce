using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Common
{
    public class PaymentGatewaySettings
    {
        public string SecretKey { get; set; } = default!;
        public string DefaultCurrency { get; set; } = default!;
        public string WebhookSecret { get; set; } = default!;
    }
}
