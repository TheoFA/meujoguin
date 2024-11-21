
using UnityEngine;

[CreateAssetMenu (fileName="New Weapon" ,menuName= "ScriptableObjects/Weapon")] 
public class Weapon : ScriptableObject
{
    [Header("Description")]
  public string weaponName;
  public string weaponDescription;
  public string weaponPrice;
  [Header("Stats")]
  public float damage;
  public float speed;
  public float range;
  [Header("Model")]
  public GameObject weaponModel;
}
