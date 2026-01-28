using UnityEngine;

public class FaceChange : MonoBehaviour
{
    public Renderer facerenderer; //can be used for both mesh and skinned mesh renderer

    public Texture happyFace;
    public Texture annoyedFace;
    public Texture angryFace;

    //changing faces
    public void SetHappy()
    {
        facerenderer.material.mainTexture = happyFace;
    }

    public void SetAnnoyed()
    {
        facerenderer.material.mainTexture = annoyedFace;
    }

    public void SetAngry()
    {
        facerenderer.material.mainTexture = angryFace;
    }
}
