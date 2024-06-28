using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Project.Config;

public static class SecurityHelpers
{
    public static string GetHashedPassword(string password)
    {
        byte[] saltBytes = Convert.FromBase64String("salt");

        string currentHashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: saltBytes,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return currentHashedPassword;
    }
}
