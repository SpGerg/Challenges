using Exiled.API.Features;
using System;

namespace Challenges.API.Features.Challenges
{
    public abstract class Challenge
    {
        protected Challenge(string name, string description, ItemType[] awards)
        {
            Name = name;
            Description = description;
            Awards = awards;
        }

        public string Name { get; init; }

        public string Description { get; init; }

        public abstract Enums.ChallengeType Type { get; }

        public ItemType[] Awards { get; }

        public virtual bool OnChallengeSelected(Player player) => true;

        public static Challenge Create(string name, string desciption, ItemType[] awards, Enums.ChallengeType challengeType)
        {
            switch (challengeType)
            {
                case Enums.ChallengeType.Kill:
                    return new KillChallenge(name, desciption, awards);
                case Enums.ChallengeType.UseScp:
                    return new UseScpChallenge(name, desciption, awards);
                case Enums.ChallengeType.Escape:
                    return new EscapeChallenge(name, desciption, awards);
            }

            return null;
        }
    }
}
