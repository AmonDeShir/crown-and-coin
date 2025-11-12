using Game.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class TestResource : MonoBehaviour
{
    [SerializeField] private UIDocument  uiDocument;
    
    void Start()
    {
        var material = Resources.Load("Blured") as Texture;
        uiDocument.rootVisualElement.Q<BlurPanel>("scene-toolbar").SetImage(material);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
