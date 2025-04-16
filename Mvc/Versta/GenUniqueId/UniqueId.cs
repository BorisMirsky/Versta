using System.Security.Cryptography;



namespace Versta.GenUniqueId
{
    public class UniqueId
    {
        public string GenerateUniqueID()
        {
            var randomNumber = new byte[32];
            string refreshToken = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refreshToken = Convert.ToBase64String(randomNumber);
            }
            return refreshToken;
        }
    }
}


