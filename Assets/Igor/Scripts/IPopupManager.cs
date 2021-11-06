namespace Igor
{
    public interface IPopupManager
    {
        IPopup CurrentPopup { get; }

        void ShowPopup<T>() where T : IPopup;

        void HidePopup<T>() where T : IPopup;

        void AddListener<T>(IPopupListener<T> listener) where T : IPopup;

        void RemoveListener<T>(IPopupListener<T> listener) where T: IPopup;
    }
}