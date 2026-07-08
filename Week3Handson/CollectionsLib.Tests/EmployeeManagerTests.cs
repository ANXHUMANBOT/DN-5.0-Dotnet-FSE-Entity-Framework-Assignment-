using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using CollectionsLib;

namespace CollectionsLib.Tests
{
    [TestFixture]
    public class EmployeeManagerTests
    {
        private EmployeeManager _employeeManager;

        [SetUp]
        public void Setup()
        {
            _employeeManager = new EmployeeManager();
        }

        [Test]
        public void GetEmployees_Always_ContainsNoNullValues_ConstraintModel()
        {
            var employees = _employeeManager.GetEmployees();
            Assert.That(employees, Has.None.Null);
        }

        [Test]
        public void GetEmployees_Always_ContainsNoNullValues_ClassicModel()
        {
            var employees = _employeeManager.GetEmployees();
            CollectionAssert.DoesNotContain(employees, null);
        }

        [Test]
        public void GetEmployees_Always_ContainsEmployeeWithId100_ConstraintModel()
        {
            var employees = _employeeManager.GetEmployees();
            Assert.That(employees, Has.Some.Matches<Employee>(e => e.EmpId == 100));
        }

        [Test]
        public void GetEmployees_Always_ContainsEmployeeWithId100_ClassicModel()
        {
            var employees = _employeeManager.GetEmployees();
            bool exists = employees.Exists(e => e.EmpId == 100);
            ClassicAssert.IsTrue(exists);
        }

        [Test]
        public void GetEmployees_Always_ReturnsOnlyUniqueEmployees()
        {
            var employees = _employeeManager.GetEmployees();
            var distinctCount = employees.Distinct().Count();
            Assert.That(distinctCount, Is.EqualTo(employees.Count));
        }

        [Test]
        public void GetEmployeesAndGetEmployeesWhoJoinedInPreviousYears_Always_ReturnSameItems_ConstraintModel()
        {
            var all = _employeeManager.GetEmployees();
            var previousYears = _employeeManager.GetEmployeesWhoJoinedInPreviousYears();
            Assert.That(previousYears, Is.EquivalentTo(all));
        }

        [Test]
        public void GetEmployeesAndGetEmployeesWhoJoinedInPreviousYears_Always_ReturnSameItems_ClassicModel()
        {
            var all = _employeeManager.GetEmployees();
            var previousYears = _employeeManager.GetEmployeesWhoJoinedInPreviousYears();
            CollectionAssert.AreEquivalent(all, previousYears);
        }
    }
}