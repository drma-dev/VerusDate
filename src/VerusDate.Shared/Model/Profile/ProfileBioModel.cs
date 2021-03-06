﻿using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfileBioModel
    {
        [Display(Name = "Nascimento", Description = "Confira a idade e signo")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Signo")]
        public Zodiac Zodiac { get; set; }

        [Display(Name = "Altura", Description = "(Pode ser um valor aproximado)")]
        public Height Height { get; set; }

        [Display(Name = "Raça", Description = "Classificação definida por US OMB")]
        public RaceCategory RaceCategory { get; set; }

        [Display(Name = "Corpo")]
        public BodyMass BodyMass { get; set; }
    }
}