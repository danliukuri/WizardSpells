using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using WizardSpells.Infrastructure.Factories.Components;
using WizardSpells.Tests.EditMode.TestUtilities;
using Zenject;

namespace WizardSpells.Tests.EditMode.Infrastructure.Factories.Components
{
    public class DependentComponentFactoryTests : ZenjectUnitTestFixture
    {
        [Test]
        public void WhenCreate_ThenNewComponentShouldNotBeNull() =>
            ComponentFactoryTests.WhenCreate_ThenNewComponentShouldNotBeNull
                (() => Create.DependentComponentFactory<Transform>());

        [Test]
        public void WhenCreate_ThenNewGameObjectShouldNotBeOriginal() =>
            ComponentFactoryTests.WhenCreate_ThenNewGameObjectShouldNotBeOriginal
                (originalGameObject => Create.DependentComponentFactory<Transform>(originalGameObject));

        [Test]
        public void WhenCreate_AndOriginalHas3Components_ThenNewComponentsCountShouldBeGreaterOrEqualToOriginal() =>
            ComponentFactoryTests
                .WhenCreate_AndOriginalHas3Components_ThenNewComponentsCountShouldBeGreaterOrEqualToOriginal
                    (originalGameObject => Create.DependentComponentFactory<Transform>(originalGameObject));

        [Test]
        public void WhenCreate_AndOriginalHas3Components_ThenNewComponentsShouldBeTypeOfOriginalOnes() =>
            ComponentFactoryTests.WhenCreate_AndOriginalHas3Components_ThenNewComponentsShouldBeTypeOfOriginalOnes
                (originalGameObject => Create.DependentComponentFactory<Transform>(originalGameObject));

        [Test]
        public void WhenCreate_AndComponentHasDependency_ThenItShouldBeInjectedOne()
        {
            // Arrange
            float randomValue = Random.value;
            Container.BindInstance(randomValue).WhenInjectedInto<TestObject>();

            GameObject originalGameObject = Create.GameObject(typeof(TestObject));
            DependentComponentFactory<TestObject> factory =
                Create.DependentComponentFactory<TestObject>(originalGameObject, Container);

            // Act
            float injectedRandomFloatValue = factory.Create().FloatValue;

            // Assert
            injectedRandomFloatValue.Should().Be(randomValue);
        }

        private class TestObject : MonoBehaviour
        {
            [Inject] public float FloatValue { get; }
        }
    }
}