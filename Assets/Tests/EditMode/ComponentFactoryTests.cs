using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using WizardSpells.Data.Configuration;
using WizardSpells.Infrastructure.Factories.Component;

namespace WizardSpells.Tests.EditMode
{
    public class ComponentFactoryTests
    {
        [Test]
        public void WhenCreate_ThenNewComponentShouldNotBeNull()
        {
            // Arrange
            ComponentFactory<Transform> factory = Create.ComponentFactory();

            // Act
            Transform newComponent = factory.Create();

            // Assert
            newComponent.Should().NotBeNull();
        }

        [Test]
        public void WhenCreate_ThenNewGameObjectShouldNotBeOriginal()
        {
            // Arrange
            var originalGameObject = new GameObject("original");
            IFactoryConfig factoryConfig = Create.FactoryConfig(originalGameObject);
            ComponentFactory<Transform> factory = Create.ComponentFactory(factoryConfig);

            // Act
            Transform newComponent = factory.Create();

            // Assert
            newComponent.gameObject.Should().NotBe(originalGameObject);
        }

        [Test]
        public void WhenCreate_AndOriginalHas3Components_ThenNewComponentsCountShouldBeGreaterOrEqualToOriginal()
        {
            // Arrange
            GameObject originalGameObject = Create.NewGameObject(typeof(Rigidbody), typeof(BoxCollider));
            ComponentFactory<Transform> factory = Create.ComponentFactory(Create.FactoryConfig(originalGameObject));

            // Act
            Transform newComponent = factory.Create();

            // Assert
            int originalGameObjectComponentsCount = originalGameObject.GetComponents<Component>().Length;
            int newGameObjectComponentsCount = newComponent.gameObject.GetComponents<Component>().Length;
            newGameObjectComponentsCount.Should().BeGreaterOrEqualTo(originalGameObjectComponentsCount);
        }

        [Test]
        public void WhenCreate_AndOriginalHas3Components_ThenNewComponentsShouldBeTypeOfOriginalOnes()
        {
            // Arrange
            GameObject originalGameObject = Create.NewGameObject(typeof(Rigidbody), typeof(BoxCollider));
            ComponentFactory<Transform> factory = Create.ComponentFactory(Create.FactoryConfig(originalGameObject));

            // Act
            Transform newComponent = factory.Create();

            // Assert
            Component[] originalGameObjectComponents = originalGameObject.GetComponents<Component>();
            Component[] newGameObjectComponents = newComponent.gameObject.GetComponents<Component>();
            for (var i = 0; i < originalGameObjectComponents.Length; i++)
                newGameObjectComponents[i].Should().BeOfType(originalGameObjectComponents[i].GetType());
        }
    }
}