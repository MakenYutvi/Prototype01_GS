namespace Igor
{
    public interface IPopupListener<in T> where T : IPopup
    {
        void OnPopupShown(T popup);

        void OnPopupActive(T popup);

        void OnPopupInactive(T popup);
        
        void OnPopupHidden(T popup);
    }
}