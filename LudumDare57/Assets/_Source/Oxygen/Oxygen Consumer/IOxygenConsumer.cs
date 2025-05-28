using System;

namespace OxygenConsumerSystem
{
    public interface IOxygenConsumer
    {
        public event Action OnSuffocationStarted;

        public void StartConsuming();
    }
}
