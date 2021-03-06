﻿using GameSpyLib.Extensions;
using PresenceConnectionManager.Enumerator;
using System.Text;

namespace PresenceConnectionManager.Handler.General.Login.Misc
{
    public class ChallengeProof
    {
        /// <summary>
        /// Generates an MD5 hash, which is used to verify the sessions login information
        /// </summary>
        /// <param name="serverChallenge">First challenge key</param>
        /// <param name="clientChallenge">Second challenge key</param>
        /// <returns>
        ///     The proof verification MD5 hash string that can be compared to what the _session sends,
        ///     to verify that the users entered password matches the specific user data in the database.
        /// </returns>
        public static string GenerateProof(string userData, LoginType loginType, uint partnerID, string serverChallenge, string clientChallenge, string passwordHash)
        {
            string realUserData = userData;

            // Auth token does not have partnerid append.
            if (partnerID != (uint)PartnerID.Gamespy && loginType != LoginType.AuthToken)
            {
                realUserData = string.Format("{0}@{1}", partnerID, userData);
            }

            // Generate our string to be hashed
            StringBuilder HashString = new StringBuilder(passwordHash);
            HashString.Append(' ', 48); // 48 spaces
            HashString.Append(realUserData);
            HashString.Append(serverChallenge);
            HashString.Append(clientChallenge);
            HashString.Append(passwordHash);
            return HashString.ToString().GetMD5Hash();
        }
    }
}
