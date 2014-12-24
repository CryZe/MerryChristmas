using System.Globalization;

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
