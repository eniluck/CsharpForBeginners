namespace CafeForDevs.Client
{
    public interface ICafeHttpClient
    {
        Menu GetMenu();
        void SelectMenuItem(int menuItemId);
        Order GetOrder();
    }
}
