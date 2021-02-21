﻿using Blazored.SessionStorage;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class GamificationSession
    {
        public async static Task Session_AddXP(this HttpClient http, ISyncSessionStorageService storage, int qtd)
        {
            var obj = await http.Get<ProfileModel>(ProfileEndpoint.Get, storage);
            obj.Gamification.AddXP(qtd);
            storage.SetItem(ProfileEndpoint.Get, obj);

            RefreshCore.RefreshHead();
        }

        public async static Task Session_RemoveXP(this HttpClient http, ISyncSessionStorageService storage, int qtd)
        {
            var obj = await http.Get<ProfileModel>(ProfileEndpoint.Get, storage);
            obj.Gamification.RemoveXP(qtd);
            storage.SetItem(ProfileEndpoint.Get, obj);

            RefreshCore.RefreshHead();
        }

        public async static Task Session_AddDiamond(this HttpClient http, ISyncSessionStorageService storage, int qtd)
        {
            var obj = await http.Get<ProfileModel>(ProfileEndpoint.Get, storage);
            obj.Gamification.AddDiamond(qtd);
            storage.SetItem(ProfileEndpoint.Get, obj);

            RefreshCore.RefreshHead();
        }

        public async static Task Session_RemoveDiamond(this HttpClient http, ISyncSessionStorageService storage, int qtd)
        {
            var obj = await http.Get<ProfileModel>(ProfileEndpoint.Get, storage);
            obj.Gamification.RemoveDiamond(qtd);
            storage.SetItem(ProfileEndpoint.Get, obj);

            RefreshCore.RefreshHead();
        }

        public async static Task Session_ExchangeFood(this HttpClient http, ISyncSessionStorageService storage, int qtd)
        {
            var obj = await http.Get<ProfileModel>(ProfileEndpoint.Get, storage);
            obj.Gamification.ExchangeFood(qtd);
            storage.SetItem(ProfileEndpoint.Get, obj);

            RefreshCore.RefreshHead();
        }

        public async static Task Session_RemoveFood(this HttpClient http, ISyncSessionStorageService storage, int qtd)
        {
            var obj = await http.Get<ProfileModel>(ProfileEndpoint.Get, storage);
            obj.Gamification.RemoveFood(qtd);
            storage.SetItem(ProfileEndpoint.Get, obj);

            RefreshCore.RefreshHead();
        }
    }
}