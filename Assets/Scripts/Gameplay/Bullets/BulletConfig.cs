using UnityEngine;

[CreateAssetMenu(
       fileName = "BulletConfig",
       menuName = "Bullets/New BulletConfig"
   )]
public sealed class BulletConfig : ScriptableObject
{
    [SerializeField]
    public float speed;

    [SerializeField]
    public float lifetime;

    [SerializeField]
    public int damage;
}
