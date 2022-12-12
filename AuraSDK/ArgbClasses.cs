using AuraServiceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuraSDK;


public class AuraArgbDevice : IArgbDevice
{
    public IArgbStrip Strip { get; set; }
    public string Name { get; set; }

    private IAuraSyncDevice AuraDevice { get; set; }

    public AuraArgbDevice(IAuraSyncDevice AuraDevice) 
    { 
        this.AuraDevice = AuraDevice;
        this.Name = AuraDevice.Name;
        this.Strip = new AuraLedStrip(AuraDevice.Lights);
        Console.WriteLine($"New Device! {Name} {Strip.length} leds");
    }

    public void Show() => AuraDevice.Apply();
}

public class AuraLedStrip : IArgbStrip
{
    public int length { get; set; }
    IAuraRgbLightCollection leds;
    public AuraLedStrip(IAuraRgbLightCollection leds) 
    {
        this.leds = leds;
        length = leds.Count;
    }

    public RGBColor GetPixelColor(int index) => new((int)leds[index].Color);
    public void FillAll(RGBColor color)
    {
        for (int i = 0; i < length; i++)
        {
            leds[i].Color = (uint) color.Hex;
        }
    }

    public void FillPixel(int index, RGBColor color)
    {
        leds[index].Color = (uint) color.Hex;
    }

    public void FillByStrip(IArgbStrip strip)
    {
        if (strip.length  >= length)
        {
            for (int i = 0; i < length; i++)
            {
                FillPixel(i, strip.GetPixelColor(i));
            }
        }
    }
}

