using System;
using System.Collections.Generic;
using System.Text;

namespace MawiidaApp
{
    public interface IAudio
    {
        void PlayAudioFile(string filePath);
        bool PauseAudioFile();
    }
}
