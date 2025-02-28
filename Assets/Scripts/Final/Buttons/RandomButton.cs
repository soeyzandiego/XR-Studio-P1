using UnityEngine;

public class RandomButton : PokeButton
{
    enum RandomType { CONFETTI, PROP, PASSTHROUGH };

    [SerializeField] RandomType type;
    [SerializeField] ParticleSystem confetti;

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
        base.Press();
        switch (type)
        {
            case RandomType.CONFETTI:
                confetti.Play();
                break;
            case RandomType.PROP:
                GameObject newProp = PropManager.instance.RandomProp();
                break;
            case RandomType.PASSTHROUGH:
                // fade to passthrough
                break;
        }
    }
}
