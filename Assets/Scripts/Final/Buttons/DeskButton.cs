using UnityEngine;

public class DeskButton : PokeButton
{
    [SerializeField] bool up = true;
    [SerializeField] float liftSpeed = 1f;
    [SerializeField] Transform controlPanel;

    bool pressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            if (up) { controlPanel.Translate(new Vector3(0, liftSpeed * Time.deltaTime, 0)); }
            else { controlPanel.Translate(new Vector3(0, -liftSpeed * Time.deltaTime, 0)); }
        }
    }

    public override void Press()
    {
        base.Press();
        pressed = true;
    }

    public void Unpress()
    {
        pressed = false;
    }
}
