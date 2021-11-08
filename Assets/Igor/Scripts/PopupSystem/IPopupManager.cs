namespace Igor
{
    public interface IPopupManager
    {
        void ShowPopup<T>();

        void HidePopup<T>();

        bool IsPopupVisible<T>();

        bool IsPopupActive<T>();

        void AddListener<T>(IPopupListener listener);

        void RemoveListener<T>(IPopupListener listener);
    }
}