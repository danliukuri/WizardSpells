using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using WizardSpells.Data.Dynamic;
using WizardSpells.Features.Services.Transformation;
using WizardSpells.Tests.Utilities.Features.Services.Transformation;

namespace WizardSpells.Tests.PlayMode.Features.Services.Transformation
{
    public class PositionChangerTests
    {
        [UnityTearDown]
        public IEnumerator TearDown()
        {
            GameObject[] gameObjects = Object.FindObjectsOfType<GameObject>();
            foreach (GameObject gameObject in gameObjects)
                Object.Destroy(gameObject);
            yield return new WaitForEndOfFrame();
        }

        [Test]
        public void WhenChangePosition_AndObjectIsGrounded_AndMotionForceIsDown_ThenObjectShouldBeGrounded()
        {
            // Arrange
            CharacterController characterController = Create.GroundedCharacterController();
            IContactableObjectData contactableObjectData =
                Substitute.ContactableObjectData(characterController.isGrounded);
            PositionChanger positionChanger = Create.PositionChanger(characterController, contactableObjectData);

            // Act
            positionChanger.ChangePosition(Vector3.down);

            // Assert
            contactableObjectData.IsGrounded.Should().BeTrue();
        }

        [Test]
        public void WhenChangePosition_AndObjectIsGrounded_AndMotionForceIsUp_ThenObjectShouldNotBeGrounded()
        {
            // Arrange
            CharacterController characterController = Create.GroundedCharacterController();
            IContactableObjectData contactableObjectData =
                Substitute.ContactableObjectData(characterController.isGrounded);
            PositionChanger positionChanger = Create.PositionChanger(characterController, contactableObjectData);

            // Act
            positionChanger.ChangePosition(Vector3.up);

            // Assert
            contactableObjectData.IsGrounded.Should().BeFalse();
        }

        [Test]
        public void WhenChangePosition_AndObjectIsNotGrounded_AndMotionForceIsDown_ThenObjectShouldNotBeGrounded()
        {
            // Arrange
            IContactableObjectData contactableObjectData = Substitute.ContactableObjectData();
            PositionChanger positionChanger = Create.PositionChanger(default, contactableObjectData);

            // Act
            positionChanger.ChangePosition(Vector3.down);

            // Assert
            contactableObjectData.IsGrounded.Should().BeFalse();
        }

        [Test]
        public void WhenChangePosition_AndObjectIsNotGrounded_AndMotionForceIsUp_ThenObjectShouldNotBeGrounded()
        {
            // Arrange
            IContactableObjectData contactableObjectData = Substitute.ContactableObjectData();
            PositionChanger positionChanger = Create.PositionChanger(default, contactableObjectData);

            // Act
            positionChanger.ChangePosition(Vector3.up);

            // Assert
            contactableObjectData.IsGrounded.Should().BeFalse();
        }
    }
}