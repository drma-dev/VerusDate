﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class Profile : ModelBase
    {
        public DateTimeOffset? DtTopList { get; private set; }
        public DateTimeOffset? DtLastLogin { get; private set; }

        [Display(Name = "Nome / Apelido", Prompt = "Ex: Paulo ou Paulinho")]
        public string NickName { get; set; }

        [Display(Name = "Descrição", Prompt = "Para sua própria segurança, favor não incluir seu celular, email ou quaisquer informações de contato. \n\nOBS: Promover redes sociais de outras plataformas ou conteúdo que viole direitos de terceiros estará sujeito a banimento da plataforma.")]
        public string Description { get; set; }

        [Display(Name = "Nascimento")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Sexo Biológico")]
        public BiologicalSex BiologicalSex { get; set; }

        [Display(Name = "Status de Relacionamento")]
        public MaritalStatus MaritalStatus { get; set; }

        [Display(Name = "Intenção")]
        public IReadOnlyList<Intent> Intent { get; set; } = Array.Empty<Intent>();

        [Display(Name = "Identidade de Gênero", Description = "Este campo é opcional")]
        public GenderIdentity GenderIdentity { get; set; }

        [Display(Name = "Orientação Sexual", Description = "Este campo é opcional")]
        public SexualOrientation SexualOrientation { get; set; }

        [Display(Name = "Longitude")]
        public double? Longitude { get; set; }

        [Display(Name = "Latitude")]
        public double? Latitude { get; set; }

        [Display(Name = "Localização", Prompt = "Favor, liberar o GPS do seu aparelho", Description = "Informação automática (deve-se liberar a opção de GPS)")]
        public string Location { get; set; }

        [Display(Name = "Fuma")]
        public Smoke Smoke { get; set; }

        [Display(Name = "Bebe")]
        public Drink Drink { get; set; }

        [Display(Name = "Dieta", Description = "Este campo é opcional")]
        public Diet Diet { get; set; }

        [Display(Name = "Altura")]
        public Height Height { get; set; }

        [Display(Name = "Corpo", Description = "Massa Corporal")]
        public BodyMass BodyMass { get; set; }

        [Display(Name = "Raça", Description = "Classificação da Raça")]
        public RaceCategory RaceCategory { get; set; }

        //[JsonIgnore]
        //public ActivityStatus ActivityStatus { get; set; }

        [Display(Name = "Tem Filho(s)")]
        public HaveChildren? HaveChildren { get; set; }

        [Display(Name = "Quer Filho(s)")]
        public WantChildren? WantChildren { get; set; }

        [Display(Name = "Religião")]
        public Religion? Religion { get; set; }

        [Display(Name = "Educação")]
        public EducationLevel? EducationLevel { get; set; }

        [Display(Name = "Carreira")]
        public CareerCluster? CareerCluster { get; set; }

        [Display(Name = "Personalidade Financeira")]
        public MoneyPersonality? MoneyPersonality { get; set; }

        [Display(Name = "Personalidade no Relacionamento")]
        public RelationshipPersonality? RelationshipPersonality { get; set; }

        [Display(Name = "Personalidade MBTI")]
        public MyersBriggsTypeIndicator? MyersBriggsTypeIndicator { get; set; }

        [Display(Name = "Hobbies")]
        public string[] Hobbies { get; set; } = Array.Empty<string>();

        public string MainPhoto { get; private set; }

        public string[] PhotoGallery { get; private set; } = Array.Empty<string>();

        //[JsonIgnore]
        [Display(Name = "Distância")]
        public double? Distance { get; set; }

        public override void LoadDefatultData()
        {
            BirthDate = DateTime.Now.AddYears(-18);
            GenderIdentity = GenderIdentity.Cisgender;
            SexualOrientation = SexualOrientation.Heteressexual;
            Diet = Diet.Omnivore;
        }

        public void UpList()
        {
            DtTopList = DateTimeOffset.UtcNow;
        }

        public void Login()
        {
            DtLastLogin = DateTimeOffset.UtcNow;
        }

        public void UpdateData(Profile vm)
        {
            NickName = vm.NickName;
            Description = vm.Description;
            BirthDate = vm.BirthDate;
            BiologicalSex = vm.BiologicalSex;
            MaritalStatus = vm.MaritalStatus;
            Intent = vm.Intent;
            GenderIdentity = vm.GenderIdentity;
            SexualOrientation = vm.SexualOrientation;
            Longitude = vm.Longitude;
            Latitude = vm.Latitude;
            Location = vm.Location;
            Height = vm.Height;
            BodyMass = vm.BodyMass;
            RaceCategory = vm.RaceCategory;
            Smoke = vm.Smoke;
            Drink = vm.Drink;
            Diet = vm.Diet;

            HaveChildren = vm.HaveChildren;
            WantChildren = vm.WantChildren;
            EducationLevel = vm.EducationLevel;
            CareerCluster = vm.CareerCluster;
            Religion = vm.Religion;
            MoneyPersonality = vm.MoneyPersonality;
            RelationshipPersonality = vm.RelationshipPersonality;
            MyersBriggsTypeIndicator = vm.MyersBriggsTypeIndicator;
            Hobbies = vm.Hobbies;

            base.Update();
        }

        public void UpdateMainPhoto(string MainPhoto)
        {
            this.MainPhoto = MainPhoto;

            base.Update();
        }

        public void UpdatePhotoGallery(string[] PhotoGallery)
        {
            this.PhotoGallery = PhotoGallery;

            base.Update();
        }

        public string GetPhotoFace()
        {
            if (string.IsNullOrEmpty(MainPhoto))
                return "/img/nouser.jpg";
            else
                return MainPhoto;
        }

        public void ClearSimpleView()
        {
            if (Intent.IsShortTerm(true))
            {
                EducationLevel = null;
                HaveChildren = null;
                WantChildren = null;
                CareerCluster = null;
                Religion = null;
                MoneyPersonality = null;
                RelationshipPersonality = null;
                MyersBriggsTypeIndicator = null;
            }
        }
    }
}