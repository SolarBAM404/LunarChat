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
					<SenderMessage timestamp="12:47pm" status=" " avatarUrl="https://img.freepik.com/free-vector/illustration-user-avatar-icon_53876-5908.jpg?w=826&t=st=1694992683~exp=1694993283~hmac=ac83d5e462866cebc5bdeabae056bf5c1a0a41442760ba6816cbfc2d0a104c65">Hello again Jeff!</SenderMessage>
					<ReceivedMessage username="Jeff" timestamp="12:46pm" status="Read" avatarUrl="https://img.freepik.com/free-vector/illustration-user-avatar-icon_53876-5907.jpg">I am replying with hello world again!!!</ReceivedMessage>
					<SenderMessage timestamp="12:45pm" status=" " avatarUrl="https://img.freepik.com/free-vector/illustration-user-avatar-icon_53876-5908.jpg?w=826&t=st=1694992683~exp=1694993283~hmac=ac83d5e462866cebc5bdeabae056bf5c1a0a41442760ba6816cbfc2d0a104c65">This is me just saying hello world</SenderMessage>
				</div>
				<MessageInput/>
			</div>
			)
	}
}