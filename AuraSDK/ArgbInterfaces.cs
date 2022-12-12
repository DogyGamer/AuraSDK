namespace AuraSDK;

public interface IArgbDevice
{
    public IArgbStrip Strip { get; protected set; }
    public string Name { get; protected set; } 
    public void Show();
}

public interface IArgbStrip
{
    public int length { get; protected set; }

    public RGBColor GetPixelColor(int index);
    public void FillAll(RGBColor color);

    public void FillPixel(int index, RGBColor color);

    //public void FillByArray(List<RGBColor> colors);

    public void FillByStrip(IArgbStrip strip);
}



public class RGBColor
{
    public int R { get; protected set; }
    public int G { get; protected set; }
    public int B { get; protected set; }

    public int Hex { get; protected set; }
    int getHexFromRGB(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
        Hex = ((r & 0xff) << 16) + ((g & 0xff) << 8) + ((b & 0xff) << 0);
        return Hex;
    }

    (int r, int g, int b) getRGBFromHex(int hex)
    {
        R = (hex >> 16) & 0xFF;
        G = (hex >> 8) & 0xFF;
        B = (hex >> 0) & 0xFF;
        Hex = hex;
        return (r: R, g: G, b: B);
    }

    public RGBColor(int r, int g, int b)
    {
        getHexFromRGB(r, g, b);
    }
    public RGBColor(int hex)
    {
        getRGBFromHex(hex);
    }
}