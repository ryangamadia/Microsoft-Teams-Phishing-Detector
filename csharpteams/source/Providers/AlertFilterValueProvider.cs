// -----------------------------------------------------------------------
// <copyright file="AlertFilterValueProvider.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Globalization;
using System.Web;
using System.Web.Mvc;
using MicrosoftGraph_Security_API_Sample.Models;
using MicrosoftGraph_Security_API_Sample.Models.ViewModels;

namespace MicrosoftGraph_Security_API_Sample.Providers
{
    public class AlertFilterValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return string.Compare("filters", prefix, true) == 0;
        }

        public ValueProviderResult GetValue(string key)
        {
            if (this.ContainsPrefix(key))
            {
                var filters = new AlertFilterCollection();

                var formData = HttpContext.Current.Request.Form;
                foreach (var formKey in formData.AllKeys)
                {
                    var valuesByKey = formData.GetValues(formKey);
                    if (AlertFilterModel.HasPropertyDescription(formKey) && valuesByKey != null && valuesByKey.Length > 0)
                    {
                        filters.Add(formKey, valuesByKey[0]);
                    }
                }

                return new ValueProviderResult(filters, null, CultureInfo.InvariantCulture);
            }
            else
            {
                return null;
            }
        }
    }
}