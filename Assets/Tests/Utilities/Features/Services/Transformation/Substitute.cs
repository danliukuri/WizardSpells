using NSubstitute;
using WizardSpells.Data.Dynamic;

namespace WizardSpells.Tests.Utilities.Features.Services.Transformation
{
    public static class Substitute
    {
        public static IGroundableObjectData GroundableObjectData(bool isGrounded = default)
        {
            var contactableObjectData = NSubstitute.Substitute.For<IGroundableObjectData>();
            contactableObjectData.IsGrounded.Returns(isGrounded);
            return contactableObjectData;
        }
    }
}