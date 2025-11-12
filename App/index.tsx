// @ts-ignore
console.log("[index.tsx]: OneJS is good to go")

import { h, render } from 'preact'
import { useState, useEffect, useMemo, useRef } from 'preact/hooks'
import { Bar } from './src/components/bar'
import { Panel } from './src/components/panel'
 
function App() {
  return (
    <div class="w-full h-full justify-center items-center">
      <div class="absolute w-full h-[142px] flex flex-row justify-center bottom-2">
        <div class="w-[850px]">
          <Panel title='Budynki'>
            {"Example text"}
          </Panel>
        </div>
      </div>
    </div>
  )
}
 
render(<App />, document.body)