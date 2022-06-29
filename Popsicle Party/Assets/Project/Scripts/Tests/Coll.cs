using UnityEngine;

public class Coll : MonoBehaviour
{
    public int index;

    BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        index = transform.GetSiblingIndex();
    }

    public void HitCollider(float damage)
    {
        // Resize the collider's height(X) depends on "damage" 
        if (boxCollider.size.x - damage > 0.0f)
            boxCollider.size = new Vector3(boxCollider.size.x - damage, boxCollider.size.y, boxCollider.size.z - damage);
        else
            Destroy(this); // Remove Coll Component from this gameobject
    }
}
