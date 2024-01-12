namespace Challenges.API.Features.Challenges
{
    public class UseScpChallenge : Challenge
    {
        public UseScpChallenge(string name, string description, ItemType[] awards) : base(name, description, awards)
        {
        }

        public override Enums.ChallengeType Type => Enums.ChallengeType.UseScp;
    }
}
