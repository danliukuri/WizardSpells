using UnityEngine;
using Zenject;

namespace WizardSpells.Features.Services.Force.Generators
{
    public class ForceGeneratorsUpdater : ITickable
    {
        private readonly IForceGenerator[] _forceGenerators;

        public ForceGeneratorsUpdater(IForceGenerator[] forceGenerators) => _forceGenerators = forceGenerators;

        public void Tick()
        {
            foreach (IForceGenerator forceGenerator in _forceGenerators)
                forceGenerator.GenerateForce(Time.deltaTime);
        }
    }
}