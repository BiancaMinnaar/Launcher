using System.Threading.Tasks;

namespace BaobabMobile.Interface.ViewController
{
    public interface IMainMenuViewController
    {
        Task Load();
        void CloseMenu();
    }
}
