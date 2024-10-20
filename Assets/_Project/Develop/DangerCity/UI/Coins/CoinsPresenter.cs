﻿using System;
using DangerCity.Gameplay.Hero.Data;
using DangerCity.Infrastructure.LifeCycle;

namespace DangerCity.UI.Coins
{
    public class CoinsPresenter : ICoinsPresenter, IDisposable
    {
        private readonly HeroInventory _inventory;
        private CoinsView _view;

        public CoinsPresenter(HeroInventory inventory, IExplicitInitializer initializer)
        {
            _inventory = inventory;
            _inventory.Coins.OnChanged += SetCoins;
            initializer.Add(this);
        }

        public void SetView(CoinsView view)
        {
            _view = view;
        }

        public void Dispose()
        {
            _inventory.Coins.OnChanged -= SetCoins;
        }

        private void SetCoins()
        {
            _view.SetScore($"Coins: {_inventory.Coins.Value.ToString()}");
        }
    }
}