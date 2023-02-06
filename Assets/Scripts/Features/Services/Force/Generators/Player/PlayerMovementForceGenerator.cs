using UnityEngine;
using WizardSpells.Data.Static.Configuration.Player;
using WizardSpells.Features.Services.Force.Accumulators;
using WizardSpells.Infrastructure.Services.Input;
using WizardSpells.Utilities.Extensions.Unity;
using Zenject;

namespace WizardSpells.Features.Services.Force.Generators.Player
{
    public class PlayerMovementForceGenerator : ITickable
    {
        private readonly IMovementInputService _movementInputService;
        private readonly IPlayerConfig _config;
        private readonly IInstantForceAccumulator _forceAccumulator;

        public PlayerMovementForceGenerator(IMovementInputService movementInputService, IPlayerConfig config,
            IInstantForceAccumulator instantForceAccumulator)
        {
            _movementInputService = movementInputService;
            _config = config;
            _forceAccumulator = instantForceAccumulator;
        }

        public void Tick()
        {
            if (_movementInputService.HasInput)
                GenerateMovementForce();
        }

        private void GenerateMovementForce() => _forceAccumulator.AccumulateInstantForce(CalculateMovementForce());

        private Vector3 CalculateMovementForce() => _config.MovementSpeed * _movementInputService.GetInput().AsXZ();
    }
}