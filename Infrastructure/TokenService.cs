using System;
namespace NotesApi.Infrastructure
{
    public class TokenService : ITokenService
    {
        public string GetId()
        {
            var test = new Random().Next(0, 10);
            return test / 2 == 0 ? Guid.Empty.ToString() : Guid.NewGuid().ToString();
        }
    }
}

