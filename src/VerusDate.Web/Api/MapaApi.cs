﻿using Blazored.SessionStorage;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public struct MapEndpoint
    {
        public static string GetLocation(double Latitude, double Longitude) => $"External/GetLocation?latitude={Latitude.ToString(CultureInfo.InvariantCulture)}&longitude={Longitude.ToString(CultureInfo.InvariantCulture)}";
    }

    public static class MapApi
    {
        public async static Task<HereJson> Map_GetLocation(this HttpClient http, ISyncSessionStorageService storage, double Latitude, double Longitude)
        {
            return await http.Get<HereJson>(MapEndpoint.GetLocation(Latitude, Longitude), storage);
        }
    }
}