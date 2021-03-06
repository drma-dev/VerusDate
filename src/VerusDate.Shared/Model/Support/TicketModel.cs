﻿using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class TicketModel : CosmosBase
    {
        public TicketModel() : base(CosmosType.Ticket)
        {
        }

        public string IdUserOwner { get; set; }

        [Display(Name = "Tipo")]
        public TicketType TicketType { get; set; }

        [Display(Name = "Descrição", Prompt = "Descreva o mais detalhado possível para que possamos entender melhor o problema")]
        public string Description { get; set; }

        [Display(Name = "Status")]
        public TicketStatus TicketStatus { get; set; }

        [Display(Name = "Total de Votos")]
        public int TotalVotes { get; set; }

        public void ChangeStatus(TicketStatus ticketStatus)
        {
            TicketStatus = ticketStatus;

            DtUpdate = DateTime.UtcNow;
        }

        public override void SetIds(string IdLoggedUser)
        {
            var guid = Guid.NewGuid().ToString();
            this.SetId(guid);
            this.SetPartitionKey(guid);
            IdUserOwner = IdLoggedUser;
        }

        public void Vote()
        {
            TotalVotes++;

            DtUpdate = DateTime.UtcNow;
        }
    }
}