using UnityEngine;
using WizardSpells.Data.Dynamic;
using WizardSpells.Data.Static.Configuration.Environment;
using WizardSpells.Features.Services.Force.Accumulators;
using Zenject;

namespace WizardSpells.Features.Services.Force.Generators.Environment
{
    public class GravityForceGenerator : ITickable
    {
        private readonly IEnvironmentConfig _environmentConfig;
        private readonly IPermanentForceAccumulator _forceAccumulator;
        private readonly IGroundableObjectData _forceUserData;

        public GravityForceGenerator(IEnvironmentConfig environmentConfig, IPermanentForceAccumulator forceAccumulator,
            IGroundableObjectData forceUserData)
        {
            _environmentConfig = environmentConfig;
            _forceAccumulator = forceAccumulator;
            _forceUserData = forceUserData;
        }

        public void Tick()
        {
            if (!_forceUserData.IsGrounded)
                GenerateGravityForce(Time.deltaTime);
        }

        private void GenerateGravityForce(float deltaTime)
        {
            Vector3 gravityForceToAccumulate = CalculateFreeFallAccumulatedDisplacement(deltaTime);
            _forceAccumulator.AccumulatePermanentForce(gravityForceToAccumulate);
        }

        /// <summary>
        ///     Calculates the accumulated displacement due to gravity by free fall.
        /// </summary>
        /// <returns> Value calculated by formula d = 1/2 * g * t </returns>
        /// <remarks>
        ///     Uses the formula of displacement due to gravity by free fall (d = 1/2 * g * t^2),
        ///     but divided by the time delta,
        ///     because it is the accumulated force that must be multiplied by the time delta when using.
        /// </remarks>
        private Vector3 CalculateFreeFallAccumulatedDisplacement(float deltaTime) =>
            _environmentConfig.GravityForce / 2f * deltaTime;
    }
}