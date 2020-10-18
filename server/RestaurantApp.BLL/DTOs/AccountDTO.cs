﻿using RestaurantApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantApp.BLL.DTOs
{
    public class AccountDTO
    {

        public AccountDTO()
        {
        }

        internal AccountDTO(Account entity)
        {
            Email = entity.Email;
            Name = entity.Name;
            CreatedOn = entity.CreatedOn;
            Role = entity.Role;
            Cards = entity.Cards.Select(card => new CardDTO(card)).ToList();
        }


        public string Token { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }

        public string Role { get; set; }


        public virtual ICollection<CardDTO> Cards { get; set; } = new List<CardDTO>();

    }
}
