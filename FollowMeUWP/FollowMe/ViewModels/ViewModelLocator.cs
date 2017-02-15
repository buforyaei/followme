using System.Diagnostics.CodeAnalysis;
using Ninject;

namespace FollowMe.ViewModels
{
    public class ViewModelLocator
    {
        public static Bootstrapper BootStrapper;

        static ViewModelLocator()
        {
            InitializeBootstraper();
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public StartViewModel Start => BootStrapper.Kernel.Get<StartViewModel>();

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public FollowViewModel Follow => BootStrapper.Kernel.Get<FollowViewModel>();

        public static void InitializeBootstraper()
        {
            if (BootStrapper != null) return;
            BootStrapper = new Bootstrapper();
            BootStrapper.Initialize();
        }

        public static void Cleanup()
        {
            // AppSession.Current = null;
        }

        public static T GetInstance<T>()
        {
            return BootStrapper.Kernel.Get<T>();
        }
    }
}