import SenderMessage from '../components/Messages/SenderMessage'
import ReceivedMessage from '../components/Messages/ReceivedMessage'
import MessageInput from '../components/Messages/MessageInput'
import {Component} from "react";
import "./ChatPage.css"

export default class ChatPage extends Component {
	render() {
		return (
			<div className={"flex flex-col h-full"}>
				<div className={"flex flex-col-reverse flex-auto"}>
					<SenderMessage timestamp="12:47pm" status=" " avatarUrl="https://example.com/example.png">This is me just saying hello world</SenderMessage>
					<ReceivedMessage username="Jeff" timestamp="12:46pm" status="Read" avatarUrl="https://example.com/example.png">I am replying with hello world again!!!</ReceivedMessage>
				</div>
				<MessageInput/>
			</div>
			)
	}
}