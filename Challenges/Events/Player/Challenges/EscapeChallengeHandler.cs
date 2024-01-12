using Challenges.API.Extensions;
using Exiled.Events.EventArgs.Player;
using MEC;
using EventSource = Exiled.Events.Handlers.Player;

namespace Challenges.Events.Player.Challenges
{
    internal class EscapeChallengeHandler
    {
        internal static void Register()
        {
            EventSource.Escaping += CompleteChallengeOnEscaping;
        }

        internal static void Unregister()
        {
            EventSource.Escaping -= CompleteChallengeOnEscaping;
        }

        private static void CompleteChallengeOnEscaping(EscapingEventArgs ev)
        {
            var player = ev.Player;

            if (!player.TryGetChallenge(API.Enums.ChallengeType.Escape, out var result))
            {
                return;
            }

            //Wait for spawn because i didnt found escaped event.
            Timing.CallDelayed(Timing.WaitForOneFrame, () =>
            {
                player.CompleteChallenge(result);
            });
        }
    }
}
