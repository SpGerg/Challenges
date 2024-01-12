using Challenges.API.Features.Challenges;
using Exiled.API.Extensions;
using Exiled.API.Features;
using MEC;
using System.Collections.Generic;
using System.Linq;

namespace Challenges.API.Extensions
{
    public static class PlayerExtension
    {
        public static void AddChallenge(this Player player, Challenge challenge)
        {
            ChallengesAPI.AddChallenge(player, challenge);
        }

        public static void AddRandomChallenge(this Player player, bool isWithMessage = true)
        {
            var challenge = ChallengesAPI.GetRegisteredChallenges().GetRandomValue();

            var result = challenge.OnChallengeSelected(player);

            while (!result)
            {
                challenge = ChallengesAPI.GetRegisteredChallenges().GetRandomValue();

                result = challenge.OnChallengeSelected(player);
            }

            player.AddChallenge(challenge);

            if (isWithMessage)
            {
                player.Broadcast(2, Plugin.Instance.Config.NewChallenge.SetPlaceholders(challenge));
                player.SendConsoleMessage(Plugin.Instance.Config.NewChallenge.SetPlaceholders(challenge), "default");
            }
        }

        public static void CompleteChallenge(this Player player, Challenge challenge, bool isWithMessage = true, bool isGiveNewChallenge = true)
        {
            player.AddItem(challenge.Awards);

            ChallengesAPI.RemoveChallenge(player, challenge);

            if (isWithMessage)
            {
                var message = Plugin.Instance.Config.ChallengeComplete.SetPlaceholders(challenge);

                player.Broadcast(2, message);
            }

            if (isGiveNewChallenge)
            {
                Timing.CallDelayed(2, () =>
                {
                    player.AddRandomChallenge();
                });
            }
        }

        public static bool TryGetChallenge(this Player player, Enums.ChallengeType challengeType, out Challenge result)
        {
            var challenges = player.GetChallenges();

            var challenge = challenges.FirstOrDefault(challenge => challenge.Type == challengeType);

            if (challenge == default)
            {
                result = null;
                return false;
            }

            result = challenge;
            return true;
        }

        public static void RemoveChallenge(this Player player, Challenge challenge)
        {
            ChallengesAPI.RemoveChallenge(player, challenge);
        }

        public static List<Challenge> GetChallenges(this Player player)
        {
            return ChallengesAPI.GetChallenges(player);
        }
    }
}
