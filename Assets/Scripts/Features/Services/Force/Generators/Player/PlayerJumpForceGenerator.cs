using System;
using WizardSpells.Data.Dynamic;
using WizardSpells.Data.Static.Configuration.Player;
using WizardSpells.Features.Services.Force.Accumulators;
using WizardSpells.Infrastructure.Services.Input;
using Zenject;

namespace WizardSpells.Features.Services.Force.Generators.Player
{
    public class PlayerJumpForceGenerator : IInitializable, IDisposable
    {
        private readonly IJumpingInputService _jumpingInputService;
        private readonly IPlayerConfig _config;
        private readonly IPermanentForceAccumulator _forceAccumulator;
        private readonly ICharacterData _forceUserData;

        public PlayerJumpForceGenerator(IJumpingInputService jumpingInputService, IPlayerConfig config,
            IPermanentForceAccumulator forceAccumulator, ICharacterData forceUserData)
        {
            _jumpingInputService = jumpingInputService;
            _config = config;
            _forceAccumulator = forceAccumulator;
            _forceUserData = forceUserData;
        }

        public void Initialize() => _jumpingInputService.InputReceived += TryToStartJump;

        public void Dispose() => _jumpingInputService.InputReceived -= TryToStartJump;

        private void TryToStartJump()
        {
            if (_forceUserData.IsGrounded)
                GenerateJumpForce();
        }

        private void GenerateJumpForce() => _forceAccumulator.AccumulatePermanentForce(y: _config.JumpPower);
    }
}