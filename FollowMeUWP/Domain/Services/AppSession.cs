using System;

namespace Domain.Services
{
    public sealed class AppSession
    {
        private static readonly Lazy<AppSession> Lazy =
            new Lazy<AppSession>(() => new AppSession());

        private AppSession()
        {
        }

        public static AppSession Current => Lazy.Value;

        public int Code { get; set; }

        public void Cleanup()
        {
        }
    }
}