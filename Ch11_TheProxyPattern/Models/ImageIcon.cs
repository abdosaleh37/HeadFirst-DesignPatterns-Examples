using Ch11_TheProxyPattern.Interfaces;

namespace Ch11_TheProxyPattern.Models;

public sealed class ImageIcon(string imageUrl) : IIcon
{
    private readonly string _imageUrl = imageUrl;

    public string Render()
    {
        // Simulate heavy load from disk/network.
        Thread.Sleep(1200);
        return $"[Image loaded from {_imageUrl}]";
    }
}
