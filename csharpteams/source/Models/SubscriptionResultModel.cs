﻿using System.Collections.Generic;
using System;

namespace MicrosoftGraph_Security_API_Sample.Models
{
    public class SubscriptionResultModel
    {
        public string Id { get; set; }
        public string Resource { get; set; }
        public string ChangeType { get; set; }
        public string ClientState { get; set; }
        public string NotificationUrl { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public string Error { get; set; }
        public string Query { get; set; }
    }
}