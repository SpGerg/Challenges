namespace Challenges.Events.Player.Challenges
{
    internal class ChallengesHandler
    {
        internal static void Register()
        {
            KillChallengeHandler.Register();
            UseScpChallengeHandler.Register();
            EscapeChallengeHandler.Register();
        }

        internal static void Unregister()
        {
            KillChallengeHandler.Unregister();
            UseScpChallengeHandler.Unregister();
            EscapeChallengeHandler.Unregister();
        }
    }
}
