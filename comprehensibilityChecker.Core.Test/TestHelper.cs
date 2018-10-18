using comprehensibilityChecker.Contracts;
using comprehensibilityChecker.Contracts.Data;

namespace comprehensibilityChecker.Core.Test
{
    internal static class TestHelper
    {
        internal static Manuscript CreateFilledManuscriptForSplitting()
        {
            return new Manuscript(
                new[]
                {
                    new Sentence(new[]
                    {
                        "Es",
                        "blaut",
                        "die",
                        "Nacht,",
                        "die",
                        "Sternlein",
                        "blinken."
                    }),
                    new Sentence(new[]
                    {
                        "Schneeflöcklein",
                        "leis",
                        "herunter",
                        "sinken."
                    })
                }, "Es blaut die Nacht, die Sternlein blinken. Schneeflöcklein leis herunter sinken.");
        }
    }
}
