using System;
using System.Collections.Generic;
using System.Text;

namespace MamaApp.Interfaces {
    public interface ISoundSettings
    {
        void SetToSilent();
        void SetToVibrate();
        void SetPhoneLevelToLouder();
        void SetRingtoneLevelToLouder();
    }
}
