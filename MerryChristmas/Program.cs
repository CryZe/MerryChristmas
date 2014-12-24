using System.Globalization;

namespace MerryChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            var textSpeaker = new TextSpeaker(new CultureInfo("de-De"));
            var text = "Frohe Weihnachten \{args.Length > 0 ? args[0] : ""}";
            textSpeaker.Speak(text);
            var player = new SilentNightPlayer(Midi.Instrument.AcousticGrandPiano);
            using (player)
            {
                player.Start();
            }
        }
    }
}
