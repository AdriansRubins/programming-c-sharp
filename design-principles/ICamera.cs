using Implementation.Memory;

namespace Implementation;

public interface ICamera
{

    void VoiceCommand();
    void turnOn();

    void turnOff();
    
    char[,] getRawFacePicture(int faceId);
    Picture getFaceArea(int faceId, char[,] face, int[] area);
}