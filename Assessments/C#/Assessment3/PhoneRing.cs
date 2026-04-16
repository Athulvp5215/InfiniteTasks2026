using System;

namespace Assessment3
{

    public delegate void RingEventHandler();

    class PhoneRing
    {
        public event RingEventHandler OnRing;

        public void ReceiveCall()
        {
            Console.WriteLine("\nIncoming Call...");
            OnRing?.Invoke();
        }
    }

    class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }

    class ScreenDisplay
    {
        public void ShowCallerInfo()
        {
            Console.WriteLine("Displaying caller info...");
        }
    }

    class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }
}