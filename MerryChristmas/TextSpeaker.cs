using System.Globalization;
using System.Speech.Synthesis;
using System.Threading.Tasks;

namespace MerryChristmas
{
    public class TextSpeaker
    {
        private SpeechSynthesizer Synth { get; }

        public TextSpeaker(CultureInfo culture)
        {
            Synth = new SpeechSynthesizer();
            Synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 0, culture);
        }

        public void SpeakAsync(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Task.Factory.StartNew(() =>
                {
                    Synth.SpeakAsync(text);
                });
            }
        }

        public void Speak(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Synth.Speak(text);
            }
        }
    }
}
