using NSubstitute;
using WizardSpells.Data.Dynamic;

namespace WizardSpells.Tests.Utilities.Features.Services.Transformation
{
    public static class Substitute
    {
        public static IContactableObjectData ContactableObjectData(bool isGrounded = default,
            float contactOffset = default)
        {
            var contactableObjectData = NSubstitute.Substitute.For<IContactableObjectData>();
            contactableObjectData.IsGrounded.Returns(isGrounded);
            contactableObjectData.ContactOffset.Returns(contactOffset);
            return contactableObjectData;
        }
    }
}