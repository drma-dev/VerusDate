﻿using System;

namespace VerusDate.Shared.Model
{
    public class ProfilePhotoModel
    {
        public string Main { get; set; }
        public string Validation { get; set; }
        public string[] Gallery { get; set; } = Array.Empty<string>();

        public void UpdateMainPhoto(string Main)
        {
            this.Main = Main;
        }

        public void UpdatePhotoGallery(string[] Gallery)
        {
            this.Gallery = Gallery;
        }
    }
}