﻿
/*
 * Morgan Stanley makes this available to you under the Apache License,
 * Version 2.0 (the "License"). You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0.
 *
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Unless required by applicable law or agreed
 * to in writing, software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 */

using MorganStanley.Fdc3.NewtonsoftJson.Serialization;
using Newtonsoft.Json;

namespace MorganStanley.Fdc3.AppDirectory.Tests
{
    public class DeserializationTest
    {
        [Fact]
        public void AppDAppDeserializationTest()
        {
            string jsonString = File.ReadAllText("TestJsons\\SampleAppForInterop.json");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Fdc3App app = JsonConvert.DeserializeObject<Fdc3App>(jsonString, new Fdc3JsonSerializerSettings());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            Assert.Equal("my-application", app!.AppId);
            Assert.Equal("my-application", app.Name);
            Assert.Equal("My Application", app.Title);
            Assert.Equal("An example application that uses FDC3 and fully describes itself in an AppD record.", app.Description);
            Assert.Equal("1.0.0", app.Version);
            Assert.Equal("My example application definition", app.ToolTip);
            Assert.Equal("en-US", app.Lang);
            Assert.Equal("fdc3@finos.org", app.ContactEmail);
            Assert.Equal("fdc3-maintainers@finos.org", app.SupportEmail);
            Assert.Equal("http://example.domain.com/", app.MoreInfo);
            Assert.Equal("Example App, Inc.", app.Publisher);
            Assert.Equal("web", app.Type);
            Assert.Equal(3, app.Categories!.Count()!);
            Assert.Single(app.Icons!);
            Assert.Equal(2, app.Screenshots!.Count());
            Assert.IsType<WebAppDetails>(app.Details);
            Assert.Contains("Finsemble", app.HostManifests!.Keys);
            Assert.Contains("Glue42", app.HostManifests.Keys);
            Assert.Contains("Web App Manifest", app.HostManifests.Keys);
            Assert.Contains("ViewChart", app.Interop!.Intents!.ListensFor!.Keys);
            Assert.Contains("myApp.GetPrice", app.Interop.Intents.ListensFor.Keys);
            Assert.Contains("ViewOrders", app.Interop.Intents.Raises!.Keys);
            Assert.Contains("StartEmail", app.Interop.Intents.Raises.Keys);
            Assert.Equal(2, app.Interop.UserChannels!.Broadcasts!.Count()!);
            Assert.Equal(2, app.Interop.UserChannels!.ListensFor!.Count()!);
            Assert.Single(app.Interop.AppChannels!);
            Assert.Contains("fr-FR", app.LocalizedVersions!.Keys);

        }
    }
}