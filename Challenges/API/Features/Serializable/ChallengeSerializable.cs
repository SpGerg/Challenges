namespace Challenges.API.Features.Serializable
{
    public class ChallengeSerializable
    {
        public ChallengeSerializable() { }

        public ChallengeSerializable(string name, string description, ItemType[] awards)
        {
            Name = name;
            Description = description;
            Awards = awards;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public ItemType[] Awards { get; set; }
    }
}
