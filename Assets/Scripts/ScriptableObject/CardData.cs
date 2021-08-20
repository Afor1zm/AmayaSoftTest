using UnityEngine;

[CreateAssetMenu(fileName = "New CardData", menuName = "Card Data", order = 10)]
public class CardData : ScriptableObject
{
    [SerializeField] private string _identifier;
    [SerializeField] private Sprite _sprite;
    public string Identifier {get => _identifier;}
    public Sprite Sprite { get => _sprite; }
}
