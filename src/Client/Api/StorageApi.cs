﻿using Blazored.LocalStorage;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace VerusDate.Client.Api
{
    public static class StorageApi
    {
        public async static Task<HttpResponseMessage> Storage_UploadPhotoFace(this HttpClient http, ILocalStorageService storage, byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) throw new ArgumentNullException(nameof(bytes));

            await ProfileApi.ClearCache(storage);
            //await ProfileValidationApi.ClearCache(storage);

            return await http.PostAsJsonAsync("Storage/UploadPhotoFace", new { Stream = bytes });
        }

        public async static Task<HttpResponseMessage> Storage_UploadPhotoGallery(this HttpClient http, ILocalStorageService storage, MemoryStream stream1, MemoryStream stream2, MemoryStream stream3, MemoryStream stream4)
        {
            await ProfileApi.ClearCache(storage);

            return await http.PostAsJsonAsync("Storage/UploadPhotoGallery", new
            {
                Stream1 = stream1?.ToArray(),
                Stream2 = stream2?.ToArray(),
                Stream3 = stream3?.ToArray(),
                Stream4 = stream4?.ToArray()
            });
        }

        public async static Task<HttpResponseMessage> Storage_UploadPhotoValidation(this HttpClient http, ILocalStorageService storage, byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) throw new ArgumentNullException(nameof(bytes));

            //await ProfileValidationApi.ClearCache(storage);
            await GamificationApi.ClearCache(storage);

            return await http.PostAsJsonAsync("Storage/UploadPhotoValidation", new { Stream = bytes });
        }
    }
}