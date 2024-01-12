using Exiled.API.Features;

namespace Challenges.API.Features.Challenges
{
    public class EscapeChallenge : Challenge
    {
        public EscapeChallenge(string name, string description, ItemType[] awards) : base(name, description, awards)
        {
        }

        public override Enums.ChallengeType Type => Enums.ChallengeType.Escape;

        public override bool OnChallengeSelected(Player player)
        {
            return !player.IsNTF && !player.IsCHI;
        }
    }
}
