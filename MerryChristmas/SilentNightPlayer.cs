using Midi;
using System;
using System.Linq;
using System.Threading;

namespace MerryChristmas
{
    public class SilentNightPlayer : IDisposable
    {
        public const int DEFAULT_VELOCITY = 70;
        public const int DEFAULT_TEMPO = 100;
        public const int OCTAVE_LENGTH = 12;

        private OutputDevice Device { get; }
        private Channel Channel { get; }
        private int Tempo { get; }
        private int Velocity { get; }

        public SilentNightPlayer(
            Instrument instrument = Instrument.AcousticGrandPiano, 
            int tempo = DEFAULT_TEMPO, 
            int velocity = DEFAULT_VELOCITY)
        {
            Tempo = tempo;
            Velocity = velocity;

            Device = OutputDevice.InstalledDevices.First();
            Device.Open();
            Channel = Channel.Channel1;
            Device.SendProgramChange(Channel, instrument);
        }

        public void Dispose()
        {
            Device.Close();
        }

        public void Start()
        {
            // First line
            PlaySound(Pitch.G4, NoteType.QUARTER_NOTE_AND_HALF);
            PlaySound(Pitch.A4, NoteType.EIGHTH_NOTE);
            PlaySound(Pitch.G4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.E4, NoteType.THREE_QUARTERS_NOTE);

            PlaySound(Pitch.G4, NoteType.QUARTER_NOTE_AND_HALF);
            PlaySound(Pitch.A4, NoteType.EIGHTH_NOTE);
            PlaySound(Pitch.G4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.E4, NoteType.THREE_QUARTERS_NOTE);

            PlaySound(Pitch.D5, NoteType.HALF_NOTE);
            PlaySound(Pitch.D5, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.B4, NoteType.HALF_NOTE);
            PlaySound(Pitch.B4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.C5, NoteType.HALF_NOTE);
            PlaySound(Pitch.C5, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.G4, NoteType.THREE_QUARTERS_NOTE);

            PlaySound(Pitch.A4, NoteType.HALF_NOTE);
            PlaySound(Pitch.A4, NoteType.QUARTER_NOTE);

            // Second line
            PlaySound(Pitch.C5, NoteType.QUARTER_NOTE_AND_HALF);
            PlaySound(Pitch.B4, NoteType.EIGHTH_NOTE);
            PlaySound(Pitch.A4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.G4, NoteType.QUARTER_NOTE_AND_HALF);
            PlaySound(Pitch.A4, NoteType.EIGHTH_NOTE);
            PlaySound(Pitch.G4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.E4, NoteType.HALF_NOTE);
            PlaySound(Pitch.E4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.A4, NoteType.HALF_NOTE);
            PlaySound(Pitch.A4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.C5, NoteType.QUARTER_NOTE_AND_HALF);
            PlaySound(Pitch.B4, NoteType.EIGHTH_NOTE);
            PlaySound(Pitch.A4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.G4, NoteType.QUARTER_NOTE_AND_HALF);
            PlaySound(Pitch.A4, NoteType.EIGHTH_NOTE);
            PlaySound(Pitch.G4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.E4, NoteType.HALF_NOTE);
            PlaySound(Pitch.E4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.D5, NoteType.HALF_NOTE);
            PlaySound(Pitch.D5, NoteType.QUARTER_NOTE);

            // Third line
            PlaySound(Pitch.F5, NoteType.QUARTER_NOTE_AND_HALF);
            PlaySound(Pitch.D5, NoteType.EIGHTH_NOTE);
            PlaySound(Pitch.B4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.C5, NoteType.THREE_QUARTERS_NOTE);

            PlaySound(Pitch.E5, NoteType.HALF_NOTE);
            Pause(NoteType.QUARTER_NOTE);

            PlaySound(Pitch.C5, NoteType.QUARTER_NOTE);
            PlaySound(Pitch.G4, NoteType.QUARTER_NOTE);
            PlaySound(Pitch.E4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.G4, NoteType.QUARTER_NOTE_AND_HALF);
            PlaySound(Pitch.F4, NoteType.EIGHTH_NOTE);
            PlaySound(Pitch.D4, NoteType.QUARTER_NOTE);

            PlaySound(Pitch.C4, NoteType.THREE_QUARTERS_NOTE);

            Pause(NoteType.FULL_NOTE);
        }

        private void PlaySound(Pitch pitch, NoteType note)
        {
            Device.SendNoteOn(Channel, pitch, Velocity);
            Sleep(Tempo * (int)note);
            Device.SendNoteOff(Channel, pitch, Velocity);
        }

        private void Pause(NoteType note)
        {
            Sleep(Tempo * (int)note);
        }

        private void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}
