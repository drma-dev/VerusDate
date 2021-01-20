﻿using System;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using static VerusDate.Shared.Helper.ImageHelper;

namespace VerusDate.Shared.Model
{
    public class ProfileModel : CosmosBase
    {
        public ProfileModel() : base(CosmosType.Profile)
        {
        }

        public DateTimeOffset? DtTopList { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DtLastLogin { get; set; } = DateTimeOffset.UtcNow;

        private readonly string BlobPath = "https://storageverusdate.blob.core.windows.net";

        public ProfileBasicModel Basic { get; set; }
        public ProfileBioModel Bio { get; set; }
        public ProfileLifestyleModel Lifestyle { get; set; }
        public ProfileLookingModel Looking { get; set; }
        public ProfileGamificationModel Gamification { get; set; }
        public ProfileBadgeModel Badge { get; set; }
        public ProfilePhotoModel Photo { get; set; }

        public void UpList()
        {
            DtTopList = DateTimeOffset.UtcNow;
        }

        public void Login()
        {
            DtLastLogin = DateTimeOffset.UtcNow;
        }

        public void UpdateProfile(ProfileBasicModel basic, ProfileBioModel bio, ProfileLifestyleModel lifestyle)
        {
            Basic = basic;
            Bio = bio;
            Lifestyle = lifestyle;

            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void UpdateLooking(ProfileLookingModel obj)
        {
            Looking = obj;

            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void UpdateGamification(ProfileGamificationModel obj)
        {
            Gamification = obj;

            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void UpdateBadge(ProfileBadgeModel obj)
        {
            Badge = obj;

            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void UpdatePhoto(ProfilePhotoModel obj)
        {
            Photo = obj;

            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void ClearSimpleView()
        {
            if (Basic.Intent.IsShortTerm(exclusive: true))
            {
                Lifestyle.Drink = null;
                Lifestyle.Smoke = null;
                Lifestyle.Diet = null;
                Lifestyle.HaveChildren = null;
                Lifestyle.WantChildren = null;
                Lifestyle.EducationLevel = null;
                Lifestyle.CareerCluster = null;
                Lifestyle.Religion = null;
                Lifestyle.MoneyPersonality = null;
                Lifestyle.RelationshipPersonality = null;
                Lifestyle.MyersBriggsTypeIndicator = null;
                Lifestyle.Hobbies = Array.Empty<string>();
            }
        }

        public int DaysInsert()
        {
            return ProfileHelper.GetDaysPassed(DtInsert.Value);
        }

        public int DaysUpdate()
        {
            if (!DtUpdate.HasValue) return DaysInsert();

            return ProfileHelper.GetDaysPassed(DtUpdate.Value);
        }

        public string GetMainPhoto()
        {
            if (Photo == null || string.IsNullOrEmpty(Photo.Main))
                return GetNoUserPhoto;
            else
                return $"{BlobPath}/{GetPhotoContainer(PhotoType.PhotoFace)}/{Photo.Main}";
        }

        public override void SetIds(string IdLoggedUser)
        {
            this.SetId(IdLoggedUser);
            this.SetPartitionKey(IdLoggedUser);
        }
    }

    public class ProfileView : ProfileModel
    {
        public ActivityStatus ActivityStatus { get; set; }
        public double Distance { get; set; }
        public int Age { get; set; }      
    }
}