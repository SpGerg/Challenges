using Challenges.API.Extensions;
using Exiled.Events.EventArgs.Player;
using EventSource = Exiled.Events.Handlers.Player;

namespace Challenges.Events.Player
{
    internal static class PlayerHandler
    {
        internal static void Register()
        {
            EventSource.Spawned += AddChallengeOnPlayerSpawned;
        }

        internal static void Unregister()
        {
            EventSource.Spawned -= AddChallengeOnPlayerSpawned;
        }

        private static void AddChallengeOnPlayerSpawned(SpawnedEventArgs ev)
        {
            var player = ev.Player;

            player.GetChallenges().Clear();

            player.AddRandomChallenge();
        }
    }
}
