using System;

namespace Assessment3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            Team team = new Team();
            Console.Write("Enter number of matches: ");
            int matches = Convert.ToInt32(Console.ReadLine());
            team.Pointscalculation(matches);

            // 2
            FileAppend fileDemo = new FileAppend();
            fileDemo.AppendToFile();

            // 3
            PhoneRing phone = new PhoneRing();
            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();
            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += screen.ShowCallerInfo;
            phone.OnRing += vibration.Vibrate;

            phone.ReceiveCall();
            Console.ReadLine();
        }
    }
}