using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Swashbuckle.AspNetCore.Filters;

namespace FhirSwaggerExample
{
    public class BundleExample : IExamplesProvider<Bundle>
    {
        public Bundle GetExamples()
        {
            return new Bundle
            {
                Entry = new List<Bundle.EntryComponent>
                {
                    GetOrganizationLocation("10286"),
                    GetRegionLocation("00000001")
                }
            };
        }
        
        private static Bundle.EntryComponent GetOrganizationLocation(string accountCode)
        {
            var location = new Location();
            location.Identifier.Add(
                new Identifier("http://terminology.ru/CodeSystem/account-codes", accountCode));

            return WrapResource(location);
        }

        private static Bundle.EntryComponent GetRegionLocation(string locationFiasCode)
        {
            var location = new Location();
            location.Identifier.Add(
                new Identifier("http://terminology.ru/CodeSystem/fias-codes-region", locationFiasCode));

            return WrapResource(location);
        }
        
        private static Bundle.EntryComponent WrapResource(Resource resource)
        {
            var entry = new Bundle.EntryComponent
            {
                Request = new Bundle.RequestComponent
                {
                    Method = Bundle.HTTPVerb.POST,
                    Url = "Bundle"
                },
                FullUrl = GuidToUrl(Guid.NewGuid()),
                Resource = resource
            };
            return entry;
        }
        
        private static string GuidToUrl(Guid guid)
        {
            return "urn:uuid:" + guid;
        }
    }
}