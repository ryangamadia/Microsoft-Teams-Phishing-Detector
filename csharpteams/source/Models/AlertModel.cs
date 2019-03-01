/* 
*  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. 
*  See LICENSE in the source repository root for complete license information. 
*/

using Microsoft.Graph;
using System.Collections.Generic;

namespace MicrosoftGraph_Security_API_Sample.Models
{
    public class AlertModel
    {
        public string Id { get; set; }

        public string Metadata { get; set; }

        public List<string> Comments { get; set; }

        public string Status { get; set; }
      
        public string Feedback { get; set; }

        public GraphUserModel User { get; set; }

        public AlertDeviceModel Device { get; set; }

        public string Query { get; set; }
    }
}