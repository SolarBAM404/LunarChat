import React from "react";
import Login from "./pages/Login"
import Logout from "./pages/Logout"

export const AuthenticationRoutes = [
	{
		path: "/auth/login",
		element: <Login/>,
		title: "Log In"
	},
	{
		path: "/auth/logout",
		element: <Logout/>,
		title: "Log Out"
	}
];