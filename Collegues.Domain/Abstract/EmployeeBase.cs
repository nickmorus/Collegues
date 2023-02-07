namespace Collegues.Domain.Abstract
{
    public abstract class EmployeeBase
    {
        public string FirstName { get; }
        public string? LastName { get; }
        public string FamilyName { get; }
        public DateTime EmploymentFrom { get; }

        public EmployeeBase(string firstName, string? lastName, string familyName, DateTime employmentFrom)
        {
            FirstName = firstName;
            LastName = lastName;
            FamilyName = familyName;
            EmploymentFrom = employmentFrom;
        }
    }
}