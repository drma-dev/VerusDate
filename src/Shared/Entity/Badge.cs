﻿using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Entity
{
    public class Badge : EntityType
    {
        [Key]
        public string IdUser { get; set; }

        /// <summary>
        /// 1 = Bronze
        /// 2 = Prata
        /// 3 = Ouro
        /// 4 = Safira
        /// 5 = Rubi
        /// 6 = Esmeralda
        /// 7 = Ametista
        /// 8 = Pérola
        /// 9 = Obsidiana
        /// 10 = Diamante
        /// </summary>
        public ValueType.BadgeType Rank { get; set; } //aumenta pelo xp

        /// <summary>
        /// 1 mês de aniversário
        /// 2 meses de aniversário
        /// 3 meses de aniversário
        /// 4 meses de aniversário
        /// 5 meses de aniversário
        /// 6 meses de aniversário
        /// 7 meses de aniversário
        /// 8 meses de aniversário
        /// 9 meses de aniversário
        /// 10 meses de aniversário
        /// </summary>
        public ValueType.BadgeType Seniority { get; set; } //aumenta com a passagem do tempo

        /// <summary>
        /// completou todos os campos existentes (de acordo com a intenção escolhida)
        /// </summary>
        public ValueType.BadgeType CompletedProfile { get; set; } //aumenta com ações do usuário

        /// <summary>
        /// 1 = foto
        /// 2 = redes sociais
        /// 3 = avaliação pessoal
        /// </summary>
        public ValueType.BadgeType VerifiedProfile { get; set; } //aumenta com ações do usuário

        /// <summary>
        /// likes acima de 70%
        /// </summary>
        public ValueType.BadgeType Popular { get; set; } //aumenta com ações de outros usuários

        public Profile Profile { get; set; }
    }
}