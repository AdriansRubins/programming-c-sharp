namespace Implementation.Memory;

public interface IMemoryCardStrategy
{
    void SavePicture(Picture picture);
    Picture GetPicture();
}