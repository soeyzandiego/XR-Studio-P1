using UnityEngine;

public class CleanUpButton : PokeButton
{
    [SerializeField] GameObject propBoxPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Press()
    {
        NewPropBox newBox = Instantiate(propBoxPrefab).GetComponent<NewPropBox>();
        newBox.InitBox(NewPropBox.State.CLEANING_UP);
    }
}
