/* 
*  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. 
*  See LICENSE in the source repository root for complete license information. 
*/

namespace Microsoft_Teams_Graph_RESTAPIs_Connect.Models
{
    public class UpdateAlertResultItemModel
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
        public string Feedback { get; set; }
        public string Provider { get; set; }
        public string AssignedTo { get; set; }
        public string Comments { get; set; }
    }
}