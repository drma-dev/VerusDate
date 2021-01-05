﻿using Bogus;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Seed
{
    public static class EventSeed
    {
        public static Faker<Model.Event.Event> GetEventVM(string IdUser = null)
        {
            return new Faker<Model.Event.Event>("pt_BR")
                .Rules((s, p) =>
                {
                    p.SetIds(IdUser ?? s.Random.Guid().ToString());
                    p.DtStart = s.Date.FutureOffset();
                    p.DtEnd = s.Date.FutureOffset();
                    p.EventType = s.PickRandom<EventType>();
                    p.Location = s.Address.City();
                    p.MinimalAge = s.Random.Number(18, 40);
                    p.MaxAge = s.Random.Number(30, 120);
                    p.Intent = s.Random.ArrayElements(new Intent[] { Intent.OneNightStand, Intent.FriendsWithBenefits, Intent.Relationship, Intent.Married });
                    p.SexualOrientation = s.Random.ArrayElements(new SexualOrientation[] { SexualOrientation.Assexual, SexualOrientation.Heteressexual, SexualOrientation.Bissexual, SexualOrientation.Bissexual });
                    p.GenderDivision = s.Random.Bool();
                });
        }
    }
}