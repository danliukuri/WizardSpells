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
        public void WhenChangePosition_AndCharacterIsGrounded_AndMotionForceIsDown_ThenCharacterShouldBeGrounded()
        {
            // Arrange
            CharacterController characterController = Create.GroundedCharacterController();
            ICharacterData characterData = Substitute.CharacterData(characterController.isGrounded);
            PositionChanger positionChanger = Create.PositionChanger(characterController, characterData);

            // Act
            positionChanger.ChangePosition(Vector3.down);

            // Assert
            characterData.IsGrounded.Should().BeTrue();
        }

        [Test]
        public void WhenChangePosition_AndCharacterIsGrounded_AndMotionForceIsUp_ThenCharacterShouldNotBeGrounded()
        {
            // Arrange
            CharacterController characterController = Create.GroundedCharacterController();
            ICharacterData characterData = Substitute.CharacterData(characterController.isGrounded);
            PositionChanger positionChanger = Create.PositionChanger(characterController, characterData);

            // Act
            positionChanger.ChangePosition(Vector3.up);

            // Assert
            characterData.IsGrounded.Should().BeFalse();
        }

        [Test]
        public void WhenChangePosition_AndCharacterIsNotGrounded_AndMotionForceIsDown_ThenCharacterShouldNotBeGrounded()
        {
            // Arrange
            ICharacterData characterData = Substitute.CharacterData();
            PositionChanger positionChanger = Create.PositionChanger(default, characterData);

            // Act
            positionChanger.ChangePosition(Vector3.down);

            // Assert
            characterData.IsGrounded.Should().BeFalse();
        }

        [Test]
        public void WhenChangePosition_AndCharacterIsNotGrounded_AndMotionForceIsUp_ThenCharacterShouldNotBeGrounded()
        {
            // Arrange
            ICharacterData characterData = Substitute.CharacterData();
            PositionChanger positionChanger = Create.PositionChanger(default, characterData);

            // Act
            positionChanger.ChangePosition(Vector3.up);

            // Assert
            characterData.IsGrounded.Should().BeFalse();
        }
    }
}