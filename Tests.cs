using FluentAssertions;
using NUnit.Framework;

namespace BuilderImmutableClass
{
    public class Tests
    {
        private void AssertImmutablePerson(ImmutablePerson person)
        {
            person.FirstName.Should().Be("John");
            person.LastName.Should().Be("Doe");
            person.MiddleName.Should().Be("Don");
            person.ChildrenNames.Should().Equal(new[] { "Jane" });
        }

        [Test]
        public void ConstructorCreatesClass()
        {
            var person = new ImmutablePerson("John", "Doe", "Don", new[] { "Jane" });

            AssertImmutablePerson(person);
        }

        [Test]
        public void ConstructorWithNamedParametersCreatesClass()
        {
            var person = new ImmutablePerson(
                firstName: "John",
                lastName: "Doe",
                middleName: "Don",
                childrenNames: new[] { "Jane" });

            AssertImmutablePerson(person);
        }

        [Test]
        public void ConstructorWithoutOptionalParametersCreatesClass()
        {
            var person = new ImmutablePerson("John", "Doe");

            person.FirstName.Should().Be("John");
            person.LastName.Should().Be("Doe");
        }

        [Test]
        public void BuilderCreatesClass()
        {
            var person = new ImmutablePerson.Builder("John", "Doe")
                .SetMiddleName("Don")
                .SetChildrenNames(new[] { "Jane" })
                .Build();

            AssertImmutablePerson(person);
        }
    }
}