using UnityEngine;
using DG.Tweening;

public class Popsicle : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private Transform popsicleTransform;
    [SerializeField] private Vector3 rotationVector;
    [SerializeField] public float rotationDuration;

    private void Start()
    {
        //popsicleTransform
        //   .DOLocalRotate(rotationVector, rotationDuration, RotateMode.FastBeyond360)
        //   .SetLoops(-1, LoopType.Restart)
        //   .SetEase(Ease.Linear);
    }

    void Update()
    {
        RotatePopsicle();
    }

    void RotatePopsicle()
    {
        //popsicleTransform.DORotate(rotationVector, rotationDuration).OnComplete(() => {
        //    RotatePopsicle();
        //});

        popsicleTransform.Rotate(rotationVector * rotationDuration * Time.deltaTime);
    }

    public void Hit(int keyIndex, float damage)
    {
        float colliderHeight = 2.6f;
        //Skinned mesh renderer key's value is clamped between 0 & 100
        float newWeight = skinnedMeshRenderer.GetBlendShapeWeight(keyIndex) + damage * (100f / colliderHeight);
        skinnedMeshRenderer.SetBlendShapeWeight(keyIndex, newWeight);
    }
}

