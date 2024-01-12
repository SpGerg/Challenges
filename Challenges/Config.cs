using Challenges.API.Features.Serializable;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace Challenges
{
    public class Config : IConfig
    {
        [Description("Is enabled or not")]
        public bool IsEnabled { get; set; }

        [Description("Is debug or not")]
        public bool Debug { get; set; }

        [Description("Challenge complete message")]
        public string ChallengeComplete { get; set; } = "You complete %challenge_name%!\n Awards: %challenge_awards%";

        [Description("Challenge complete message")]
        public string NewChallenge { get; set; } = "Challenge for you: %challenge_name%: %challenge_description%";

        [Description("Challenges display name, display description and awards")]
        public Dictionary<API.Enums.ChallengeType, ChallengeSerializable> Challenges { get; set; } = new Dictionary<API.Enums.ChallengeType, ChallengeSerializable>()
        {
            { API.Enums.ChallengeType.Kill, new ChallengeSerializable("Kill", "Kill player with enemy side!", new ItemType[] { ItemType.SCP207 }) },
            { API.Enums.ChallengeType.UseScp, new ChallengeSerializable("Use scp", "Use scp item!", new ItemType[] { ItemType.GunAK }) },
            { API.Enums.ChallengeType.Escape, new ChallengeSerializable("Escape!", "Escape from this place!", new ItemType[] { ItemType.MicroHID }) },
        };
    }
}
