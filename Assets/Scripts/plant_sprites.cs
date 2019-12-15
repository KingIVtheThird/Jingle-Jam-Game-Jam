using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class plant_sprites : ScriptableObject {
    public Sprite emptySprite;
    public Sprite plantedSprite;
    public Sprite caredSprite;
    public Sprite uncaredSprite;
    public Sprite producingSprite;
    public Sprite bountySprite;
    public Sprite deadSprite;
}
