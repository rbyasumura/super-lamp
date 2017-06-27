using Kendo.Modules.Tournament.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournament.Interfaces.Services
{
    public interface ITournamentService
    {
        IEnumerable<TournamentDto> ListAll();
    }
}
