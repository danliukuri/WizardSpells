using System;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using WizardSpells.Infrastructure.Factories.Component;

namespace WizardSpells.Tests.EditMode
{
    public class ComponentFactoryTests
    {
        [Test]
        public void WhenCreate_ThenNewComponentShouldNotBeNull() =>
            WhenCreate_ThenNewComponentShouldNotBeNull(() => Create.ComponentFactory<Transform>());

        [Test]
        public void WhenCreate_ThenNewGameObjectShouldNotBeOriginal() =>
            WhenCreate_ThenNewGameObjectShouldNotBeOriginal
                (originalGameObject => Create.ComponentFactory<Transform>(originalGameObject));

        [Test]
        public void WhenCreate_AndOriginalHas3Components_ThenNewComponentsCountShouldBeGreaterOrEqualToOriginal() =>
            WhenCreate_AndOriginalHas3Components_ThenNewComponentsCountShouldBeGreaterOrEqualToOriginal
                (originalGameObject => Create.ComponentFactory<Transform>(originalGameObject));

        [Test]
        public void WhenCreate_AndOriginalHas3Components_ThenNewComponentsShouldBeTypeOfOriginalOnes() =>
            WhenCreate_AndOriginalHas3Components_ThenNewComponentsShouldBeTypeOfOriginalOnes
                (originalGameObject => Create.ComponentFactory<Transform>(originalGameObject));


        public static void WhenCreate_ThenNewComponentShouldNotBeNull
            (Func<ComponentFactory<Transform>> factoryCreationFunc)
        {
            // Arrange
            ComponentFactory<Transform> factory = factoryCreationFunc.Invoke();

            // Act
            Transform newComponent = factory.Create();

            // Assert
            newComponent.Should().NotBeNull();
        }

        public static void WhenCreate_ThenNewGameObjectShouldNotBeOriginal
            (Func<GameObject, ComponentFactory<Transform>> factoryCreationFunc)
        {
            // Arrange
            const string originalGameObjectName = "original";
            var originalGameObject = new GameObject(originalGameObjectName);
            ComponentFactory<Transform> factory = factoryCreationFunc.Invoke(originalGameObject);

            // Act
            Transform newComponent = factory.Create();

            // Assert
            newComponent.gameObject.Should().NotBe(originalGameObject);
        }

        public static void WhenCreate_AndOriginalHas3Components_ThenNewComponentsCountShouldBeGreaterOrEqualToOriginal
            (Func<GameObject, ComponentFactory<Transform>> factoryCreationFunc)
        {
            // Arrange
            GameObject originalGameObject = Create.GameObject(typeof(Rigidbody), typeof(BoxCollider));
            ComponentFactory<Transform> factory = factoryCreationFunc.Invoke(originalGameObject);

            // Act
            Transform newComponent = factory.Create();

            // Assert
            int originalGameObjectComponentsCount = originalGameObject.GetComponents<Component>().Length;
            int newGameObjectComponentsCount = newComponent.gameObject.GetComponents<Component>().Length;
            newGameObjectComponentsCount.Should().BeGreaterOrEqualTo(originalGameObjectComponentsCount);
        }

        public static void WhenCreate_AndOriginalHas3Components_ThenNewComponentsShouldBeTypeOfOriginalOnes
            (Func<GameObject, ComponentFactory<Transform>> factoryCreationFunc)
        {
            // Arrange
            GameObject originalGameObject = Create.GameObject(typeof(Rigidbody), typeof(BoxCollider));
            ComponentFactory<Transform> factory = factoryCreationFunc.Invoke(originalGameObject);

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