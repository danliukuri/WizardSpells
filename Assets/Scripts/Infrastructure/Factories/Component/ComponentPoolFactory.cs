using System.Collections.Generic;
using UnityEngine.Pool;
using WizardSpells.Data.Configuration;
using Zenject;

namespace WizardSpells.Infrastructure.Factories.Component
{
    public class ComponentPoolFactory<TComponent> : IFactory<ObjectPool<TComponent>>, IInitializable
        where TComponent : UnityEngine.Component
    {
        private readonly List<ObjectPool<TComponent>> _createdPools = new();
        private readonly IComponentFactory<TComponent> _componentFactory;
        private readonly IPoolConfig _poolConfig;

        public ComponentPoolFactory(IComponentFactory<TComponent> componentFactory, IPoolConfig poolConfig)
        {
            _componentFactory = componentFactory;
            _poolConfig = poolConfig;
        }

        public void Initialize()
        {
            _createdPools.ForEach(FillWithStartObjects);

            void FillWithStartObjects(ObjectPool<TComponent> pool)
            {
                for (var i = 0; i < _poolConfig.StartCount; i++)
                    pool.Release(_componentFactory.Create());
            }
        }

        public ObjectPool<TComponent> Create()
        {
            var pool = new ObjectPool<TComponent>(_componentFactory.Create, _componentFactory.ActivateGameObject,
                _componentFactory.DeactivateGameObject, _componentFactory.DestroyGameObject,
                _poolConfig.ThrowErrorIfItemAlreadyInPoolWhenRelease, _poolConfig.StartCapacity, _poolConfig.MaxSize);
            
            _createdPools.Add(pool);
            return pool;
        }
    }
}