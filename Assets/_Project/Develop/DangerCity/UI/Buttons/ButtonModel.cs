using System;

namespace DangerCity.UI.Buttons
{
    [Serializable]
    public class ButtonModel
    {
        public bool WasPerformedThisFrame;
        public int FrameCountLost;
    }
}