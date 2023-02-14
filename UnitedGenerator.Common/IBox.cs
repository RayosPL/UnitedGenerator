﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Common
{
    public interface IBox
    {
        string Name { get; }
        string Id { get; }
        ISeason Season { get; }
        IHero[] Heroes { get; }
        IVillain[] Villains { get; }
        IAntiHero[] AntiHeroes { get; }
        ILocation[] Locations { get; }
        IChallenge[] Challenges { get; }
        IHeroTeam[] Teams { get; }

        IBoxItem[] AllItems { get; }
    }
}