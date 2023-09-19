import Home from "./pages/Home";
import ChatPage from "./pages/ChatPage";

import {AuthenticationRoutes} from "./authentication/AuthenticationRoutes"

const RoutesList = [
	{
		path: "",
		element: <Home/>,
		title: "home"
	},
	{
		path: "chat",
		element: <ChatPage/>,
		title: "Chat Pages"
	},
	...AuthenticationRoutes
];

export default RoutesList;