using RTF.Mobile.Utils.Models;

namespace RTF.Mobile.ViewModels.Profile
{
    public class ProfileInformationModel : EditableModel
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";

        public string Group { get; }

        private int points;

        public int Points
        {
            get => points;
            set
            {
                points = value;
                OnPropertyChanged(nameof(Points));
            }
        }

        public ProfileInformationModel(string firstName, string lastName, string group, int points)
        {
            FirstName = firstName;
            LastName = lastName;
            Group = group;
            Points = points;
        }
    }
}
