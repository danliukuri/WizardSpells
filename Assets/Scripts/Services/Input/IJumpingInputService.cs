using System;

namespace WizardSpells.Services.Input
{
    public interface IJumpingInputService
    {
       event Action InputReceived;
    }
}