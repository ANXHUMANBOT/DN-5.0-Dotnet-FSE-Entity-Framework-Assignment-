using System.Collections;
using NUnit.Framework;
using SeasonsLib;

namespace FourSeasonsLib.Tests
{
    [TestFixture]
    public class SeasonTellerTests
    {
        private SeasonTeller _seasonTeller;

        [SetUp]
        public void Setup()
        {
            _seasonTeller = new SeasonTeller();
        }

        // Approach 1 (straightforward): static array of test data
        private static readonly object[] MonthSeasonCases =
        {
            new object[] { "February", "Spring" },
            new object[] { "March", "Spring" },
            new object[] { "April", "Summer" },
            new object[] { "May", "Summer" },
            new object[] { "June", "Summer" },
            new object[] { "July", "Monsoon" },
            new object[] { "August", "Monsoon" },
            new object[] { "September", "Monsoon" },
            new object[] { "October", "Autumn" },
            new object[] { "November", "Autumn" },
            new object[] { "December", "Winter" },
            new object[] { "January", "Winter" },
        };

        [TestCaseSource(nameof(MonthSeasonCases))]
        public void DisplaySeasonBy_GivenMonth_ReturnsExpectedSeason(string month, string expectedSeason)
        {
            string actual = _seasonTeller.DisplaySeasonBy(month);
            Assert.That(actual, Is.EqualTo(expectedSeason));
        }

        // Approach 2 (alternate): method yielding TestCaseData
        private static IEnumerable MonthSeasonTestCaseData()
        {
            yield return new TestCaseData("February").Returns("Spring").SetName("Feb_IsSpring");
            yield return new TestCaseData("March").Returns("Spring").SetName("Mar_IsSpring");
            yield return new TestCaseData("April").Returns("Summer").SetName("Apr_IsSummer");
            yield return new TestCaseData("July").Returns("Monsoon").SetName("Jul_IsMonsoon");
            yield return new TestCaseData("October").Returns("Autumn").SetName("Oct_IsAutumn");
            yield return new TestCaseData("December").Returns("Winter").SetName("Dec_IsWinter");
            yield return new TestCaseData("Foo").Returns("Invalid Season").SetName("Invalid_ReturnsInvalidSeason");
        }

        [TestCaseSource(nameof(MonthSeasonTestCaseData))]
        public string DisplaySeasonBy_GivenMonth_ReturnsExpectedSeason_AlternateApproach(string month)
        {
            return _seasonTeller.DisplaySeasonBy(month);
        }
    }
}