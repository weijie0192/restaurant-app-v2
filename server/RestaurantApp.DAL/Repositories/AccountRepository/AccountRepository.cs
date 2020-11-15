﻿using Microsoft.EntityFrameworkCore;
using RestaurantApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RestaurantApp.DAL.Repositories
{
    internal class AccountRepository : BaseRepository<Account, int>, IAccountRepository
    {
        public AccountRepository(RestaurantAppContext context): base(context)
        {
        }

        public Account GetByPhone(string phone)
        {
            return base.SingleOrDefault(acc => acc.Phone == phone);
        }
    }
}