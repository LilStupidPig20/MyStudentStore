namespace RTF.Mobile.ViewModels.Profile
{
    public class ProfileInformationModel
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";

        public string Group { get; }

        public int Points { get; }

        public ProfileInformationModel(string firstName, string lastName, string group, int points)
        {
            FirstName = firstName;
            LastName = lastName;
            Group = group;
            Points = points;
        }
    }
}
