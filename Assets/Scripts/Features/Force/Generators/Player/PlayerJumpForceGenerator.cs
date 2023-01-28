using System;
using WizardSpells.Data.Configuration.Player;
using WizardSpells.Features.Force.Accumulators;
using WizardSpells.Services.Input;
using Zenject;

namespace WizardSpells.Features.Force.Generators.Player
{
    public class PlayerJumpForceGenerator : IInitializable, IDisposable
    {
        private readonly IJumpingInputService _jumpingInputService;
        private readonly IPlayerConfig _config;
        private readonly IPermanentForceAccumulator _forceAccumulator;

        public PlayerJumpForceGenerator(IJumpingInputService jumpingInputService, IPlayerConfig config,
            IPermanentForceAccumulator forceAccumulator)
        {
            _jumpingInputService = jumpingInputService;
            _config = config;
            _forceAccumulator = forceAccumulator;
        }

        public void Initialize() => _jumpingInputService.InputReceived += GenerateJumpForce;

        public void Dispose() => _jumpingInputService.InputReceived -= GenerateJumpForce;

        private void GenerateJumpForce() => _forceAccumulator.AccumulatePermanentForce(y: _config.JumpPower);
    }
}