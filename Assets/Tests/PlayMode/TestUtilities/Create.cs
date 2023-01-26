using NSubstitute;
using WizardSpells.Services.SceneManagement;

namespace WizardSpells.Tests.PlayMode.TestUtilities
{
    public static class Create
    {
        public static SceneLoader SceneLoader() => Substitute.For<SceneLoader>();
    }
}