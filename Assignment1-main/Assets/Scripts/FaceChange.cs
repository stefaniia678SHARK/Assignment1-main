using UnityEngine;

public class FaceChange : MonoBehaviour
{
    public SkinnedMeshRenderer facerenderer; 

    public Texture happyFace;
    public Texture annoyedFace;
    public Texture angryFace;


    void Awake()
    {
        facerenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    //changing faces
    public void SetHappy()
    {
        var mats = facerenderer.materials;
        mats[1].mainTexture = happyFace;
        facerenderer.materials = mats;
    }
  

    public void SetAnnoyed()
    {
        var mats = facerenderer.materials;
        mats[1].mainTexture = annoyedFace;
        facerenderer.materials = mats;
    }

    public void SetAngry()
    {
        var mats = facerenderer.materials;
        mats[1].mainTexture = angryFace;
        facerenderer.materials = mats;
    }
}
