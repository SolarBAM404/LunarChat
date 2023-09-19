import Store from './Redux/Store/Store'
import { Provider } from 'react-redux';
import Sidebar from "./components/nav/Sidebar"
import Navbar from "./components/nav/Navbar";
import { useEffect } from 'react'
import { themeChange } from 'theme-change'
import Home from './pages/Home'
import ChatPage from './pages/ChatPage'
import Router from './Router'

function App() {
  
  useEffect(() => {
    themeChange(false)
    // 👆 false parameter is required for react project
  }, [])
  
  return (
    <Provider store={Store}>
      <div className="flex">
        <div className="flex-none">
          <Sidebar/>
        </div>
        <div className={"flex flex-col flex-auto"}>
          <div className={"flex-none"}>
            <Navbar name={"Test friend"}/>
          </div>
          <div className="flex-auto px-5 pt-5 p-0 m-0">
            <Router/>
          </div>
        </div>
      </div>
    </Provider>
  );
}

export default App;
