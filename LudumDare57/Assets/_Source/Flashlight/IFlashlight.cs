namespace FlashlightSystem
{
    public interface IFlashlight
    {
        public int CurrentConfigurationIndex { get; }

        public void SwitchToNextConfiguration();

        public void SwitchToPreviousConfiguration();

        public void SwitchToConfiguration(int index);
    }
}
