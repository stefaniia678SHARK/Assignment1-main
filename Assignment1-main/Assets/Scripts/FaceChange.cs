using UnityEngine;

public class FaceChange : MonoBehaviour
{

    //functions for changing faces of visitor
    //that will be called in Visitor script

    public SkinnedMeshRenderer facerenderer; 

    public Texture happyFace;
    public Texture annoyedFace;
    public Texture angryFace;

    //I could not assign SkinnedMeshRenderer from inspector
    //so I am getting it from children in Awake
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
