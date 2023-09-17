import SenderMessage from '../components/Messages/SenderMessage'
import ReceivedMessage from '../components/Messages/ReceivedMessage'
import {Component} from "react";
import "./ChatPage.css"

export default class ChatPage extends Component {
	render() {
		return (
			<div className={"flex flex-col h-full"}>
				<div className={"flex flex-col-reverse flex-auto"}>
					<SenderMessage timestamp="12:47pm" status="Read" avatarUrl="https://example.com/example.png">This is me just saying hello world</SenderMessage>
					<ReceivedMessage username="Jeff" timestamp="12:46pm" status="Read" avatarUrl="https://example.com/example.png">I am replying with hello world again!!!</ReceivedMessage>
				</div>
				<div className={"flex py-3 gap-5 min-w-full"}>
					<input type="text" placeholder="Type here" className="flex-auto input input-bordered min-w-fit" />
					<button className="btn">
						<svg width="28px" height="28x" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" className={"SendMessageBtn"}>
							<g id="SVGRepo_bgCarrier" stroke-width="0"></g>
							<g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g>
							<g id="SVGRepo_iconCarrier">
								<path d="M22 2L2 8.66667L11.5833 12.4167M22 2L15.3333 22L11.5833 12.4167M22 2L11.5833 12.4167" stroke="var(--p)" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"></path>
							</g>
						</svg>
					</button>
				</div>
			</div>
			)
	}
}