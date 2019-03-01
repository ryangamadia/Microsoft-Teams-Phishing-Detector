/* 
*  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. 
*  See LICENSE in the source repository root for complete license information. 
*/

using System.Collections.Generic;

namespace Microsoft_Teams_Graph_RESTAPIs_Connect.Models
{
    public class SubscriptionCollection
    {
        public IEnumerable<SubscriptionResultModel> Subscriptions { get; set; }
        public string Query { get; set; }
    }
}