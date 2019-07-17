﻿using System;
using PingDong.CleanArchitect.Core;

namespace PingDong.Newmoon.Places.Service.Commands
{
    public class PlaceOpenCommand : Command
    {
        public PlaceOpenCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
