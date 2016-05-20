using System.Security.Cryptography.X509Certificates;

namespace MarsRover.Contracts
{
    public interface IPosition
    {
        int X { get; set; }

        int Y { get; set; }
    }
}
