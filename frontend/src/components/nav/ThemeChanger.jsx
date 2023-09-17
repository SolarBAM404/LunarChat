import { useEffect } from 'react'

export default function ThemeChanger () {
	let selectedCss = "btn-active"
	
	return <>
	<button data-set-theme="light" data-act-class={selectedCss} className={"btn btn-ghost"}>Light</button>
	<button data-set-theme="pastel" data-act-class={selectedCss} className={"btn btn-ghost"}>Pastel</button>
	<button data-set-theme="dracula" data-act-class={selectedCss} className={"btn btn-ghost"}>Dracula</button>
	<button data-set-theme="halloween" data-act-class={selectedCss} className={"btn btn-ghost"}>Halloween</button>
	</>
}