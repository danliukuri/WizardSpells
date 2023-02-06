using System;

namespace WizardSpells.Infrastructure.Services.Input
{
    public interface IJumpingInputService
    {
       event Action InputReceived;
    }
}