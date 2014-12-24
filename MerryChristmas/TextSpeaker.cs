using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
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

        public void SpeakAsync(String text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                Task.Factory.StartNew(() =>
                {
                    Synth.SpeakAsync(text);
                });
            }
        }

        public void Speak(String text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                Synth.Speak(text);
            }
        }
    }
}
