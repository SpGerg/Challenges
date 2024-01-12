using Challenges.API.Extensions;
using Challenges.API.Features.Challenges;
using Exiled.API.Extensions;
using Exiled.Events.EventArgs.Player;
using System.Linq;
using EventSource = Exiled.Events.Handlers.Player;

namespace Challenges.Events.Player.Challenges
{
    public class UseScpChallengeHandler
    {
        internal static void Register()
        {
            EventSource.UsingItemCompleted += CompleteChallengeOnItemUsing;
        }

        internal static void Unregister()
        {
            EventSource.UsingItemCompleted -= CompleteChallengeOnItemUsing;
        }

        private static void CompleteChallengeOnItemUsing(UsingItemCompletedEventArgs ev)
        {
            if (!ev.Usable.Type.IsScp())
            {
                return;
            }

            var player = ev.Player;

            if (!player.TryGetChallenge(API.Enums.ChallengeType.UseScp, out var result))
            {
                return;
            }

            player.CompleteChallenge(result);
        }
    }
}
