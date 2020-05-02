using System.Collections.Generic;

namespace BuilderImmutableClass
{
    public class ImmutablePerson
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string? MiddleName { get; }
        public IEnumerable<string> ChildrenNames { get; }

        public ImmutablePerson(string firstName, string lastName, string? middleName = null, IEnumerable<string>? childrenNames = null)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            ChildrenNames = childrenNames ?? new string[0];
        }

        private ImmutablePerson(Builder builder)
        {
            FirstName = builder.FirstName;
            LastName = builder.LastName;
            MiddleName = builder.MiddleName;
            ChildrenNames = builder.ChildrenNames;
        }

        public class Builder
        {
            internal string FirstName { get; private set; }
            internal string LastName { get; private set; }
            internal string? MiddleName { get; private set; }
            internal IEnumerable<string> ChildrenNames { get; private set; } = new string[0];

            public Builder(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public Builder SetMiddleName(string middleName)
            {
                MiddleName = middleName;
                return this;
            }

            public Builder SetChildrenNames(IEnumerable<string> childrenNames)
            {
                ChildrenNames = childrenNames;
                return this;
            }

            public ImmutablePerson Build()
            {
                return new ImmutablePerson(this);
            }
        }
    }
}