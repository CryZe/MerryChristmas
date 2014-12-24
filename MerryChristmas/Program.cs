using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerryChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            var textSpeaker = new TextSpeaker(new CultureInfo("de-De"));
            textSpeaker.Speak("Frohe Weihnachten");
            var player = new SilentNightPlayer(Midi.Instrument.AcousticGrandPiano);
            using (player)
            {
                player.Start();
            }
        }
    }
}
