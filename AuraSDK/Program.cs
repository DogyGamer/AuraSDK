using AuraServiceLib;
using System;
using System.Drawing;



namespace AuraSDK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAuraSdk3 sdk = (IAuraSdk3) new AuraServiceLib.AuraSdk();
            sdk.SwitchMode();
            Console.WriteLine("Acces granted!");
            List<AuraArgbDevice> auraArgbDevices = new();
            foreach (IAuraSyncDevice dev in sdk.Enumerate(0))
            {
                auraArgbDevices.Add(new(dev));
            }

            for (int i = 0; i< auraArgbDevices.Count; i++)
            {
                auraArgbDevices[i].Strip.FillAll(new RGBColor(0x0000FF));
                auraArgbDevices[i].Show();

                Console.WriteLine();
            }

            Thread.Sleep(5000);

            sdk.ReleaseControl(0);
        }
    }
}