﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Dashboard.Shared;
using Dashboard.Controllers;

namespace DashboardWebAppTests.Controller
{
    [TestClass]
    public class SalesIntelligenceErrorControllerTest
    {
        [TestMethod]
        public void TestDeserializeWebHookPayload()
        {
            var payload =
                    @"{
                    ""status"": ""Activated"",
                    ""context"": {
                                ""timestamp"": ""2015-08-14T22:26:41.9975398Z"",
                                ""id"": ""/subscriptions/s1/resourceGroups/useast/providers/microsoft.insights/alertrules/ruleName1"",
                                ""name"": ""ruleName1"",
                                ""description"": ""some description"",
                                ""conditionType"": ""Metric"",
                                ""condition"": {
                                            ""metricName"": ""Requests"",
                                            ""metricUnit"": ""Count"",
                                            ""metricValue"": ""10"",
                                            ""threshold"": ""10"",
                                            ""windowSize"": ""15"",
                                            ""timeAggregation"": ""Average"",
                                            ""operator"": ""GreaterThanOrEqual""
                                    },
                                ""subscriptionId"": ""s1"",
                                ""resourceGroupName"": ""useast"",                                
                                ""resourceName"": ""mysite1"",
                                ""resourceType"": ""microsoft.foo/sites"",
                                ""resourceId"": ""/subscriptions/s1/resourceGroups/useast/providers/microsoft.foo/sites/mysite1"",
                                ""resourceRegion"": ""centralus"",
                                ""portalLink"": ""https://portal.azure.com/#resource/subscriptions/s1/resourceGroups/useast/providers/microsoft.foo/sites/mysite1""
                    },
                    ""properties"": {
                                  ""key1"": ""value1"",
                                  ""key2"": ""value2""
                                  }
                    }";

            var data = (AlertWebHookPayload)JsonConvert.DeserializeObject(payload, typeof(AlertWebHookPayload));
            Assert.AreEqual("Activated", (string)data.status);
        }
    }
}