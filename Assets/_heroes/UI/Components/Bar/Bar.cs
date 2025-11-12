using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UiKit
{
    [UxmlElement]
    public partial class Bar : VisualElement
    {
        [UxmlAttribute] 
        public string title { get; set; } = "TITLE";
        
        [UxmlAttribute("decorations-count")] 
        public int decorationsCount { get; set; } = 8;

        public Bar()
        {
            var bar = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/_heroes/UI/Components/Bar/Bar.uxml");
            bar.CloneTree(this);

            var ss = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/_heroes/UI/Components/Bar/Bar.uss");
            this.styleSheets.Add(ss);
            
            var label = this.Q<Label>("title");
            label.text = title;

            var left = this.Q<VisualElement>("left");
            var right = this.Q<VisualElement>("right");

            var leftCount = decorationsCount / 2 + (decorationsCount % 2);
            var rightCount = decorationsCount / 2;

            for (var i = 0; i < leftCount; i++)
            {
                left.Add(MakeMotif());
            }
            
            for (var i = 0; i < rightCount; i++)
            {
                right.Add(MakeMotif());
            }
        }

        private VisualElement MakeMotif()
        {
            var e = new VisualElement();
            
            e.AddToClassList("bar__motif");
            
            return e;
        }
    }
}