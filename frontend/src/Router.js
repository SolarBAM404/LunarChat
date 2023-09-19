import { Route, Routes } from "react-router-dom";
import RoutesList from "./RoutesList";

const Router = () => {
	const pageRoutes = RoutesList.map(({ path, title, element }) => {
		return <Route key={title} path={`/${path}`} element={element} />;
	});

	return <Routes>{pageRoutes}</Routes>;
};

export default Router;