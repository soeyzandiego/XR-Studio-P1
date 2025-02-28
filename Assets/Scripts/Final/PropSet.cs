using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "PropSet", menuName = "Scriptable Objects/PropSet")]
public class PropSet : ScriptableObject
{
    [SerializeField] public Sprite icon;
    [SerializeField] public GameObject[] props;
}
