/* 
*  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. 
*  See LICENSE in the source repository root for complete license information. 
*/

namespace MicrosoftGraph_Security_API_Sample.Models
{
    public class UpdateAlertResultModel
    {
        public string Error { get; set; }

        public string Id { get; set; }

        public string Query { get; set; }

        public UpdateAlertResultItemModel Before { get; set; }

        public UpdateAlertResultItemModel After { get; set; }
    }
}