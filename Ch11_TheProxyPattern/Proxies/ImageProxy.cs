using Ch11_TheProxyPattern.Interfaces;
using Ch11_TheProxyPattern.Models;

namespace Ch11_TheProxyPattern.Proxies;

public sealed class ImageProxy(string imageUrl) : IIcon
{
    private readonly string _imageUrl = imageUrl;
    private ImageIcon? _realImage;

    public string Render()
    {
        if (_realImage is null)
        {
            Console.WriteLine("Loading image, please wait...");
            _realImage = new ImageIcon(_imageUrl);
        }

        return _realImage.Render();
    }
}
