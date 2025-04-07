namespace EnemySystem
{
    public interface IPerciever
    {
        public void StartPercieving(PercievedObject percievedObject);
        public void StopPercieving(PercievedObject percievedObject);
    }
}
