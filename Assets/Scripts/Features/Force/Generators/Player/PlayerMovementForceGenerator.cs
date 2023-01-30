using UnityEngine;
using WizardSpells.Data.Static.Configuration.Player;
using WizardSpells.Features.Force.Accumulators;
using WizardSpells.Services.Input;
using WizardSpells.Utilities.Extensions.Unity;

namespace WizardSpells.Features.Force.Generators.Player
{
    public class PlayerMovementForceGenerator : IForceGenerator
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

        public void GenerateForce(float deltaTime)
        {
            if (_movementInputService.HasInput)
                _forceAccumulator.AccumulateInstantForce(CalculateMovementForce());
        }

        private Vector3 CalculateMovementForce() => _config.MovementSpeed * _movementInputService.GetInput().AsXZ();
    }
}