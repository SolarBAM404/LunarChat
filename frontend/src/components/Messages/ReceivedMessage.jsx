export default function ReceivedMessage ({username, avatarUrl, timestamp, status, children}) {
	return <>
		<div>
			<div className="chat chat-start">
				<div className="chat-header">
					{username}
					<time className="text-xs opacity-50"> {timestamp}</time>
				</div>
				<div className="chat-image avatar">
					<div className="w-10 rounded-full">
						<img src={avatarUrl} />
					</div>
				</div>
				<div className="chat-bubble chat-bubble-primary">{children}</div>
				<div className="chat-footer opacity-50">
					{status}
				</div>
			</div>
		</div>
	</>
}