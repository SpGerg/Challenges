using Challenges.API.Extensions;
using Challenges.API.Features.Challenges;
using Exiled.API.Extensions;
using Exiled.Events.EventArgs.Player;
using System.Linq;
using EventSource = Exiled.Events.Handlers.Player;

namespace Challenges.Events.Player.Challenges
{
    internal class KillChallengeHandler
    {
        internal static void Register()
        {
            EventSource.Died += CompleteChallengeOnPlayerKilled;
        }

        internal static void Unregister()
        {
            EventSource.Died -= CompleteChallengeOnPlayerKilled;
        }

        private static void CompleteChallengeOnPlayerKilled(DiedEventArgs ev)
        {
            if (ev.Attacker is null)
            {
                return;
            }

            var player = ev.Attacker;

            if (!player.TryGetChallenge(API.Enums.ChallengeType.Kill, out var result))
            {
                return;
            }

            if (ev.Attacker.Role.Side == ev.TargetOldRole.GetSide())
            {
                return;
            }

            player.CompleteChallenge(result);
        }
    }
}
