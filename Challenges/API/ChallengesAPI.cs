using Challenges.API.Features.Challenges;
using Exiled.API.Features;
using System.Collections.Generic;

namespace Challenges.API
{
    public static class ChallengesAPI
    {
        public static readonly Dictionary<Player, List<Challenge>> _challenges = new Dictionary<Player, List<Challenge>>();

        private static readonly List<Challenge> _registeredChallenges = new List<Challenge>();

        public static void RegisterChallenge(Challenge challenge)
        {
            _registeredChallenges.Add(challenge);
        }

        public static List<Challenge> GetRegisteredChallenges()
        {
            return new List<Challenge>(_registeredChallenges);
        }

        public static void AddChallenge(Player player, Challenge challenge)
        {
            if (!_challenges.TryGetValue(player, out List<Challenge> challenges))
            {
                challenges = _challenges[player] = new List<Challenge>();
            }

            challenges.Add(challenge);
        }

        public static void RemoveChallenge(Player player, Challenge challenge)
        {
            if (!_challenges.TryGetValue(player, out List<Challenge> challenges))
            {
                _challenges[player] = new List<Challenge>();
                return;
            }

            challenges.Remove(challenge);
        }

        public static List<Challenge> GetChallenges(Player player)
        {
            if (!_challenges.TryGetValue(player, out List<Challenge> challenges))
            {
                challenges = _challenges[player] = new List<Challenge>();
            }

            return challenges;
        }
    }
}
