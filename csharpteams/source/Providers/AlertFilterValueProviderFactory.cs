// -----------------------------------------------------------------------
// <copyright file="AlertFilterValueProviderFactory.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Web.Mvc;

namespace Microsoft_Teams_Graph_RESTAPIs_Connect.Providers
{
    public class AlertFilterValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new AlertFilterValueProvider();
        }
    }
}