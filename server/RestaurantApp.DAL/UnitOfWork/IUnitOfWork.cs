﻿using RestaurantApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.DAL
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IMenuRepository Menus { get; }
        IOrderRepository Orders { get; }
        IOrderRuleRepository OrderRules { get; }

        public int Complete();

    }
}
