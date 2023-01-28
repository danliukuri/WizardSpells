using UnityEngine;
using WizardSpells.Data.Configuration.Environment;
using WizardSpells.Data.Dynamic;
using WizardSpells.Features.Force.Accumulators;

namespace WizardSpells.Features.Force.Generators.Environment
{
    public class GravityForceGenerator : IForceGenerator
    {
        private readonly IEnvironmentConfig _environmentConfig;
        private readonly IPermanentForceAccumulator _forceAccumulator;
        private readonly ICharacterData _forceUserData;
        
        private bool _isNormalForceGenerated;
        
        public GravityForceGenerator(IEnvironmentConfig environmentConfig, IPermanentForceAccumulator forceAccumulator,
            ICharacterData forceUserData)
        {
            _environmentConfig = environmentConfig;
            _forceAccumulator = forceAccumulator;
            _forceUserData = forceUserData;
        }

        public void GenerateForce(float deltaTime)
        {
            if (!_forceUserData.IsGrounded)
            {
                GenerateGravityForce(deltaTime);
                _isNormalForceGenerated = false;
            }
            else if (!_isNormalForceGenerated)
                GenerateNormalForce();
        }

        private void GenerateGravityForce(float deltaTime)
        {
            Vector3 gravityForceToAccumulate = CalculateFreeFallAccumulatedDisplacement(deltaTime);
            _forceAccumulator.AccumulatePermanentForce(gravityForceToAccumulate);
        }
        
        private void GenerateNormalForce()
        {
            _forceAccumulator.AccumulatePermanentForce(y: -_forceAccumulator.PermanentForce.y);
            _isNormalForceGenerated = true;
        }
        
        /// <summary>
        /// Calculates the accumulated displacement due to gravity by free fall.
        /// </summary>
        /// <returns> Value calculated by formula d = 1/2 * g * t </returns>
        /// <remarks> Uses the formula of displacement due to gravity by free fall (d = 1/2 * g * t^2),
        /// but divided by the time delta,
        /// because it is the accumulated force that must be multiplied by the time delta when using.</remarks>
        private Vector3 CalculateFreeFallAccumulatedDisplacement(float deltaTime) => 
            _environmentConfig.GravityForce / 2f * deltaTime;
    }
}