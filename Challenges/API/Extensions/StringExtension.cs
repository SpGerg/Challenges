using Challenges.API.Features.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.API.Extensions
{
    public static class StringExtension
    {
        public static string SetPlaceholders(this string input, Challenge challenge)
        {
            return input.Replace("%challenge_name%", challenge.Name).Replace("%challenge_description%", challenge.Description).Replace("%challenge_awards%", string.Concat(challenge.Awards));
        }
    }
}
