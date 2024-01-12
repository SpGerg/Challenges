namespace Challenges.API.Features.Challenges
{
    public class KillChallenge : Challenge
    {
        public KillChallenge(string name, string description, ItemType[] awards) : base(name, description, awards) { }

        public override Enums.ChallengeType Type => Enums.ChallengeType.Kill;
    }
}
