using System;
using UnityEngine;
using WizardSpells.Features.Services.Force.Generators;
using WizardSpells.Features.Services.Force.MotionForce;
using Zenject;

namespace WizardSpells.Features.Services.Transformation
{
    public class PositionUpdater : IInitializable, IDisposable, ITickable
    {
        private readonly IPositionChanger _positionChanger;
        private readonly IMotionForceProvider _motionForceProvider;
        private readonly IForceGenerator[] _motionForceGenerators;

        private bool _isNeededToChangePosition;
        
        public PositionUpdater(IPositionChanger positionChanger, IMotionForceProvider motionForceProvider,
            IForceGenerator[] motionForceGenerators)
        {
            _positionChanger = positionChanger;
            _motionForceProvider = motionForceProvider;
            _motionForceGenerators = motionForceGenerators;
        }

        public void Initialize() => _motionForceProvider.MotionForceChanged += ChangePosition;

        public void Dispose() => _motionForceProvider.MotionForceChanged -= ChangePosition;

        public void Tick()
        {
            float deltaTime = Time.deltaTime;

            foreach (IForceGenerator motionForceApplier in _motionForceGenerators)
                motionForceApplier.GenerateForce(deltaTime);

            if (_isNeededToChangePosition)
            {
                _positionChanger.ChangePosition(_motionForceProvider.GetMotionForce() * deltaTime);
                _isNeededToChangePosition = false;
            }
        }
        private void ChangePosition() => _isNeededToChangePosition = true;
    }
}