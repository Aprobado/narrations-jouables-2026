namespace NarrationsJouables
{
    public interface IObservable
    {
        public bool ObservationStateChanged(bool _observed, float distance = -1f);
    }
}