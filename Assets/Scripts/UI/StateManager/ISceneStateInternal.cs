namespace Foundation
{
    // ?? ?????????, ??? Scene State Manager
    interface ISceneStateInternal
    {
        void InternalBecomeTopmost();
        void InternalResignTopmost();
        void InternalActivate();
        void InternalDeactivate();
        void InternalSetSortingOrder(int order);
    }
}
