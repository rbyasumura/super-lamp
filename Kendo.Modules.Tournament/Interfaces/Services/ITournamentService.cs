﻿using Kendo.Modules.Tournaments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Interfaces.Services
{
    public interface ITournamentService
    {
        IEnumerable<TournamentDto> ListAll();
    }
}
