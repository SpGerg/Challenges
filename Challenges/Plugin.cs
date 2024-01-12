using Challenges.API;
using Challenges.API.Features.Challenges;
using Challenges.Events.Player;
using Challenges.Events.Player.Challenges;
using Exiled.API.Features;
using System;

namespace Challenges
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; }

        public override string Name => "Challenges";

        public override string Author => "SpGerg";

        public override Version Version { get; } = new Version(1, 0, 0);

        public override Version RequiredExiledVersion { get; } = new Version(8, 6, 0);

        public override void OnEnabled()
        {
            Instance = this;

            PlayerHandler.Register();
            ChallengesHandler.Register();  

            foreach (var challenge in Config.Challenges)
            {
                ChallengesAPI.RegisterChallenge(Challenge.Create(challenge.Value.Name, challenge.Value.Description, challenge.Value.Awards, challenge.Key));
            }

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerHandler.Unregister();
            ChallengesHandler.Unregister();

            base.OnDisabled();
        }
    }
}
