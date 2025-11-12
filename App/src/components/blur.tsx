import { h } from "onejs-preact";
import { useEffect, useRef, useState } from "onejs-preact/hooks";
import { RenderTexture, Resources } from "UnityEngine";
import { Background, BackgroundRepeat, Repeat, StyleBackground, StyleBackgroundRepeat } from "UnityEngine/UIElements";

const SCREEN_TEXTURE = Resources.Load("CameraTexture") as RenderTexture;

type Props = { 
  children?: any, 
  blur?: number
  color?: string
  opacity?: number,
};

export function Blur({ children, blur = 5, color = "white", opacity = 0.1 }: Props) {
  const imageRef = useRef<HTMLElement>(null);
  const parentRef = useRef<HTMLElement>(null);
  const [pos, setPos] = useState({w: 0, h: 0, l: 0, t: 0});

  useEffect(() => {
    const image = getVisualElement(imageRef.current);
    const parentImage = getVisualElement(parentRef.current);

    if (!image || !SCREEN_TEXTURE || !parentImage) {
      return;
    }

    image.style.backgroundImage  = new StyleBackground(Background.FromRenderTexture(SCREEN_TEXTURE));
    image.style.backgroundRepeat = new StyleBackgroundRepeat(new BackgroundRepeat(Repeat.NoRepeat, Repeat.NoRepeat));

    const bound = parentImage.worldBound;

    setPos({
      w: 1920 / image.scaledPixelsPerPoint,
      h: 1080 / image.scaledPixelsPerPoint,
      l: -Math.round(bound.x),
      t: -Math.round(bound.y),
    });
  }, []);

  return (
    <div ref={parentRef} class={"w-full h-full overflow-hidden"}>
      <div 
        ref={imageRef} 
        style={{
          position: "absolute",
          top: pos.t, 
          left: pos.l, 
          height: pos.h, 
          width: pos.w,
          filter: `blur(${blur}px)`
        }}
      />
      
      <div class="absolute top-0 left-0 w-full h-full" style={{ backgroundColor: color, opacity }} />

      {children}
    </div>
  );
}

function getVisualElement(element: any): (VisualElement & { scaledPixelsPerPoint: number }) {
  if (!element) {
    return
  }

  return element.ve ?? element.__ve;
}