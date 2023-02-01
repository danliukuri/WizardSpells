using NSubstitute;
using WizardSpells.Data.Dynamic;

namespace WizardSpells.Tests.Utilities.Features.Services.Transformation
{
    public static class Substitute
    {
        public static ICharacterData CharacterData(bool isGrounded = false)
        {
            var characterData = NSubstitute.Substitute.For<ICharacterData>();
            characterData.IsGrounded.Returns(isGrounded);
            return characterData;
        }
    }
}