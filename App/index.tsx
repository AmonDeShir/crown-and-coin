// @ts-ignore
console.log("[index.tsx]: OneJS is good to go")

import { h, render } from 'preact'
import { Panel } from './src/components/panel'
import { Heroes } from './src/components/heroes'
import { MiniMap } from './src/components/MiniMap'
 
function App() {
  return (
    <div class="w-full h-full flex justify-between p-1 pb-2">
      <div class="w-full flex flex-row justify-between">
        <Heroes />
        <MiniMap />
      </div>

      <div class="w-full h-[142px] flex flex-row justify-center">
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